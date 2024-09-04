using Microsoft.AspNetCore.Identity;
using RealtyAgency.Core.Entities;
using RealtyAgency.Core.Entities.Auth;
using RealtyAgency.Core.Repositories;
using RealtyAgency.Core.Repositories.DTO;
using RealtyAgency.Core.Services;
using RealtyAgency.Persistence;

namespace RealtyAgency.Infrastructure.Services.Auth;

public class AuthService : IAuthService
{
    private readonly UserManager<CommonUser> _userManager;
    private readonly SignInManager<CommonUser> _signInManager;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Конструктор для зависимострей
    /// </summary>
    /// <param name="userManager"></param>
    /// <param name="signInManager"></param>
    /// <param name="jwtTokenService"></param>
    /// <param name="unitOfWork"></param>
    /// <param name="context"></param>
    public AuthService(
        UserManager<CommonUser> userManager,
        SignInManager<CommonUser> signInManager,
        IJwtTokenService jwtTokenService,
        IUnitOfWork unitOfWork,
        ApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtTokenService = jwtTokenService;
        _unitOfWork = unitOfWork;
        _context = context;
    }

    public async Task<AuthResultDTO> RegisterClientAsync(RegisterClientDTO model)
    {
        var user = new CommonUser
        {
            UserName = model.Email,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        
        if (!result.Succeeded)
        {
            return new AuthResultDTO {Success = false, Errors = result.Errors.Select(e => e.Description).ToList()};
        }
        
        var userId = Convert.ToInt32(user.Id);
        
        await _userManager.AddToRoleAsync(user, "Client");

        var client = new Client
        {
            CommonUserId = userId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };

        await _unitOfWork.ClientRepository.AddAsync(client);
        await _unitOfWork.CommitAsync();
        
        return await LoginAsync(new LoginDTO{ Email = model.Email, Password = model.Password});
    }

    public async Task<AuthResultDTO> RegisterRealtorAsync(RegisterRealtorDTO model)
    {
        var user = new CommonUser
        {
            UserName = model.Email,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        
        if (!result.Succeeded)
        {
            return new AuthResultDTO {Success = false, Errors = result.Errors.Select(e => e.Description).ToList()};
        }
        
        var userId = Convert.ToInt32(user.Id);
        
        await _userManager.AddToRoleAsync(user, "Realtor"); 

        var realtor = new Realtor
        {
            CommonUserId = userId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        };
        
        await _unitOfWork.RealtorRepository.AddAsync(realtor);
        await _unitOfWork.CommitAsync();
        
        return await LoginAsync(new LoginDTO{ Email = model.Email, Password = model.Password});
    }

    public async Task<AuthResultDTO> LoginAsync(LoginDTO model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            return new AuthResultDTO {Success = false, Errors = new List<string> {"Пользователь не найден"}};
        }
        
        var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);
        if (!result.Succeeded)
        {
            return new AuthResultDTO {Success = false, Errors = new List<string> {"Неверный пароль"}};
        }
        
        var roles = await _userManager.GetRolesAsync(user);
        var token = _jwtTokenService.GenerateJwtToken(user, roles);
        
        return new AuthResultDTO
        {
            Success = true,
            Token = token
        };
    }
}