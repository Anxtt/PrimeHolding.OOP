namespace VehicleRentalSystem.Contracts
{
    public interface ICalculator
    {
        decimal CalculateDailyInsurance(int elapsedDays);

        decimal CalculateDailyInsuranceDiscount(int elapsedDays);

        decimal CalculateDailyPrice();

        decimal CalculateInitialDailyInsurance(int elapsedDays);

        decimal CalculateInsurance(int elapsedDays);

        decimal CalculatePrice(int elapsedDays);

        decimal EarlyReturnDiscount(int elapsedDays);

        decimal EarlyReturnInsuranceDiscount(int elapsedDays);
    }
}
