using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inheritance_car.Classes;

namespace UnitTest.ClassTests
{
    [TestClass]
    public class CarTest
    {
        private TestContext testContext;

        public TestContext TestContext { get => testContext; set => testContext = value; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                 "|DataDirectory|\\CarInputDataTests.csv", "CarInputDataTests#csv", DataAccessMethod.Sequential),
         DeploymentItem("C:\\Users\\Yura\\source\\repos\\Task6\\InheritanceCar\\UnitTest\\TestsData\\CarData"), TestMethod]
        public void TestInput()
        {
            Car a = new Car(TestContext.DataRow["brand"].ToString(),
                TestContext.DataRow["model"].ToString(),
                TestContext.DataRow["color"].ToString(),
                Convert.ToDouble(TestContext.DataRow["maxSpeed"].ToString()),
                Convert.ToDouble(TestContext.DataRow["powerOfEngine"].ToString()),
                Convert.ToDouble(TestContext.DataRow["CapOfEngine"].ToString()),
                Convert.ToInt32(TestContext.DataRow["Passengers"].ToString()));
            Car b = new Car();
            b.Input(TestContext.DataRow["brand"].ToString() + " " +
                TestContext.DataRow["model"].ToString() + " " +
                TestContext.DataRow["color"].ToString() + " " +
                (TestContext.DataRow["maxSpeed"].ToString()) + " " +
                (TestContext.DataRow["powerOfEngine"].ToString()) + " " +
                (TestContext.DataRow["CapOfEngine"].ToString()) + " " +
                (TestContext.DataRow["Passengers"].ToString()));
            b.VIN = a.VIN;
            Assert.IsTrue(a.ToString().Equals(b.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                 "|DataDirectory|\\CarCompareToDataTests.csv", "CarCompareToDataTests#csv", DataAccessMethod.Sequential),
         DeploymentItem("C:\\Users\\Yura\\source\\repos\\Task6\\InheritanceCar\\UnitTest\\TestsData\\CarData"), TestMethod]
        public void TestCopareTo()
        {
            Car a = new Car();
            Car b = new Car();
            a.PowerOfEngine = Convert.ToDouble(TestContext.DataRow["first"].ToString());
            b.PowerOfEngine = Convert.ToDouble(TestContext.DataRow["second"].ToString());
            Assert.AreEqual(a.CompareTo(b), Convert.ToInt32(TestContext.DataRow["result"].ToString()));
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                 "|DataDirectory|\\GetVolumeOfFuelDataTests.csv", "GetVolumeOfFuelDataTests#csv", DataAccessMethod.Sequential),
         DeploymentItem("C:\\Users\\Yura\\source\\repos\\Task6\\InheritanceCar\\UnitTest\\TestsData\\CarData"), TestMethod]
        public void TestGetVolumeOfFuel()
        {
            Car b = new Car();
            b.Input(TestContext.DataRow["brand"].ToString() + " " +
                TestContext.DataRow["model"].ToString() + " " +
                TestContext.DataRow["color"].ToString() + " " +
                (TestContext.DataRow["maxSpeed"].ToString()) + " " +
                (TestContext.DataRow["powerOfEngine"].ToString()) + " " +
                (TestContext.DataRow["CapOfEngine"].ToString()) + " " +
                (TestContext.DataRow["Passengers"].ToString()));
            string a = Convert.ToString(b.GetVolumeOfFuel(100));
            Assert.IsTrue(a.Equals((TestContext.DataRow["output"].ToString()), StringComparison.OrdinalIgnoreCase));
        }

    }
}
