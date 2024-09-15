namespace RealtyAgency.Core.Entities.Log;

public class Apartment
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Address { get; set; }
    public string? ImageUrl { get; set; }
    public int? RealtorId { get; set; }
    
}