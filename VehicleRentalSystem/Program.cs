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
                IVehicle car = new Car("Mitsubishi", "Mirage", 15000, 10, safetyRating: 3);
                //IVehicle safeCar = new Car("Mitsubishi", "Lancer", 15000, 10, 5);

                //IVehicle motorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, age: 20);
                //IVehicle safeMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, 25);

                //IVehicle cargoVan = new CargoVan("Citroen", "Jumper", 20000, 15, 4);
                //IVehicle safeCargoVan = new CargoVan("Citroen", "Jumper", vehicleValue: 20000, period: 15, experience: 8);

                Invoice<IVehicle> invoice = new("San", "Dokan", DateTime.Now, DateTime.Now.AddDays(10), car);

                Console.WriteLine(invoice.ToString());

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///Early return

                //IVehicle earlyCar = new Car("Mitsubishi", "Mirage", 15000, 10, 3);
                //IVehicle earlySafeCar = new Car("Mitsubishi", "Lancer", 15000, 10, 5);

                //IVehicle earlyMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, 20);
                //IVehicle earlySafeMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10, 25);

                //IVehicle earlyCargoVan = new CargoVan("Citroen", "Jumper", 20000, 15, 4);
                //IVehicle earlySafeCargoVan = new CargoVan("Citroen", "Jumper", 20000, 15, 8);

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                ///Faulty Data

                //IVehicle faultyCar = new Car("", "", 1000000m + 1, 0, 0);
                //IVehicle secondFaultyCar = new Car("A", "B", -1, 0, 6);
                //IVehicle testCar = new Car("Mitsubishi", "Mirage", 15000, 1, 1);

                //IVehicle faultyMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, 17);
                //IVehicle secondFaultySafeMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, 101);
                //IVehicle testMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, 18);
                //IVehicle secondTestMotorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000, 10, 100);

                //IVehicle testCargoVan = new CargoVan("Citroen", "Jumper", 20000, 15, 0);
                //IVehicle faultyCargoVan = new CargoVan("Citroen", "Jumper", 20000, 15, -1);
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
