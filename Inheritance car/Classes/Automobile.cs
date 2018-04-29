using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance_car.Interfaces;

namespace Inheritance_car.Classes
{
    public abstract class Automobile : IAutomobile
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string VIN { get; set; }
        public double MaximumSpeed { get; set; }
        public double PowerOfEngine { get; set; }
        public double CapacityOfEngine { get; set; }

        public Automobile() { }

        public Automobile(string brand, string model, string color, double maximumSpeed, double powerOfEngine, double capacityOfEngine)
        {
            Brand = brand;
            Model = model;
            Color = color;
            VIN = Guid.NewGuid().ToString();
            MaximumSpeed = maximumSpeed;
            PowerOfEngine = powerOfEngine;
            CapacityOfEngine = capacityOfEngine;
        }

        public double GetVolumeOfFuel(double averageSpeed)
        {
            Converter сonverter = new Converter();
            double watts = сonverter.HpsToWatt(PowerOfEngine);
            double distance = сonverter.KilometersToMeters(100);
            double speed = сonverter.KilometersPerHourToMetersPerSecond(averageSpeed);
            double ece = Converter.ece;
            double result = watts * distance / (speed * ece * Converter.benzinHeatOfCombustion);

            return result;
        }

        public abstract void Input(string str);

        public abstract int CompareTo(IAutomobile other);

        public override string ToString()
        {
            return $"{Brand}, {Model}, {Color}, {VIN}, {MaximumSpeed}, {PowerOfEngine}, {CapacityOfEngine}";
        }

        protected void Input(string[] array)
        {
            Brand = array[0];
            Model = array[1];
            Color = array[2];
            MaximumSpeed = Convert.ToDouble(array[3]);
            PowerOfEngine = Convert.ToDouble(array[4]);
            CapacityOfEngine = Convert.ToDouble(array[5]);
        }
    }
}
