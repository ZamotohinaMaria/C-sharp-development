namespace AirlineCompany.ApplicationServices.DTO;
public class PlaneDto
{
    /// <summary>
    /// Модель
    /// </summary>
    public required string Model { set; get; }

    /// <summary>
    /// Грузоподъемность
    /// </summary>
    public required double LoadCapacity { set; get; }

    /// <summary>
    /// Производительность
    /// </summary>
    public required double Efficiency { set; get; }

    /// <summary>
    /// Максимальное число пассажиров
    /// </summary>
    public required int PassengerMax { set; get; }
}
