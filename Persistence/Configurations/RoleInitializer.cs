using Microsoft.AspNetCore.Identity;

namespace RealtyAgency.Persistence.Configurations;

public class RoleInitializer
{
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    
    public RoleInitializer(RoleManager<IdentityRole<int>> roleManager)
    {
        _roleManager = roleManager;
    }
    
    public async Task InitializeAsync()
    {
        string[] roles = { "Admin", "Realtor", "Client" };
        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole<int>(role));
            }
        }
    }
}