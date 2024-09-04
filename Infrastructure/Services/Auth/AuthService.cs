using Microsoft.AspNetCore.Identity;
using RealtyAgency.Core.Entities.Auth;
using RealtyAgency.Core.Repositories;
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
}