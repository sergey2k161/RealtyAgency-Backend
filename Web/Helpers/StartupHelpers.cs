using System.Collections.Immutable;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealtyAgency.Core.Entities.Auth;
using RealtyAgency.Core.Repositories;
using RealtyAgency.Core.Repositories.Client;
using RealtyAgency.Core.Repositories.Interfaces.ApartmentRepository;
using RealtyAgency.Core.Repositories.Realtor;
using RealtyAgency.Core.Services;
using RealtyAgency.Infrastructure.Repositories;
using RealtyAgency.Infrastructure.Services;
using RealtyAgency.Infrastructure.Services.Auth;
using RealtyAgency.Infrastructure.Services.Log;
using RealtyAgency.Persistence;
using RealtyAgency.Persistence.Configurations;


namespace RealtyAgency.Web.Helpers;

public static class StartupHelpers
{
    public static void RegisterDomainServices(WebApplicationBuilder webApplicationBuilder, WebApplicationBuilder builder)
    {
        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddIdentity<CommonUser, IdentityRole<int>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        });

        builder.Services.AddScoped<RoleInitializer>();
        
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IRealtorRepository, RealtorRepository>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
        builder.Services.AddScoped<IApartmentService, ApartmentService>();
    }
}