using Microsoft.VisualStudio.TestTools.UnitTesting;
using EVIC;
using System;
using Class_Library;

namespace EVIC.Tests
{
    [TestClass()]
    public class TestClass
    {
        [TestMethod()] //odometer class
        public void TestMethod()
        {
            Class_Library.Class1.Odometer o = new Class1.Odometer();
            Assert.AreEqual(o.currentMileage(), o.ode);
        }

        [TestMethod()] //trip info class
        public void TestMethod1()
        {
            Class_Library.Class1.Odometer o = new Class1.Odometer();
            Class_Library.Class1.TripInfo tt = new Class1.TripInfo(o);
            Assert.AreEqual((o.currentMileage() - tt._tripA), tt.getTripAValue());
        }

        [TestMethod()] //system status class
        public void TestMethod2()
        {
            Class_Library.Class1.Odometer o = new Class1.Odometer();
            Class_Library.Class1.System_Status ss = new Class1.System_Status(o);
            Assert.AreEqual(o.currentMileage(), ss.ResetOil());
        }

        [TestMethod()] //warnings class
        public void TestMethod3()
        {
            Class_Library.Class1.Warnings w = new Class1.Warnings();
            Assert.IsTrue(w.ajar);
            Assert.IsTrue(w.engine);
            Assert.IsTrue(w.changeOil);
        }

        [TestMethod()] //ToCelcius method
        public void TestMethod4()
        {
            Class_Library.Class1.Temperature t = new Class1.Temperature(0, 0);
            Assert.AreNotEqual(t.TempInside(), Class1.ToCelcius(0));
        }

        [TestMethod()] //toggle method
        public void TestMethod5()
        {
            bool b = true;
            Assert.AreNotEqual(Class1.toggle(b), !b);
        }

        [TestMethod()] //toMetric method
        public void TestMethod6()
        {
            int a = 1;
            Assert.AreNotEqual(Class1.ToMetric(a), a);
        }
    }
}