using Potato.Product.Api.Extensions.Api;
using Potato.Product.Api.Extensions.EntityFramework;
using Potato.Product.Api.Extensions.HealthCheck;
using Potato.Product.Api.Extensions.Log;
using Potato.Product.Api.Extensions.Swagger;
using Potato.Product.Infra.CrossCutting;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.AddSerilog(builder.Configuration, "API PotatoStore");
    Log.Information("Getting the motors running...");

    builder.Services.AddApiExtensions();

    builder.Services.AddSwaggerExtensions();

    builder.Services
            .AddHealthCheckExtensions(builder.Configuration);

    builder.Services
        .AddHealthChecksUIExtensions();

    //IoC
    builder.Services.AddDependeciesInjections();

    builder.Services.AddEntityFrameworkExtensions(builder.Configuration);

    //----------------------------------------------------

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwaggerExtensions();
    }
    else
    {
        app.UseHsts();
    }

    app.UseHealthChecksExtensions();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}