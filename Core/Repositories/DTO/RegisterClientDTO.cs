namespace RealtyAgency.Core.Repositories.DTO;

public class RegisterClientDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
}