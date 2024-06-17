using VehicleRentalSystem.Contracts;

namespace VehicleRentalSystem.Models
{
    public abstract class Vehicle : IVehicle, ICalculator
    {
        private readonly string brand;
        private readonly string model;
        private readonly decimal vehicleValue;
        private readonly int period;

        protected Vehicle(string brand, string model, decimal vehicleValue, int period)
        {
            this.Brand = brand;
            this.Model = model;
            this.VehicleValue = vehicleValue;
            this.Period = period;
        }

        protected abstract decimal DAILY_INSURANCE_COST { get; }

        protected abstract decimal DAILY_INSURANCE_DISCOUNT { get; }

        protected abstract decimal DAILY_COST_OVER_WEEK { get; }

        protected abstract decimal STANDART_DAILY_COST { get; }

        public string Brand
        {
            get => this.brand;
            init
            {
                if (string.IsNullOrEmpty(value) is true)
                {
                    throw new ArgumentNullException(nameof(this.Brand), "Brand cannot be empty!");
                }

                this.brand = value;
            }
        }

        public string Model
        {
            get => this.model;
            init
            {
                if (string.IsNullOrEmpty(value) is true)
                {
                    throw new ArgumentNullException(nameof(this.Model), "Model cannot be empty!");
                }

                this.model = value;
            }
        }

        public decimal VehicleValue
        {
            get => this.vehicleValue;
            init
            {
                if (value < 0 || value > 1000000m)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.VehicleValue), "Price must be between 0 and 1000000!");
                }

                this.vehicleValue = value;
            }
        }

        public int Period
        {
            get => this.period;
            init
            {
                if (value < 1)
                {
                    throw new ArgumentException(nameof(this.Period), "Period must be at least 1!");
                }

                this.period = value;
            }
        }

        public decimal EarlyReturnDiscount(int elapsedDays)
            => this.CalculateDailyPrice() * 0.5M * (this.Period - elapsedDays);

        public decimal EarlyReturnInsuranceDiscount(int elapsedDays)
            => this.CalculateDailyInsurance(elapsedDays) * (this.period - elapsedDays);

        public virtual decimal CalculatePrice(int elapsedDays)
            => this.CalculateDailyPrice() * elapsedDays + EarlyReturnDiscount(elapsedDays);

        public virtual decimal CalculateDailyPrice()
            => this.Period < 8
            ? STANDART_DAILY_COST
            : DAILY_COST_OVER_WEEK;

        public virtual decimal CalculateDailyInsurance(int elapsedDays)
            => CalculateInitialDailyInsurance(elapsedDays) - (this.HasPriceChange
                                                              ? CalculateDailyInsuranceDiscount(elapsedDays)
                                                              : 0);

        public virtual decimal CalculateInsurance(int elapsedDays)
            => this.CalculateDailyInsurance(elapsedDays) * elapsedDays;

        public virtual decimal CalculateInitialDailyInsurance(int elapsedDays)
            => this.VehicleValue * DAILY_INSURANCE_COST;

        public virtual decimal CalculateDailyInsuranceDiscount(int elapsedDays)
            => this.CalculateInitialDailyInsurance(elapsedDays) * DAILY_INSURANCE_DISCOUNT;

        public abstract bool HasPriceChange { get; }
    }
}
