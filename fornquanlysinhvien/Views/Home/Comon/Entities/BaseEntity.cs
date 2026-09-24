using System;

namespace TBDUni.CorePlatform.Domain.Common.Entities;

/// <summary>
/// Base entity class for all domain entities
/// </summary>
public abstract class BaseEntity<TId>
    where TId : notnull
{
    // ========== PROPERTIES ==========
    /// <summary>
    /// Gets the entity ID
    /// </summary>
    public TId Id { get; protected set; }

    // ========== CONSTRUCTORS ==========
    /// <summary>
    /// Default constructor
    /// </summary>
    protected BaseEntity()
    {
    }

    /// <summary>
    /// Constructor with ID
    /// </summary>
    protected BaseEntity(TId id)
    {
        Id = id;
    }

    // ========== METHODS ==========
    /// <summary>
    /// Determines if the entity is valid
    /// </summary>
    public virtual bool IsValid()
    {
        return true;
    }

    /// <summary>
    /// Gets the entity's display name
    /// </summary>
    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }

    /// <summary>
    /// Checks equality based on ID
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity<TId> other)
            return false;

        return Id.Equals(other.Id);
    }

    /// <summary>
    /// Gets the hash code based on ID
    /// </summary>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}