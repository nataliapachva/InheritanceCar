using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance_car.Interfaces;

namespace Inheritance_car.Classes
{
    public class Truck : Automobile
    {
        public int LoadCapacity { get; set; }

        public Truck(): base() { }
        public Truck(string brand, string model, string color, double maximumSpeed, double powerOfEngine,
                     double capacityOfEngine, int loadCapacity) : base(brand, model, color, maximumSpeed, powerOfEngine, capacityOfEngine)
        {
            LoadCapacity = loadCapacity;
        }

        public override void Input(string str)
        {
            string[] array = str.Split(' ');
            base.Input(array);
            LoadCapacity = Convert.ToInt32(array[6]);
        }

        public override int CompareTo(IAutomobile other)
        {
            return this.PowerOfEngine.CompareTo(other.PowerOfEngine);
        }
        
        public override string ToString()
        {
            string baseProperties = base.ToString();
            return $"{baseProperties}, {LoadCapacity}";
        }
    }
}
