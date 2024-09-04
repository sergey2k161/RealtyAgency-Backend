using RealtyAgency.Core.Entities.Auth;

namespace RealtyAgency.Core.Services;

public interface IJwtTokenService
{
    string GenerateJwtToken(CommonUser user, IList<string> roles);
}