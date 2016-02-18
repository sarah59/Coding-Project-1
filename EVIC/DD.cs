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
    /// Keeps track of how many miles have been driven.
    /// </summary>
    public class Odometer
    {
        public int ode;
        int _tripA;
        int _tripB;

        /// <summary>
        /// Constructor
        /// </summary>
        public Odometer()
        {
            this.ode = 0;
        }

        /// <summary>
        /// Adds 1 to the mileage.
        /// </summary>
        public void increment()
        {
            ode++;
            _tripA++;
            _tripB++;
        }

        /// <summary>
        /// How far the car has gone.
        /// </summary>
        /// <returns>how many miles have been driven</returns>
        public int currentMileage()
        {
            return ode;
        }
    }

    /// <summary>
    /// Keeps track of trip A and trip B.
    /// </summary>
    public class TripInfo
    {
        public int _tripA;
        public int _tripB;
        Odometer _odometer;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="_odometer"></param>
        public TripInfo(Odometer _odometer)
        {
            this._odometer = _odometer;
            this._tripA = _odometer.currentMileage();
            this._tripB = _odometer.currentMileage();
        }

        /// <summary>
        /// Trip A total mileage.
        /// </summary>
        /// <returns>trip A value</returns>
        public int getTripAValue()
        {
            return _odometer.currentMileage() - _tripA;

        }

        /// <summary>
        /// Trip B total mileage.
        /// </summary>
        /// <returns>trip B value</returns>
        public int getTripBValue()
        {
            return _odometer.currentMileage() - _tripB;
        }

        /// <summary>
        /// Sets trip A to 0.
        /// </summary>
        public void resetA()
        {
            _tripA = _odometer.currentMileage();
        }

        /// <summary>
        /// Sets trip B to 0.
        /// </summary>
        public void resetB()
        {
            _tripB = _odometer.currentMileage();
        }
    }

    /// <summary>
    /// Keeps track of the oil status.
    /// </summary>
    public class System_Status
    {
        int lastOilChange;
        Odometer _odometer;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="_odometer">current odometer to determine current mileage</param>
        public System_Status(Odometer _odometer)
        {
            this._odometer = _odometer;
            lastOilChange = _odometer.currentMileage();
        }

        /// <summary>
        /// Miles until next oil change.
        /// </summary>
        /// <returns>miles until next change</returns>
        public int Oil()
        {
            int change = 3000 - (_odometer.currentMileage() - lastOilChange);
            return change;
        }

        /// <summary>
        /// The last oil change.
        /// </summary>
        /// <returns>how many miles ago the last oil change occured</returns>
        public int ResetOil()
        {
            lastOilChange = _odometer.currentMileage();
            return lastOilChange;
        }
    }

    /// <summary>
    /// Inside and outside temperature.
    /// </summary>
    public class Temperature
    {
        int inside;
        int outside;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="a">inside temperature</param>
        /// <param name="b">outside temperature</param>
        public Temperature(int a, int b)
        {
            inside = a;
            outside = b;
        }

        /// <summary>
        /// Outside temperature.
        /// </summary>
        /// <returns>the temperature outside</returns>
        public int TempOutside()
        {
            return outside;
        }

        /// <summary>
        /// Inside temperature.
        /// </summary>
        /// <returns>the temperature inside</returns>
        public int TempInside()
        {
            return inside;
        }
    }

    /// <summary>
    /// US vs Metric settings
    /// </summary>
    public class Settings
    {
        public bool usingMetric;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Settings()
        {
            usingMetric = false;
        }

        /// <summary>
        /// Toggles the setting between US and Metric
        /// </summary>
        public void Change()
        {
            usingMetric = !usingMetric;
        }
    }

    /// <summary>
    /// Warning messages.
    /// </summary>
    public class Warnings
    {
        public bool engine;
        public bool ajar;
        public bool changeOil;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Warnings()
        {
            this.engine = true;
            this.ajar = true;
            this.changeOil = true;
        }

        /// <summary>
        /// Check engine.
        /// </summary>
        /// <returns>if the check engine light is on</returns>
        public bool Engine()
        {
            return engine;
        }

        /// <summary>
        /// Door ajar.
        /// </summary>
        /// <returns>if the door is ajar</returns>
        public bool Ajar()
        {
            return ajar;
        }

        /// <summary>
        /// Time for an oil change.
        /// </summary>
        /// <returns>if the car need an oil change</returns>
        public bool ChangeOil()
        {
            return changeOil;
        }
    }
}

