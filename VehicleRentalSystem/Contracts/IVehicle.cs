namespace VehicleRentalSystem.Contracts
{
    public interface IVehicle
    {
        string Brand { get; }

        string Model { get; }

        decimal VehicleValue { get; }

        int Period { get; }

        decimal CalculateDailyInsurance(int elapsedDays);

        decimal CalculateDailyInsuranceDiscount(int elapsedDays);

        decimal CalculateDailyPrice();

        decimal CalculateInitialDailyInsurance(int elapsedDays);

        decimal CalculateInsurance(int elapsedDays);

        decimal CalculatePrice(int elapsedDays);

        decimal EarlyReturnDiscount(int elapsedDays);

        decimal EarlyReturnInsuranceDiscount(int elapsedDays);

        bool HasPriceChange { get; }
    }
}
