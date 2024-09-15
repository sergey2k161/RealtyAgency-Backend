using RealtyAgency.Core.Entities.Log;
using RealtyAgency.Core.Repositories.DTO;

namespace RealtyAgency.Core.Repositories.Interfaces.ApartmentRepository;

public interface IApartmentService
{
    Task<Apartment> CreateApartmentAsync(CreateApartmentDTO model);
    //Task<Apartment> UpdateApartmentAsync(UpdateApartmentDTO model);
    Task<Apartment> DeleteApartmentAsync(int apartmentId);
    Task<Apartment> GetApartmentByIdAsync(int apartmentId);
    Task<List<Apartment>> GetAllApartmentsAsync();
    
}