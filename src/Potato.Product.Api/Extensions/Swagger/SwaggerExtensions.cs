namespace Potato.Product.Api.Extensions.Swagger
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerExtensions(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void UseSwaggerExtensions(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    //foreach (var description in provider.ApiVersionDescriptions)
                    //{
                    //    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    //}
                });
        }
    }
}
