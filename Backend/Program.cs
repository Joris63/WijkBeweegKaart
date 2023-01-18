using Backend.Logic;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Context;
using System.Text.Json.Serialization;
using Backend.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddScoped<IMapRepository, MapRepository>();
builder.Services.AddScoped<MapLogic>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserLogic>();

builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<DonationLogic>();

builder.Services.AddScoped<IUserLevelRepository, UserLevelRepository>();
builder.Services.AddScoped<UserLevelLogic>();

builder.Services.AddScoped<ILevelRepository, LevelRepository>();
builder.Services.AddScoped<LevelLogic>();

builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<RegionLogic>();

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<LocationLogic>();

builder.Services.AddScoped<JwtService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<BackendContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connectionstring")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsDevelopment", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
             .AllowAnyHeader()
             .AllowAnyMethod()
             .AllowCredentials();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsDevelopment");

app.UseAuthorization();

app.MapControllers();

app.Run();
