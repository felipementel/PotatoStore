using Potato.Product.Api.Converters;

namespace Potato.Product.Api.Extensions.Api
{
    public static class ApiExtensions
    {
        public static void AddApiExtensions(this IServiceCollection services)
        {
            services
                   .AddControllers()
                   .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter()));

            services.AddApiVersioning(
                options =>
                {
                    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                });
            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
        }
    }
}
