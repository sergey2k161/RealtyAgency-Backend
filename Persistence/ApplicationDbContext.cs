using Microsoft.AspNetCore.Identity;
using RealtyAgency.Core.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealtyAgency.Core.Entities;
using RealtyAgency.Core.Entities.Log;


namespace RealtyAgency.Persistence;

public class ApplicationDbContext : IdentityDbContext<CommonUser, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    public DbSet<Client> Clients { get; set; }
    public DbSet<Realtor> Realtors { get; set; }
    public DbSet<Apartment> Apartments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>()  
            .HasOne(c => c.CommonUser)
            .WithMany()
            .HasForeignKey(c => c.CommonUserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Realtor>()
            .HasOne(r => r.CommonUser)
            .WithMany()
            .HasForeignKey(r => r.CommonUserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
