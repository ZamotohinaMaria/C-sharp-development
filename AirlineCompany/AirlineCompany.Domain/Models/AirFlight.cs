using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompany.Domain.Models;
/// <summary>
/// Класс описывает 1 полет какого-либо самолета
/// </summary>
[Table("airflights")]
public class AirFlight
{
    /// <summary>
    /// ID полета
    /// </summary>
    [Key]
    [Column("id_flight")]

	public required int IdFlight { get; set; }

    /// <summary>
    /// Кодовый номер рейса
    /// </summary>
    [Column("code_number")]
    [Required]

    public required string CodeNumber { get; set; }

    /// <summary>
    /// Пункт отправления
    /// </summary>
    [Column("departure_point")]
    [Required]

    public required string DeparturePoint { get; set; }

    /// <summary>
    /// Пункт прибытия
    /// </summary>
    [Column("arrival_point")]
    [Required]

    public required string ArrivalPoint { get; set; }

    /// <summary>
    /// Дата и время отправления
    /// </summary>
    [Column("departure")]
    [Required]

    public required DateTime Departure { get; set; }

    /// <summary>
    /// Дата и время прибытия
    /// </summary>
    [Column("arrive")]
    [Required]

    public required DateTime Arrive { get; set; }

    /// <summary>
    /// Время в пути в часах и минутах
    /// </summary>
    [Column("flying_time")]
    [Required]
    public required TimeOnly FlyingTime { get; set; }

    /// <summary>
    /// Тип самолета
    /// </summary>
    [Column("id_plane")]
    [Required]
    public required int PlaneId { get; set; }
    public Plane? Plane { get; set; }
}

