using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public class Class1
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
        /// <summary>
        /// Changes miles to metric.
        /// </summary>
        /// <param name="miles">number we are changing to metric</param>
        /// <returns>number of kilometers</returns>
        public static int ToMetric(int miles)
        {
            return Convert.ToInt32(1.609 * miles);
        }

        /// <summary>
        /// Prints and formats a string.
        /// </summary>
        /// <param name="s">string we are formatting in order to consistently print</param>
        public static void Display(string s)
        {
            Console.Clear();
            if (s != "")
            {
                Console.WriteLine("[" + s + "]");
            }
            Console.WriteLine("\n 1) Status \n 2) Warning Messages \n 3) Temperature Info \n");
        }

        /// <summary>
        /// Changes farenheit to celcius.
        /// </summary>
        /// <param name="temp">farenheit number the user enters</param>
        /// <returns>celcius temperature</returns>
        public static int ToCelcius(int temp)
        {
            return Convert.ToInt32((temp - 32) / 1.8);
        }

        /// <summary>
        /// Get the degree and convert to an int.
        /// </summary>
        /// <returns>degrees</returns>
        public static int temp()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        /// <summary>
        /// Increments the mileage.
        /// </summary>
        /// <param name="ode">odometer that contains the current mileage</param>
        public static void status(Odometer ode)
        {
            Odometer o = ode;
            try
            {
                Console.WriteLine("Press enter to increment the mileage by 1 mile.");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    o.increment();
                }
            }
            catch (Exception)
            {
                Console.Write("Press Enter to increment.");
            }
        }

        /// <summary>
        /// Changes the bool value to the opposite.
        /// </summary>
        /// <param name="w">bool that we want to change</param>
        /// <returns>the opposite of w</returns>
        public static bool toggle(bool w)
        {
            return !w;
        }
    }
}
