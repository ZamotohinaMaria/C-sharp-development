namespace AirlineCompany.ApplicationServices.DTO;
public class AirFlightDto
{
    /// <summary>
    /// Кодовый номер рейса
    /// </summary>
    public required string CodeNumber { get; set; }

    /// <summary>
    /// Пункт отправления
    /// </summary>
    public required string DeparturePoint { get; set; }

    /// <summary>
    /// Пункт прибытия
    /// </summary>
    public required string ArrivalPoint { get; set; }

    /// <summary>
    /// Дата и время отправления
    /// </summary>
    public required DateTime Departure { get; set; }

    /// <summary>
    /// Дата и время прибытия
    /// </summary>
    public required DateTime Arrive { get; set; }

    /// <summary>
    /// Тип самолета
    /// </summary>
    public required int PlaneId { get; set; }
}
