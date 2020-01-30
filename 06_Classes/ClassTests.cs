using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_Classes
{
    [TestClass]
    public class ClassTests
    {
        [TestMethod]
        public void VehiclePropertyTests()
        {
            Vehicle airplane = new Vehicle();
            airplane.BodyColor = "Hot Pink";
            airplane.Make = "Boeing";
            airplane.Model = "737 Max";
            airplane.Mileage = 0.1;

            Console.WriteLine("{0} {1}", airplane.Make, airplane.Model);
            Console.WriteLine(airplane.Make + " " + airplane.Model);

            airplane.TypeOfVehicle = VehicleType.Plane;

            Vehicle myCar = new Vehicle();
            myCar.BodyColor = "Silver";
            myCar.Make = "Honda";
            myCar.Model = "Civic";
            myCar.Mileage = 35000.01;
            myCar.TypeOfVehicle = VehicleType.Car;

            Vehicle anotherCar = new Vehicle("Toyota", "Corolla", 350000, "Maroon", VehicleType.Car);
            Console.WriteLine($"{anotherCar.Make} {anotherCar.Model}");
        }
    }
}
