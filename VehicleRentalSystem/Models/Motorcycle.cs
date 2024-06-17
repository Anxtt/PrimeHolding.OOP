namespace VehicleRentalSystem.Models
{
    public class Motorcycle : Vehicle
    {
        private readonly int age;

        public Motorcycle(string brand, string model, decimal vehicleValue, int period, int age)
            : base(brand, model, vehicleValue, period)
        {
            this.Age = age;
        }

        public int Age
        {
            get => this.age;
            init
            {
                if (value < 18 || value > 100)
                {
                    throw new ArgumentException(nameof(this.Age));
                }

                this.age = value;
            }
        }

        public override bool HasPriceChange => this.Age < 25;

        protected override decimal DAILY_COST_OVER_WEEK => 10M;

        protected override decimal DAILY_INSURANCE_COST => 0.0002M;

        protected override decimal DAILY_INSURANCE_DISCOUNT => 0.2M;

        protected override decimal STANDART_DAILY_COST => 15M;

        public override decimal CalculateDailyInsurance(int elapsedDays)
            => CalculateInitialDailyInsurance(elapsedDays) + CalculateDailyInsuranceDiscount(elapsedDays);
    }
}
