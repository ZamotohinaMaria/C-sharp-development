using AirlineCompany.Domain.Models;

namespace AirlineCompany.ApplicationServices.DTO;

/// <summary>
/// Класс пар (полет - значение)
/// </summary>
public class AirFlightNumberPassangers
{
    public required AirFlight Fly { get; set; }
    public required int NumberPassengers { get; set; }
}
