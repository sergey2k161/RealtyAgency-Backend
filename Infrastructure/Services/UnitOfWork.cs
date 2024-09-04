using RealtyAgency.Core.Repositories;
using RealtyAgency.Core.Repositories.Client;
using RealtyAgency.Core.Repositories.Realtor;
using RealtyAgency.Persistence;

namespace RealtyAgency.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IClientRepository _clientRepository;
    private IRealtorRepository _realtorRepository;
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
}