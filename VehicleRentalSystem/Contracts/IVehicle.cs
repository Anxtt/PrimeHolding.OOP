namespace VehicleRentalSystem.Contracts
{
    public interface IVehicle
    {
        string Brand { get; }

        string Model { get; }

        decimal VehicleValue { get; }

        int Period { get; }

        bool HasPriceChange { get; }
    }
}
