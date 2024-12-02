using AirlineCompany.Domain.Models;
using AirlineCompany.Domain;

namespace AirlineCompany.Tests;
/// <summary>
/// Класс предоставляет доступ к тестовым данным
/// </summary>
public class AirlineCompanyFixture
{
    public List<AirFlight> AirFlights;
    public List<Passeneger> Passengers;
    public List<Plane> Planes;

    public AirlineCompanyFixture()
    {
        AirFlights = FileReader.ReadAirFlights("Data/airflyights.csv");

        Passengers = FileReader.ReadPassengers("Data/passengers.csv");

        Planes = FileReader.ReadPlanes("Data/planes.csv");
    }
}
