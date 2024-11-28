using AirlineCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineCompany.Domain;

public class AirlineCompanyDbContext(DbContextOptions<AirlineCompanyDbContext> options): DbContext(options)
{
    public DbSet<AirFlight> AirFlights { get; set; }

    public DbSet<Passeneger> Passenegers { get; set; }

    public DbSet<Plane> Planes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<AirFlight>(entity =>
        {
            entity.HasOne(e => e.Plane)
                    .WithMany()
                    .HasForeignKey(p => p.PlaneId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
            );
    }
}
