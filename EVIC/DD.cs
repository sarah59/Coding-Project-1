/*
*Written By: Leah Dever and Sarah Martin
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVIC
{
    /// <summary>
    /// 
    /// </summary>
    class Odometer
    {

        int ode;
        int _tripA;
        int _tripB;

        public Odometer()
        {
            this.ode = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public void increment()
        {
            ode++;
            _tripA++;
            _tripB++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int currentMileage()
        {
            return ode;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class TripInfo
    {
        int _tripA;
        int _tripB;
        Odometer _odometer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_odometer"></param>
        public TripInfo(Odometer _odometer)
        {
            this._odometer = _odometer;
            this._tripA = _odometer.currentMileage();
            this._tripB = _odometer.currentMileage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getTripAValue()
        {
            return _odometer.currentMileage() - _tripA;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getTripBValue()
        {
            return _odometer.currentMileage() - _tripB;
        }

        /// <summary>
        /// 
        /// </summary>
        public void resetA()
        {
            _tripA = _odometer.currentMileage();
        }

        /// <summary>
        /// 
        /// </summary>
        public void resetB()
        {
            _tripB = _odometer.currentMileage();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class System_Status
    {
        int lastOilChange;
        Odometer _odometer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_odometer"></param>
        public System_Status(Odometer _odometer)
        {
            this._odometer = _odometer;
            lastOilChange = _odometer.currentMileage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Oil()
        {
            int change = 3000 - (_odometer.currentMileage() - lastOilChange);
            return change;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int ResetOil()
        {
            lastOilChange = _odometer.currentMileage();
            return lastOilChange;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class Temperature
    {
        int inside;
        int outside;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Temperature(int a, int b)
        {
            inside = a;
            outside = b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int TempOutside()
        {
            return outside;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int TempInside()
        {
            return inside;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class Settings
    {
        public bool usingMetric;
        public Settings()
        {
            usingMetric = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Change()
        {
            usingMetric = !usingMetric;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class Warnings
    {
        bool engine;
        bool ajar;
        bool changeOil;

        public Warnings()
        {
            this.engine = true;
            this.ajar = true;
            this.changeOil = true;
        }

        public bool Engine()
        {
            return engine;
        }

        public bool Ajar()
        {
            return ajar;
        }

        public bool ChangeOil()
        {
            return changeOil;
        }
    }
}

