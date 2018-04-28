using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_car.Classes
{
    public class Converter
    {
        public const double wattToHp = 745.699872;
        public const double benzinHeatOfCombustion = 45000000;
        public const double ece = 0.35;
        public const int metersInKilometer = 1000;
        public const int secondsInHour = 3600;

        public double KilometersPerHourToMetersPerSecond(double kilometersPerHour)
        {
            return (kilometersPerHour * metersInKilometer) / secondsInHour;
        }

        public double KilometersToMeters(double kilometers)
        {
            return kilometers * metersInKilometer;
        }

        public double HpsToWatt(double hps)
        {
            return hps * wattToHp;
        }
    }
}
