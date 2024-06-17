namespace VehicleRentalSystem.Models
{
    public class CargoVan : Vehicle
    {        
        private readonly int experience;

        public CargoVan(string brand, string model, decimal vehicleValue, int period, int experience)
            : base(brand, model, vehicleValue, period)
        {
            this.Experience = experience;
        }

        public int Experience
        {
            get => this.experience;
            init
            {
                if (value < 0)
                {
                    throw new ArgumentException(nameof(this.Experience));
                }

                this.experience = value;
            }
        }

        public override bool HasPriceChange => this.Experience > 5;

        protected override decimal DAILY_COST_OVER_WEEK => 40M;

        protected override decimal DAILY_INSURANCE_COST => 0.0003M;

        protected override decimal DAILY_INSURANCE_DISCOUNT => 0.15M;

        protected override decimal STANDART_DAILY_COST => 50M;
    }
}
