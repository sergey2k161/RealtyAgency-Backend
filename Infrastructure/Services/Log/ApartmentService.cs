using Microsoft.EntityFrameworkCore;
using RealtyAgency.Core.Entities.Log;
using RealtyAgency.Core.Repositories.DTO;
using RealtyAgency.Core.Repositories.Interfaces.ApartmentRepository;
using RealtyAgency.Persistence;

namespace RealtyAgency.Infrastructure.Services.Log;

public class ApartmentService : IApartmentService
{
    private readonly ApplicationDbContext _context;

    public ApartmentService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Apartment> CreateApartmentAsync(CreateApartmentDTO model)
    {
        var apartment = new Apartment
        {
            Title = model.Title,
            Description = model.Description,
            Price = model.Price,
            Address = model.Address
        };

        _context.Apartments.Add(apartment);

        await _context.SaveChangesAsync();
        return apartment;
    }

    public async Task<List<Apartment>> GetAllApartmentsAsync()
    {
        var apartments = await _context.Apartments.ToListAsync();
        return apartments;
    }

    public async Task<Apartment> GetApartmentByIdAsync(int apartmentId)
    {
        var apartment = await _context.Apartments.FirstOrDefaultAsync(a => a.Id == apartmentId) ?? throw new Exception("Apartment not found");
        return apartment;
    }
    
    public async Task<Apartment> DeleteApartmentAsync(int apartmentId)
    {
        var apartment = await _context.Apartments.FirstOrDefaultAsync(a => a.Id == apartmentId) ?? throw new Exception("Apartment not found");
        _context.Apartments.Remove(apartment);
        await _context.SaveChangesAsync();
        return apartment;
    }
}