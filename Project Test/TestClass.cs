using Microsoft.VisualStudio.TestTools.UnitTesting;
using EVIC;
using System;

namespace EVIC.Tests
{
    [TestClass()]
    public class TestClass
    {
        [TestMethod()] //odometer class
        public void TestMethod()
        {
            Odometer o = new Odometer();
            Assert.AreEqual(o.currentMileage(), o.ode);
        }

        [TestMethod()] //trip info class
        public void TestMethod1()
        {
            Odometer o = new Odometer();
            TripInfo tt = new TripInfo(o);
            Assert.AreEqual((o.currentMileage() - tt._tripA), tt.getTripAValue());
        }

        [TestMethod()] //system status class
        public void TestMethod2()
        {
            Odometer o = new Odometer();
            System_Status ss = new System_Status(o);
            Assert.AreEqual(o.currentMileage(), ss.ResetOil());
        }

        [TestMethod()] //warnings class
        public void TestMethod3()
        {
            Warnings w = new Warnings();
            Assert.IsTrue(w.ajar);
            Assert.IsTrue(w.engine);
            Assert.IsTrue(w.changeOil);
        }

        [TestMethod()] //ToCelcius method
        public void TestMethod4()
        {
            Temperature t = new Temperature(0, 0);
            Assert.AreNotEqual(t.TempInside(), Program.ToCelcius(0));
        }

        [TestMethod()] //toggle method
        public void TestMethod5()
        {
            bool b = true;
            Assert.AreNotEqual(Program.toggle(b), !b);
        }

        [TestMethod()] //toMetric method
        public void TestMethod6()
        {
            int a = 1;
            Assert.AreNotEqual(Program.ToMetric(a), a);
        }
    }
}