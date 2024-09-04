using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealtyAgency.Core.Entities.Auth;
using RealtyAgency.Core.Repositories.DTO;
using RealtyAgency.Core.Services;

namespace RealtyAgency.Infrastructure.Controllers;

[ApiController]
[EnableCors("AllowSpecificOrigin")]
[Route("api")]
public class AccountController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly UserManager<CommonUser> _userManager;

    public AccountController(IAuthService authService, UserManager<CommonUser> userManager)
    {
        _authService = authService;
        _userManager = userManager;
    }
    
    [HttpPost("register/client")]
    public async Task<IActionResult> RegisterClient([FromBody] RegisterClientDTO model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid data");
        }
        
        var result = await _authService.RegisterClientAsync(model);

        if (result.Success)
        {
            return Ok(new {Message = "Клиент успешно зарегистрирован"});
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error);
        }

        return BadRequest(ModelState);
    }
    
    [HttpPost("register/realtor")]
    public async Task<IActionResult> RegisterRealtor([FromBody] RegisterRealtorDTO model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid data");
        }
        
        var result = await _authService.RegisterRealtorAsync(model);

        if (result.Success)
        {
            return Ok(new {Message = "Риэлтор успешно зарегистрирован"});
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error);
        }

        return BadRequest(ModelState);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        var result = await _authService.LoginAsync(model);
        return Ok(result);
    }
}