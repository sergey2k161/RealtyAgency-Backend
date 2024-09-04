using RealtyAgency.Core.Entities.Auth;

namespace RealtyAgency.Core.Entities;
/// <summary>
/// Риэлтор, пользователь, который будет брать шейкели за просто так :)
/// </summary>
public class Realtor
{
    public int Id { get; set; }
    public int CommonUserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhotoPath { get; set; }
    public string? Description { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public int Rating { get; set; }
    public int TransactionsCount { get; set; }
    public CommonUser CommonUser { get; set; }
}