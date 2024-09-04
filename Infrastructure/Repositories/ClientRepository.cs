using RealtyAgency.Core.Entities;
using RealtyAgency.Core.Repositories.Client;
using RealtyAgency.Persistence;

namespace RealtyAgency.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;
    
    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Client> GetByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}