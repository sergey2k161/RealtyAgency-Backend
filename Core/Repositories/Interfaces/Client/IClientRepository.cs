namespace RealtyAgency.Core.Repositories.Client;

public interface IClientRepository
{
    Task<Entities.Client> GetByIdAsync(int id);
    Task AddAsync(Entities.Client client);
    Task SaveChangesAsync();
}