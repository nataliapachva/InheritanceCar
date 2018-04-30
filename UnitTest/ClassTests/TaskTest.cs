using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inheritance_car.Interfaces;
using Inheritance_car.Classes;


namespace UnitTest.ClassTests
{
    [TestClass]
    public class TaskTest
    {
        private TestContext testContext;

        public TestContext TestContext { get => testContext; set => testContext = value; }

        [TestMethod]
        public void TestFindTheFastest()
        {
           List<IAutomobile> automobiles = new List<IAutomobile>()
           {
               new Truck("Mercedes-Benz", "Mercedes-Benz Actros", "green", 170, 140, 16, 1000),
               new Car("Skoda", "Superb", "grey", 150, 123, 13, 4),
               new SportsCar("BMW", "X6", "red", 200, 110, 20, 12.3),
           };
            Inheritance_car.Task a = new Inheritance_car.Task();
            Assert.IsTrue(a.FindTheFastest(automobiles).Model.Equals("X6", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestFindEconomical()
        {
           List<IAutomobile> automobiles = new List<IAutomobile>()
           {
               new Truck("Mercedes-Benz", "Mercedes-Benz Actros", "green", 170, 140, 16, 1000),
               new Car("Skoda", "Superb", "grey", 150, 123, 13, 4),
               new SportsCar("BMW", "X6", "red", 200, 110, 20, 12.3),
           };
            Inheritance_car.Task a = new Inheritance_car.Task();
            Assert.IsTrue(a.FindEconomical(automobiles,100).Model.Equals("X6", StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void TestParse()
        {
            Inheritance_car.Task a = new Inheritance_car.Task();
            bool first = a.Parse("1 Mercedes-Benz Actros green 170 140 16 1000").Model.Equals("Actros", StringComparison.OrdinalIgnoreCase);
            bool second = false;
            try
            {
                a.Parse("5 Skoda Oktavia green 190 200 18 1000").Model.Equals("Actros", StringComparison.OrdinalIgnoreCase);
            }
            catch(Exception)
            {
                second = true;
            }
            Assert.IsTrue(first&&second);
        }
    }
}
