using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TastyPoint.API.Shared.Domain.Repositories;
using TastyPoint.API.Shared.Persistence.Contexts;
using TastyPoint.API.Shared.Persistence.Repositories;
using TastyPoint.API.TastyPoint.Domain.Models;
using TastyPoint.API.TastyPoint.Domain.Repositories;
using TastyPoint.API.TastyPoint.Domain.Services;
using TastyPoint.API.TastyPoint.Mapping;
using TastyPoint.API.TastyPoint.Persistence.Repositories;
using TastyPoint.API.TastyPoint.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


// AppSettings Configuration
builder.Services.AddEndpointsApiExplorer();
// OpenAPI Configuration
builder.Services.AddSwaggerGen();

// AppSettings Configuration
// TODO


//OpenAPI Configuration
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Tasty Point API",
        Description = "Tasty Point Web Services",
        Contact = new OpenApiContact
        {
            Name = "TastyPoint.studio",
            Url = new Uri("https://www.instagram.com/leograu.js/")
        }
    });
    options.EnableAnnotations();
});

// Add Database connection
var connectionString = builder.Configuration.GetConnectionString("TastyPadDbConnection");
builder.Services.AddDbContext<TastyPointDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);


// Add lower case routes
builder.Services.AddRouting(
    options => options.LowercaseUrls = true);

// CORS Service addition
builder.Services.AddCors();

// Dependency Injection Configuration

// Shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// TastyPoint Injection Configuration
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();

// Security Injection

// Automapper Configuration

builder.Services.AddAutoMapper(
    typeof(TastyPoint.API.TastyPoint.Mapping.ModelToResourceProfile),
    typeof(TastyPoint.API.TastyPoint.Mapping.ResourceToModelProfile)
);

// Validation fro Ensuring Database Objects are created
var app = builder.Build();
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<TastyPointDbContext>())
{
    context!.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => 
    x.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();