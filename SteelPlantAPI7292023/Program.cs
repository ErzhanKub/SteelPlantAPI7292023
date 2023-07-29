using Microsoft.OpenApi.Models;
using Serilog;
using SteelPlantAPI7292023.Filtres;
using SteelPlantAPI7292023.Interfaces;
using SteelPlantAPI7292023.Services;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<LogFilter>();
});
builder.Services.AddScoped<IEmployeeManagement, EmployeeManagement>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();
builder.Services.AddSwaggerGen(option =>
{
    option.EnableAnnotations();
    option.ExampleFilters();
    option.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "EmployeeManagementAPI Docs.",
        Description = "Документация работников Steel Plant.",
        TermsOfService = new Uri("https://www.youtube.com/watch?v=dQw4w9WgXcQ"),
        Contact = new OpenApiContact()
        {
            Name = "SteelPlant",
            Url = new Uri("https://www.elderscrollsonline.com/")
        }
    }); ;
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option =>
    {
        option.DocumentTitle = "EmployeeManagementAPI Docs.";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
