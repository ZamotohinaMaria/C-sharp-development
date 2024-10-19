namespace AirlineCompany.ApplicationServices.DTO;

/// <summary>
/// Класс описывает данные формы для создания объекта класса Пассажиры
/// </summary>
public class PassengerDto
{
    /// <summary>
    /// ФИО пассажира
    /// </summary>
    public required string FullName { get; set; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    public required string Passport { get; set; }

    /// <summary>
    /// Флаг регистрации
    /// </summary>
    public required bool Registration { get; set; }

    /// <summary>
    /// Номер билета
    /// </summary>
    public required string TicketNumber { get; set; }

    /// <summary>
    /// Номер места
    /// </summary>
    public required string SeatNumber { get; set; }

    /// <summary>
    /// Вес багажа
    /// </summary>
    public required double BaggageWeight { get; set; }

    /// <summary>
    /// Номер рейса
    /// </summary>
    public required int IdFlight { get; set; }
}
