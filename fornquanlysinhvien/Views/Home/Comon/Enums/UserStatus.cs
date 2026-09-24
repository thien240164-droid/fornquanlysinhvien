namespace TBDUni.CorePlatform.Domain.Common.Enums;

/// <summary>
/// Enum representing the status of a user
/// </summary>
public enum UserStatus
{
    /// <summary>
    /// User account is pending activation
    /// </summary>
    PendingActivation = 0,

    /// <summary>
    /// User account is active
    /// </summary>
    Active = 1,

    /// <summary>
    /// User account is inactive
    /// </summary>
    Inactive = 2,

    /// <summary>
    /// User account is locked
    /// </summary>
    Locked = 3,

    /// <summary>
    /// User account is suspended
    /// </summary>
    Suspended = 4,

    /// <summary>
    /// User account is disabled
    /// </summary>
    Disabled = 5
}
