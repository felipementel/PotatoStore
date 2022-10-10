using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Potato.Product.Api.Extensions.HealthCheck
{
    public static class HealthCheckExtensions
    {
        public static void AddHealthCheckExtensions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddHealthChecks()
                .AddNpgSql(
                npgsqlConnectionString: configuration["ConnectionString:Database"],
                healthQuery: "SELECT 1;",
                name: "postgresql",
                failureStatus: HealthStatus.Degraded,
                tags: new string[] { "db", "sql", "postgresql" });
        }

        public static void AddHealthChecksUIExtensions(
            this IServiceCollection services)
        {
            services
            .AddHealthChecksUI(setup =>
            {
                setup.DisableDatabaseMigrations();
                // Set the maximum history entries by endpoint that will be served by the UI api middleware
                setup.MaximumHistoryEntriesPerEndpoint(50);
                //Only one active request will be executed at a time.
                //All the excedent requests will result in 429 (Too many requests)
                setup.SetApiMaxActiveRequests(1);
                setup.SetEvaluationTimeInSeconds(5); // Configures the UI to poll for healthchecks updates every 5 seconds
                setup.AddHealthCheckEndpoint("API with Health Checks", "/healthz");
            }).AddInMemoryStorage();
        }

        public static void UseHealthChecksExtensions(this WebApplication app)
        {
            app.UseHealthChecks("/healthz", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options => 
            { 
                options.UIPath = "/dashboard";
            });
        }
    }
}