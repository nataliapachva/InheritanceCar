﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inheritance_car.Classes;

namespace UnitTest.ClassTests
{
    [TestClass]
    public class SportsCarTest
    {
        private TestContext testContext;

        public TestContext TestContext { get => testContext; set => testContext = value; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                 "|DataDirectory|\\SportsCarInputDataTests.csv", "SportsCarInputDataTests#csv", DataAccessMethod.Sequential),
         DeploymentItem("TestsData\\SportsCarData"), TestMethod]
        public void TestInput()
        {
            SportsCar a = new SportsCar(TestContext.DataRow["brand"].ToString(),
                TestContext.DataRow["model"].ToString(),
                TestContext.DataRow["color"].ToString(),
                Convert.ToDouble(TestContext.DataRow["maxSpeed"].ToString()),
                Convert.ToDouble(TestContext.DataRow["powerOfEngine"].ToString()),
                Convert.ToDouble(TestContext.DataRow["CapOfEngine"].ToString()),
                Convert.ToDouble(TestContext.DataRow["aeroDyn"].ToString()));
            SportsCar b = new SportsCar();
            b.Input(TestContext.DataRow["brand"].ToString() + " " +
                TestContext.DataRow["model"].ToString() + " " +
                TestContext.DataRow["color"].ToString() + " " +
                (TestContext.DataRow["maxSpeed"].ToString()) + " " +
                (TestContext.DataRow["powerOfEngine"].ToString()) + " " +
                (TestContext.DataRow["CapOfEngine"].ToString()) + " " +
                (TestContext.DataRow["aeroDyn"].ToString()));
            b.VIN = a.VIN;
            Assert.IsTrue(a.ToString().Equals(b.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                 "|DataDirectory|\\SportsCarCompareToDataTests.csv", "SportsCarCompareToDataTests#csv", DataAccessMethod.Sequential),
         DeploymentItem("TestsData\\SportsCarData"), TestMethod]
        public void TestCopareTo()
        {
            SportsCar a = new SportsCar();
            SportsCar b = new SportsCar();
            a.PowerOfEngine = Convert.ToDouble(TestContext.DataRow["first"].ToString());
            b.PowerOfEngine = Convert.ToDouble(TestContext.DataRow["second"].ToString());
            Assert.AreEqual(a.CompareTo(b), Convert.ToInt32(TestContext.DataRow["result"].ToString()));
        }
    }
}

