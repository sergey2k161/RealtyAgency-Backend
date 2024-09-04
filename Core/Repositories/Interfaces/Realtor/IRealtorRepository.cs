namespace RealtyAgency.Core.Repositories.Realtor;

public interface IRealtorRepository
{
    Task<Entities.Realtor> GetByIdAsync(int id);
    Task AddAsync(Entities.Realtor realtor);
    Task SaveChangesAsync();
}