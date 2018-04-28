using Inheritance_car.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance_car.Classes;

namespace Inheritance_car
{
    public class Task
    {
        public void ShowHead()
        {
            Console.WriteLine("Enter type of car(1-car, 2-sports car, 3-truck), brand, model, color," +
                              " maximum speed, power of engine, capacity of engine," +
                              " special property(car: int countOfPassengers, sports car: double coefficient aerodynamic resistance, truck: int load capacity)");
            Console.WriteLine("For example: 2 BMW X6 black 250 245 3 1,2");
        }

        public IAutomobile Parse(string str)
        {
            string[] array = str.Split(new[] { ' ' }, 2);
            IAutomobile automobile;
            if (Convert.ToInt32(array[0]) == 1)
            {
                automobile = new Car();
            }
            else if (Convert.ToInt32(array[0]) == 2)
            {
                automobile = new SportsCar();
            }
            else if (Convert.ToInt32(array[0]) == 3)
            {
                automobile = new Truck();
            }
            else
            {
                throw new Exception("Invalid data");
            }
            automobile.Input(array[1]);

            return automobile;
        }

        public List<IAutomobile> InpuList()
        {
            List<IAutomobile> automobiles = new List<IAutomobile>();
            List<IAutomobile> baseAutomobiles = GetBaseAutomobiles();
            automobiles.AddRange(baseAutomobiles);
            Console.WriteLine("Enter size of cars(there is a basic list of machines, if you do not want to add to the list " +
                              "enter the size of the cars 0): ");
            string str = Console.ReadLine();
            int count = Convert.ToInt32(str);
            if (count != 0)
            {
                ShowHead();
                for (int i = 0; i < count; i++)
                {
                    string line = Console.ReadLine();
                    IAutomobile car = Parse(line);
                    automobiles.Add(car);
                }
            }

            return automobiles;
        }

        public IAutomobile FindTheFastest(List<IAutomobile> automobiles)
        {
            IAutomobile automobile = automobiles.OrderBy(c => c.MaximumSpeed).Last();

            return automobile;
        }

        public void SortListByPowerOfEngine(List<IAutomobile> automobiles)
        {
            automobiles.Sort();
        }

        public IAutomobile FindEconomical(List<IAutomobile> automobiles, double averageSpeed)
        {
            IAutomobile automobile = automobiles.OrderBy(c => c.GetVolumeOfFuel(averageSpeed)).First();

            return automobile;
        }

        private List<IAutomobile> GetBaseAutomobiles()
        {
            List<IAutomobile> automobiles = new List<IAutomobile>()
           {
               new Truck("Mercedes-Benz", "Mercedes-Benz Actros", "green", 170, 140, 16, 1000),
               new Car("Skoda", "Superb", "grey", 150, 123, 13, 4),
               new SportsCar("BMW", "X6", "red", 200, 110, 20, 12.3),
           };

            return automobiles;
        }

    }
}
