using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance_car.Interfaces;

namespace Inheritance_car.Classes
{
    public class SportsCar : Automobile
    {
        public double CoefficientAerodynamicResistance { get; set; }

        public SportsCar() : base() { }
        public SportsCar(string brand, string model, string color, double maximumSpeed, double powerOfEngine,
            double capacityOfEngine, double coefficientAerodynamicResistance) : base(brand, model, color, maximumSpeed, powerOfEngine, capacityOfEngine)
        {
            CoefficientAerodynamicResistance = coefficientAerodynamicResistance;
        }

        public override void Input(string str)
        {
            string[] array = str.Split(' ');
            base.Input(array);
            CoefficientAerodynamicResistance = Convert.ToDouble(array[6]);
        }
        
        public override int CompareTo(IAutomobile other)
        {
            return this.PowerOfEngine.CompareTo(other.PowerOfEngine);
        }

        public override string ToString()
        {
            string baseProperties = base.ToString();
            return $"{baseProperties}, {CoefficientAerodynamicResistance}";
        }
    }
}

