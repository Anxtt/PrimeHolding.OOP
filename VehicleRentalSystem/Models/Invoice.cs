using System.Text;
using VehicleRentalSystem.Contracts;

namespace VehicleRentalSystem.Models
{
    public class Invoice<TVehicle> : IInvoice<TVehicle>
        where TVehicle : Vehicle, IVehicle
    {
        private readonly int elapsedDays;

        private readonly string firstName;
        private readonly string lastName;
        private readonly DateTime startDate;
        private readonly DateTime endDate;
        private readonly TVehicle vehicle;

        public Invoice(string firstName, string lastName, DateTime startDate, DateTime endDate, TVehicle vehicle)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Vehicle = vehicle;

            this.elapsedDays = (this.EndDate - this.StartDate).Days;
        }

        public string FirstName
        {
            get => this.firstName;
            init
            {
                if (string.IsNullOrEmpty(value) is true)
                {
                    throw new ArgumentNullException(nameof(this.FirstName));
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            init
            {
                if (string.IsNullOrEmpty(value) is true)
                {
                    throw new ArgumentNullException(nameof(this.LastName));
                }

                this.lastName = value;
            }
        }

        public DateTime StartDate
        {
            get => this.startDate;
            init
            {
                this.startDate = value;
            }
        }

        public DateTime EndDate
        {
            get => this.endDate;
            init
            {
                this.endDate = value;
            }
        }
        public TVehicle Vehicle
        {
            get => this.vehicle;
            init
            {
                this.vehicle = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("XXXXXXXXXX")
              .AppendLine($"Date: {DateTime.Now.ToString("yyyy-dd-MM")}")
              .AppendLine($"Customer Name: {this.FirstName} {this.LastName}")
              .AppendLine($"Rented Vehicle: {this.Vehicle.Brand} {this.Vehicle.Model}")
              .AppendLine()
              .AppendLine($"Reservation Start Date: {this.StartDate.ToString("yyyy-dd-MM")}")
              .AppendLine($"Reservation End Date: {this.StartDate.AddDays(this.Vehicle.Period).ToString("yyyy-dd-MM")}")
              .AppendLine($"Reserved Rental Days: {this.Vehicle.Period} days")
              .AppendLine();

            AdjustActualReturnDate(sb);

            sb.AppendLine($"Rental Cost per Day: ${this.Vehicle.CalculateDailyPrice().ToString("f2")}");

            if (this.Vehicle.HasPriceChange)
            {
                sb.AppendLine($"Initial Insurance per Day: ${this.Vehicle.CalculateInitialDailyInsurance(this.elapsedDays).ToString("f2")}")
                  .AppendLine($"Insurance {(this.Vehicle is Motorcycle ? "addition" : "discount")} per Day: ${this.Vehicle.CalculateDailyInsuranceDiscount(this.elapsedDays).ToString("f2")}");
            }
            sb.AppendLine($"Insurance per Day: ${this.Vehicle.CalculateDailyInsurance(this.elapsedDays).ToString("f2")}")
              .AppendLine();

            if (this.Vehicle.Period > this.elapsedDays)
            {
                sb.AppendLine($"Early return discount for rent: {this.Vehicle.EarlyReturnDiscount(this.elapsedDays).ToString("f2")}$")
                  .AppendLine($"Early return discount for insurance: {this.Vehicle.EarlyReturnInsuranceDiscount(this.elapsedDays).ToString("f2")}$")
                  .AppendLine();
            }            

            sb.AppendLine($"Total Rent: ${this.Vehicle.CalculatePrice(this.elapsedDays).ToString("f2")}")
              .AppendLine($"Total Insurance: ${this.Vehicle.CalculateInsurance(this.elapsedDays).ToString("f2")}")
              .AppendLine($"Total: ${(this.Vehicle.CalculatePrice(this.elapsedDays) + this.Vehicle.CalculateInsurance(this.elapsedDays)).ToString("f2")}")
              .AppendLine("XXXXXXXXXX");

            return sb.ToString();
        }

        private void AdjustActualReturnDate(StringBuilder sb)
        {
            if (this.elapsedDays != this.Vehicle.Period)
            {
                sb.AppendLine($"Actual Return Date: {this.StartDate.AddDays(this.elapsedDays).Date.ToString("yyyy-dd-MM")}")
                  .AppendLine($"Actual Rental Date: {this.elapsedDays} days")
                  .AppendLine();
            }
            else
            {
                sb.AppendLine($"Actual Return Date: {this.EndDate.ToString("yyyy-dd-MM")}")
                  .AppendLine($"Actual Rental Date: {this.Vehicle.Period} days")
                  .AppendLine();
            }
        }
    }
}
