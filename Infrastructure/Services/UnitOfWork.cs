using RealtyAgency.Core.Repositories;
using RealtyAgency.Core.Repositories.Client;
using RealtyAgency.Core.Repositories.Realtor;
using RealtyAgency.Infrastructure.Repositories;
using RealtyAgency.Persistence;

namespace RealtyAgency.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private ClientRepository _clientRepository;
    private RealtorRepository _realtorRepository;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public IClientRepository ClientRepository => _clientRepository ??= new ClientRepository(_context);
    public IRealtorRepository RealtorRepository => _realtorRepository ??= new RealtorRepository(_context);
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}