using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompany.Domain.Models;
/// <summary>
/// Класс описывает информацию о пассажире
/// </summary>
[Table("passengers")]
public class Passeneger
{
    /// <summary>
    ///  ID ассажира
    /// </summary>
    [Key]
    [Column("id_passenger")]
    public required int IdPassenger { get; set; }

    /// <summary>
    /// ФИО пассажира
    /// </summary>
    [Column("fullname")]
    [Required]

    public required string FullName { get; set; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    [Column("passport")]
    [Required]

    public required string Passport { get; set; }

    /// <summary>
    /// Флаг регистрации
    /// </summary>
    [Column("registration")]
    [Required]

    public required bool Registration { get; set; }

    /// <summary>
    /// Номер билета
    /// </summary>
    [Column("ticket_number")]
    [Required]

    public required string TicketNumber { get; set; }

    /// <summary>
    /// Номер места
    /// </summary>
    [Column("seat_number")]
    [Required]

    public required string SeatNumber { get; set; }

    /// <summary>
    /// Вес багажа
    /// </summary>
    [Column("baggage_weight")]
    [Required]

    public required double BaggageWeight { get; set; }

    /// <summary>
    /// Номер рейса
    /// </summary>
    [Column("id_flight")]
    [Required]

    public required int IdFlight { get; set; }
}

