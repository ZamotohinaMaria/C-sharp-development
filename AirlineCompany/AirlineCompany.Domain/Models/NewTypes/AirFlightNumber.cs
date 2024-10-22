namespace AirlineCompany.Domain.Models;

/// <summary>
/// Класс пар (полет - значение)
/// </summary>
public class AirFlightNumberPassangers
{
    public required AirFlight Fly { get; set; }
    public required int NumberPassengers { get; set; }
}
