using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using VTBDU.CorePlatform.Infrastructure.Persistence.DbContext;

namespace VTBDU.CorePlatform.Infrastructure.Persistence.Configurations;

/// <summary>
/// Design-time factory for EF Core migrations
/// Factory cho EF Core khi chạy migration
/// </summary>
public sealed class ApplicationDbContextFactory
    : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        // Build configuration manually
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        // ⚠️ DESIGN - TIME ONLY
        // Không có HttpContext → không có tenant
        ICurrentTenant currentTenant = new DesignTimeTenant();

        return new ApplicationDbContext(optionsBuilder.Options, currentTenant);
    }

    private sealed class DesignTimeTenant : DbContext.ICurrentTenant
    {
        public Guid? TenantId => null;
    }
}


