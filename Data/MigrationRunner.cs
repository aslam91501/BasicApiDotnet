using FluentMigrator.Runner;

namespace BasicApi.Data
{
    public class MigrationRunner
    {
        private readonly IServiceProvider _serviceProvider;

        public MigrationRunner(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void MigrateDatabase()
        {
            using var scope = _serviceProvider.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        public void MigrateDown(long version)
        {
            using var scope = _serviceProvider.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateDown(version);
        }

        public void RollbackToVersion(long version)
        {
            using var scope = _serviceProvider.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.RollbackToVersion(version);
        }
    }
}