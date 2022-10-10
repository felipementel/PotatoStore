using Potato.Product.Api.Converters;
using Potato.Product.Api.Extensions.Api;
using Potato.Product.Api.Extensions.EntityFramework;
using Potato.Product.Api.Extensions.HealthCheck;
using Potato.Product.Api.Extensions.Swagger;
using Potato.Product.Infra.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

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
