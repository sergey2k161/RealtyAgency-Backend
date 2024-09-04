using RealtyAgency.Core.Entities;
using RealtyAgency.Core.Repositories.Realtor;
using RealtyAgency.Persistence;

namespace RealtyAgency.Infrastructure.Repositories;

public class RealtorRepository : IRealtorRepository
{
    private readonly ApplicationDbContext _context;

    public RealtorRepository(ApplicationDbContext context)
    {
        _context= context;
    }
    
    public async Task<Realtor> GetByIdAsync(int id)
    {
        return await _context.Realtors.FindAsync(id);
    }

    public async Task AddAsync(Realtor realtor)
    {
        await _context.Realtors.AddAsync(realtor);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}