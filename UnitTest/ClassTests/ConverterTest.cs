using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inheritance_car.Classes;

namespace UnitTest.ClassTests
{
    [TestClass]
    public class ConverterTest
    {
        private TestContext testContext;

        public TestContext TestContext { get => testContext; set => testContext = value; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                 "|DataDirectory|\\KmToMetersDataTests.csv", "KmToMetersDataTests#csv", DataAccessMethod.Sequential),
         DeploymentItem("TestsData\\ConverterData"), TestMethod]
        public void TestKmToM()
        {
            Converter tmp = new Converter();
            Assert.AreEqual(tmp.KilometersToMeters(Convert.ToDouble(TestContext.DataRow["km"].ToString())), Convert.ToDouble(TestContext.DataRow["m"].ToString()));
        }
       
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                 "|DataDirectory|\\KPerHToMetPerSecDataTests.csv", "KPerHToMetPerSecDataTests#csv", DataAccessMethod.Sequential),
         DeploymentItem("TestsData\\ConverterData"), TestMethod]
        public void TestKilometersPerHourToMetersPerSecond()
        {
            Converter tmp = new Converter();
            Assert.AreEqual(tmp.KilometersPerHourToMetersPerSecond(Convert.ToDouble(TestContext.DataRow["input"].ToString())), Convert.ToDouble(TestContext.DataRow["output"].ToString()));
        }
        
           [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                 "|DataDirectory|\\HpsToWattDataTests.csv", "HpsToWattDataTests#csv", DataAccessMethod.Sequential),
         DeploymentItem("TestsData\\ConverterData"), TestMethod]
        public void TestHpsToWatt()
        {
            Converter tmp = new Converter();
            string a= Convert.ToString(tmp.HpsToWatt(Convert.ToDouble(TestContext.DataRow["input"].ToString())));
            Assert.IsTrue(a.Equals((TestContext.DataRow["output"].ToString()),StringComparison.OrdinalIgnoreCase));
        }
    }
}