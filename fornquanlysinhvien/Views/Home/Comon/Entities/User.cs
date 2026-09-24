using TBDUni.CorePlatform.Domain.Common.Constants;
using TBDUni.CorePlatform.Domain.Common.Entities;
using TBDUni.CorePlatform.Domain.Common.Enums;
using TBDUni.CorePlatform.Domain.Common.Events;

namespace TBDUni.CorePlatform.Domain.Entities.Identity;

/// <summary>
/// User aggregate root
/// </summary>
public class User : AggregateRoot<Guid>
{
    public string UserName { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public bool EmailConfirmed { get; private set; }
    public bool PhoneNumberConfirmed { get; private set; }
    public string? SecurityStamp { get; private set; }
    public UserStatus Status { get; private set; } = UserStatus.PendingActivation;
    public DateTime? LastLoginAt { get; private set; }
    public DateTime? LockoutEnd { get; private set; }
    public int FailedLoginAttempts { get; private set; }
    public Guid? StudentId { get; private set; }
    public bool IsSystemAdmin { get; private set; } = false;
    public string UserType { get; private set; } = UserTypeConstants.User;
    public Guid? LanguageId { get; private set; }

    // Constructor
    private User() { }

    public User(string email, string passwordHash,
                string? firstName, string? lastName,
                bool isSystemAdmin = false)
    {
        Email = email.Trim().ToLower();
        PasswordHash = passwordHash;

        FirstName = firstName;
        LastName = lastName;

        IsSystemAdmin = isSystemAdmin;
        UserType = UserTypeConstants.User;

        SecurityStamp = Guid.NewGuid().ToString();
        Status = UserStatus.PendingActivation;

        CreatedAt = DateTime.UtcNow;

        RaiseDomainEvent(new UserCreatedEvent(Id, Email));
    }

    // Factory method
    public static User Create(
        string email,
        string passwordHash,
        string? firstName,
        string? lastName,
        bool isTenantAdmin = false
    )
    {
        var user = new User(email, passwordHash, firstName, lastName, false);
        return user;
    }

    public static User CreateSystemAdmin(
        string email,
        string passwordHash)
    {
        var user = new User()
        {
            Email = email,
            PasswordHash = passwordHash,
            IsSystemAdmin = true,
            Status = UserStatus.Active,
            UserType = UserTypeConstants.SystemAdmin,
            CreatedAt = DateTime.UtcNow
        };

        user.RaiseDomainEvent(new SystemAdminCreatedEvent(user.Id, user.Email));

        return user;
    }

    public void PromoteToSystemAdmin()
    {
        IsSystemAdmin = true;
        UserType = UserTypeConstants.SystemAdmin;
    }

    // Methods
    public string GetFullName()
    {
        return $"{FirstName} {LastName}".Trim();
    }

    // =========================
    // LOGIN DOMAIN LOGIC
    // =========================
    public bool IsLocked()
    {
        return LockoutEnd.HasValue && LockoutEnd > DateTime.UtcNow;
    }

    public void ConfirmEmail()
    {
        if (EmailConfirmed)
            return;

        EmailConfirmed = true;

        if (Status == UserStatus.PendingActivation)
        {
            Status = UserStatus.Active;
        }

        UpdatedAt = DateTime.UtcNow;

        RaiseDomainEvent(new UserProfileUpdatedEvent(Id));
    }

    public void ConfirmPhoneNumber()
    {
        PhoneNumberConfirmed = true;
        RaiseDomainEvent(new UserProfileUpdatedEvent(Id));
    }

    public void UpdateProfile(string? firstName, string? lastName, string? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        UpdatedAt = DateTime.UtcNow;

        RaiseDomainEvent(new UserProfileUpdatedEvent(Id));
    }

    public void RecordSuccessfulLogin()
    {
        LastLoginAt = DateTime.UtcNow;
        FailedLoginAttempts = 0;
        LockoutEnd = null;
        UpdatedAt = DateTime.UtcNow;
    }

    public void RecordFailedLogin(int maxAttempts = 5)
    {
        FailedLoginAttempts++;

        if (FailedLoginAttempts >= maxAttempts)
        {
            LockoutEnd = DateTime.UtcNow.AddMinutes(30);
            Status = UserStatus.Locked;
        }

        UpdatedAt = DateTime.UtcNow;
    }

    public void Unlock()
    {
        FailedLoginAttempts = 0;
        LockoutEnd = null;
        Status = UserStatus.Active;
        UpdatedAt = DateTime.UtcNow;
    }

    // =========================
    // SECURITY
    // =========================
    public void ChangePassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
        SecurityStamp = Guid.NewGuid().ToString();
        UpdatedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        Status = UserStatus.Active;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        Status = UserStatus.Inactive;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Lock()
    {
        Status = UserStatus.Locked;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeLanguage(Guid languageId, Guid? updatedByUserId)
    {
        LanguageId = languageId;
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = updatedByUserId;

        RaiseDomainEvent(new UserProfileUpdatedEvent(Id));
    }
}
