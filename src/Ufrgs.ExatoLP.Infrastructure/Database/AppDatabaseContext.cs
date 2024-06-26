using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Ufrgs.ExatoLP.Domain.Configs;

namespace Ufrgs.ExatoLP.Infrastructure.Database;

public class AppDatabaseContext(IOptions<ConnectionStringConfigs> connectionStringConfigs) : DbContext
{
    private readonly ConnectionStringConfigs _connectionStringConfigs = connectionStringConfigs.Value;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql(_connectionStringConfigs.Postgres);

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDatabaseContext).Assembly);
}
