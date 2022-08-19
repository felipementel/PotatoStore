using Microsoft.EntityFrameworkCore;
using Potato.Product.Api.Converters;
using Potato.Product.Application.AppServices;
using Potato.Product.Application.Interfaces.Services;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Repositories;
using Potato.Product.Domain.Aggregates.Products.Interfaces.Services;
using Potato.Product.Domain.Aggregates.Products.Services;
using Potato.Product.Infra.Database;
using Potato.Product.Infra.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
       .AddControllers()
       .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new DateOnlyConverter()));

//builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddApiVersioning(
    options =>
    {
        // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
        options.ReportApiVersions = true;
    });
builder.Services.AddVersionedApiExplorer(
    options =>
    {
        // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
        // note: the specified format code will format the version as "'v'major[.minor][-status]"
        options.GroupNameFormat = "'v'VVV";

        // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
        // can also be used to control the format of the API version in route templates
        options.SubstituteApiVersionInUrl = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IoC
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<ProductContext>(p =>
{
    p.UseNpgsql(builder.Configuration["ConnectionString:Database"],
        w =>
        {
            w.CommandTimeout(40);
            w.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorCodesToAdd: null);
        });
    p.EnableSensitiveDataLogging();
    p.UseQueryTrackingBehavior(Microsoft.EntityFrameworkCore.QueryTrackingBehavior.TrackAll);
    p.EnableDetailedErrors();
    //p.EnableThreadSafetyChecks();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
