namespace AirlineCompany.Domain.Models;

public class AirFlightNumberPassangers
{
    public required AirFlight Fly { get; set; }
    public required int NumberPassengers { get; set; }
}
