using VehicleRentalSystem.Contracts;
using VehicleRentalSystem.Models;

namespace VehicleRentalSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Vehicle car = new Car("Mitsubishi", "Mirage", 15000, 10, safetyRating: 3);
                Vehicle safeCar = new Car("Mitsubishi", "Lancer", 15000, 10, 5);

                Vehicle motorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, age: 20);
                Vehicle safeMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, 25);

                Vehicle cargoVan = new CargoVan("Citroen", "Jumper", 20000, 15, 4);
                Vehicle safeCargoVan = new CargoVan("Citroen", "Jumper", vehicleValue: 20000, period: 15, experience: 8);

                Invoice<Vehicle> invoice = new("San", "Dokan", DateTime.Now, DateTime.Now.AddDays(10), safeCargoVan);

                Console.WriteLine(invoice.ToString());

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///Early return

                //Vehicle earlyCar = new Car("Mitsubishi", "Mirage", 15000, 10, 3);
                //Vehicle earlySafeCar = new Car("Mitsubishi", "Lancer", 15000, 10, 5);

                //Vehicle earlyMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, 20);
                //Vehicle earlySafeMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10, 25);

                //Vehicle earlyCargoVan = new CargoVan("Citroen", "Jumper", 20000, 15, 4);
                //Vehicle earlySafeCargoVan = new CargoVan("Citroen", "Jumper", 20000, 15, 8);

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///Faulty Data

                //Vehicle faultyCar = new Car("", "", 1000000m + 1, 0, 0);
                //Vehicle secondFaultyCar = new Car("A", "B", -1, 0, 6);
                //Vehicle testCar = new Car("Mitsubishi", "Mirage", 15000, 1, 1);

                //Vehicle faultyMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, 17);
                //Vehicle secondFaultySafeMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, 101);
                //Vehicle testMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, 18);
                //Vehicle secondTestMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, 100);

                //Vehicle testCargoVan = new CargoVan("Citroen", "Jumper", 20000, 15, 0);
                //Vehicle faultyCargoVan = new CargoVan("Citroen", "Jumper", 20000, 15, -1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
