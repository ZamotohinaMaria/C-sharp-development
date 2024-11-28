using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompany.Domain.Models;
/// <summary>
/// Класс описывает одну модель самолета
/// </summary>
[Table("planes")]
public class Plane
{
    /// <summary>
    /// ID самолета
    /// </summary>
    [Key]
    [Column("id_plane")]
    public required int IdPlane { get; set; }

    /// <summary>
    /// Модель
    /// </summary>
    [Column("model")]
    [Required]
    public required string Model { set; get; }

    /// <summary>
    /// Грузоподъемность
    /// </summary>
    [Column("load_capacity")]
    [Required]
    public required double LoadCapacity { set; get; }

    /// <summary>
    /// Производительность
    /// </summary>
    [Column("efficiency")]
    [Required]
    public required double Efficiency { set; get; }

    /// <summary>
    /// Максимальное число пассажиров
    /// </summary>
    [Column("passenger_max")]
    [Required]
    public required int PassengerMax { set; get; }
}

