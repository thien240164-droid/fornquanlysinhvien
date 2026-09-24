using System;

namespace TBDUni.CorePlatform.Domain.Common.Events;

/// <summary>
/// Base class for all domain events
/// </summary>
public abstract class DomainEvent
{
    /// <summary>
    /// Gets the domain event ID
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Gets the creation timestamp
    /// </summary>
    public DateTime OccurredAt { get; } = DateTime.UtcNow;
}

/// <summary>
/// Event raised when an entity is soft deleted
/// </summary>
public class EntitySoftDeletedEvent<TId> : DomainEvent where TId : notnull
{
    public TId EntityId { get; }

    public EntitySoftDeletedEvent(TId entityId)
    {
        EntityId = entityId;
    }
}

/// <summary>
/// Event raised when an entity is restored
/// </summary>
public class EntityRestoredEvent<TId> : DomainEvent where TId : notnull
{
    public TId EntityId { get; }

    public EntityRestoredEvent(TId entityId)
    {
        EntityId = entityId;
    }
}

/// <summary>
/// Event raised when a user is created
/// </summary>
public class UserCreatedEvent : DomainEvent
{
    public Guid UserId { get; }
    public string Email { get; }

    public UserCreatedEvent(Guid userId, string email)
    {
        UserId = userId;
        Email = email;
    }
}

/// <summary>
/// Event raised when a system admin is created
/// </summary>
public class SystemAdminCreatedEvent : DomainEvent
{
    public Guid UserId { get; }
    public string Email { get; }

    public SystemAdminCreatedEvent(Guid userId, string email)
    {
        UserId = userId;
        Email = email;
    }
}

/// <summary>
/// Event raised when user profile is updated
/// </summary>
public class UserProfileUpdatedEvent : DomainEvent
{
    public Guid UserId { get; }

    public UserProfileUpdatedEvent(Guid userId)
    {
        UserId = userId;
    }
}

/// <summary>
/// Event raised when user language is changed
/// </summary>
public class UserLanguageChangedEvent : DomainEvent
{
    public Guid UserId { get; }
    public Guid LanguageId { get; }
    public Guid? UpdatedByUserId { get; }

    public UserLanguageChangedEvent(Guid userId, Guid languageId, Guid? updatedByUserId = null)
    {
        UserId = userId;
        LanguageId = languageId;
        UpdatedByUserId = updatedByUserId;
    }
}

