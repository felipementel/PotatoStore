using Microsoft.EntityFrameworkCore;
using Potato.Product.Infra.Database;

namespace Potato.Product.Api.Extensions.EntityFramework
{
    public static class EntityFrameworkExtensions
    {
        public static void AddEntityFrameworkExtensions(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ProductContext>(p =>
            {
                p.UseNpgsql(configuration["ConnectionString:Database"],
                w =>
                {
                    w.CommandTimeout(40);
                    w.EnableRetryOnFailure(
                        maxRetryCount: 1,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorCodesToAdd: null);
                });
                p.EnableSensitiveDataLogging();
                p.UseQueryTrackingBehavior(Microsoft.EntityFrameworkCore.QueryTrackingBehavior.TrackAll);
                p.EnableDetailedErrors();
                p.EnableThreadSafetyChecks();
            });
        }
    }
}
