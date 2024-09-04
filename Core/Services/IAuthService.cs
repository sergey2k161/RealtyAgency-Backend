using RealtyAgency.Core.Repositories.DTO;

namespace RealtyAgency.Core.Services;

public interface IAuthService
{
    Task<AuthResultDTO> RegisterClientAsync(RegisterClientDTO model);
    Task<AuthResultDTO> RegisterRealtorAsync(RegisterRealtorDTO model);
    Task<AuthResultDTO> LoginAsync(LoginDTO model);
}