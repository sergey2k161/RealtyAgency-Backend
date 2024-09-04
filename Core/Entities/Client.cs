using RealtyAgency.Core.Entities.Auth;

namespace RealtyAgency.Core.Entities;
/// <summary>
/// Клиент, пользователь, который будет платить шейкели за просто так :)
/// </summary>
public class Client
{
    public int Id { get; set; }
    public int CommonUserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhotoPath { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public int Rating { get; set; }
    public CommonUser CommonUser { get; set; }
    public DateTime BirthDate { get; set; }
}