using RealtyAgency.Core.Repositories.Client;
using RealtyAgency.Core.Repositories.Realtor;

namespace RealtyAgency.Core.Repositories;

public interface IUnitOfWork
{
    IClientRepository ClientRepository { get; }
    IRealtorRepository RealtorRepository { get; }
    Task CommitAsync();
}