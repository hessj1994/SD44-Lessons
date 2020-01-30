using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Classes
{
    public enum VehicleType { Car, Truck, Plane, Boat, Bike, Spaceship, Train }

    public class Vehicle
    {
        public Vehicle()
        {
            BodyColor = "Magenta";
        }

        public Vehicle(string make, string model, double mileage, string bodyColor, VehicleType type)
        {
            Make = make;
            Model = model;
            Mileage = mileage;
            BodyColor = bodyColor;
            TypeOfVehicle = type;
        }

        public string BodyColor { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Mileage { get; set; }

        public VehicleType TypeOfVehicle { get; set; }
    }
}
