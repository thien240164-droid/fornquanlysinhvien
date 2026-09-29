using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using VTBDU.CorePlatform.Domain.Common.Events;
using VTBDU.CorePlatform.Domain.Entities;

namespace VTBDU.CorePlatform.Infrastructure.Persistence.DbContext;

public interface ICurrentTenant
{
    Guid? TenantId { get; }
}


public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly Guid? _currentTenantId;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        ICurrentTenant currentTenant)
        : base(options)
    {
        _currentTenantId = currentTenant?.TenantId;
    }

    // ============================
    // Model configuration
    // ============================
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //ÁP DỤNG CONFIGURATION TỰ ĐỘNG
        //1 dòng → load toàn bộ configuration
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // =========================================
        // Ignore domain events (NOT entities)
        // Loại bỏ DomainEvent khỏi EF model
        // =========================================
        modelBuilder.Ignore<DomainEvent>();

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            ApplySoftDeleteFilter(modelBuilder, entityType);
            ApplyTenantFilter(modelBuilder, entityType);
        }

    }
    private void ApplySoftDeleteFilter(ModelBuilder modelBuilder, IMutableEntityType entityType)
    {
        var prop = entityType.FindProperty("IsDeleted");
        if (prop == null) return;

        var parameter = Expression.Parameter(entityType.ClrType, "e");
        var body = Expression.Equal(
            Expression.Property(parameter, "IsDeleted"),
            Expression.Constant(false)
        );

        var lambda = Expression.Lambda(body, parameter);

        modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
    }

    private void ApplyTenantFilter(ModelBuilder modelBuilder, IMutableEntityType entityType)
    {
        if (_currentTenantId == null) return;

        var prop = entityType.FindProperty("TenantId");
        if (prop == null) return;

        var parameter = Expression.Parameter(entityType.ClrType, "e");

        var body = Expression.Equal(
            Expression.Property(parameter, "TenantId"),
            Expression.Constant(_currentTenantId.Value)
        );

        var lambda = Expression.Lambda(body, parameter);

        modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
    }

    // ============================
    // DbSets
    // ============================
    public DbSet<User> Users => Set<User>();



}