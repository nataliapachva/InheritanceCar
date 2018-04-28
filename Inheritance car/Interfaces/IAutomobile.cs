using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_car.Interfaces
{
    public interface IAutomobile : IComparable<IAutomobile>
    {
        string Brand { get; set; }
        string Model { get; set; }
        string Color { get; set; }
        string VIN { get;  set; }
        double MaximumSpeed { get; set; }
        double PowerOfEngine { get; set; }
        double CapacityOfEngine { get; set; }

        double GetVolumeOfFuel(double averageSpeed);
        void Input(string str);
    }
}
