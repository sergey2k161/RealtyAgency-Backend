using RealtyAgency.Core.Repositories.DTO;

namespace RealtyAgency.Core.Repositories.Auth;

public interface IAuthRepository
{
    Task<AuthResultDTO> RegiseterClient(RegisterClientDTO model);
    Task<AuthResultDTO> RegiseterRealtor(RegisterRealtorDTO model);
    Task<AuthResultDTO> Login(LoginDTO model);
}