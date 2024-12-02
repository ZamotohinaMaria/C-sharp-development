using AirlineCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace AirlineCompany.Domain;

public class AirlineCompanyDbContext(DbContextOptions<AirlineCompanyDbContext> options) : DbContext(options)
{
    public DbSet<AirFlight> AirFlights { get; set; }

    public DbSet<Passeneger> Passenegers { get; set; }

    public DbSet<Plane> Planes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AirFlight>().HasData(FileReader.ReadAirFlightsDb("Data/airflyights.csv"));
        modelBuilder.Entity<Plane>().HasData(FileReader.ReadPlanes("Data/planes.csv"));
        modelBuilder.Entity<Passeneger>().HasData(FileReader.ReadPassengers("Data/passengers.csv"));

        modelBuilder.Entity<AirFlight>(entity =>
            {
                entity.HasOne(e => e.Plane)
                        .WithMany()
                        .HasForeignKey(p => p.PlaneId)
                        .OnDelete(DeleteBehavior.Cascade);
            }
        );

        modelBuilder.Entity<Plane>()
            .HasKey(s => s.IdPlane);

        modelBuilder.Entity<Passeneger>()
            .HasKey(s => s.IdPassenger);
    }
}