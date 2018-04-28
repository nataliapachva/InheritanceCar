using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance_car.Classes;
using Inheritance_car.Interfaces;

namespace Inheritance_car
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task= new Task();
            List <IAutomobile> automobiles = task.InpuList();
           
            Console.WriteLine("Sorted list by power of engine: ");
            task.SortListByPowerOfEngine(automobiles);
            for (int i = 0; i < automobiles.Count; i++)
            {
                Console.WriteLine(automobiles[i].ToString());
            }

            Console.WriteLine("The fastest car: ");
            Console.WriteLine(task.FindTheFastest(automobiles));

            Console.WriteLine("The most economical car: ");
            Console.WriteLine(task.FindEconomical(automobiles, 100));

            Console.ReadKey();
        }
    }
}
