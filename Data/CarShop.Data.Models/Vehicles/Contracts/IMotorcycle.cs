namespace CarShop.Data.Models.Vehicles
{
    public interface IMotorcycle
    {
        TypeOfCooling TypeOfCooling { get; set; }

        int CubicMeter { get; set; }

        int TactsOfEngine { get; set; }
    }
}
