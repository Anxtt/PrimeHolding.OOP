namespace VehicleRentalSystem.Models
{
    public class Car : Vehicle
    {
        private readonly int safetyRating;

        public Car(string brand, string model, decimal vehicleValue, int period, int safetyRating)
            : base(brand, model, vehicleValue, period)
        {
            this.safetyRating = safetyRating;
        }

        public int SafetyRating
        {
            get => this.safetyRating;
            init
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.SafetyRating));
                }

                this.safetyRating = value;
            }
        }
        public override bool HasPriceChange => this.SafetyRating > 3;

        protected override decimal DAILY_COST_OVER_WEEK => 15M;

        protected override decimal DAILY_INSURANCE_COST => 0.0001M;

        protected override decimal DAILY_INSURANCE_DISCOUNT => 0.1M;

        protected override decimal STANDART_DAILY_COST => 20M;
    }
}
