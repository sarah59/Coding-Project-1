/*
*Written By: Leah Devers and Sarah Martin
*CIS 501 - Coding Project 1
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Class_Library;

namespace EVIC
{
    /// <summary>
    /// Contains the executable code for the car simulation.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            //initializing variables
            Odometer _odometer = new Odometer();
            TripInfo trip = new TripInfo(_odometer);
            Settings _settings = new Settings();
            System_Status _ss = new System_Status(_odometer);
            Temperature _t = new Temperature(0, 0);
            Warnings _messages = new Warnings();

            ConsoleKey _keyPress;
            int _aOrB = 0;
            int _howManyMiles = 0;
            int _inOrOut = 0;
            bool _ajar = _messages.Ajar();
            bool _engine = _messages.Engine();
            bool _changeOil = _messages.ChangeOil();
            int censor = 0; //keeps track of which way the menu shifts

            Display(_odometer.currentMileage().ToString() + " mi");

            //continually checks for the press of the key
            while (true)
            {
                _keyPress = Console.ReadKey().Key;

                if (_keyPress == ConsoleKey.RightArrow)
                {
                    censor++;
                }
                else if(_keyPress == ConsoleKey.LeftArrow)
                {
                    censor--;
                }

                //first menu option which is a personal setting to determine if the user prefers metric or US measurements
                if (censor == 0)
                {
                    Display(_odometer.currentMileage().ToString() + " mi");
                    if (_keyPress == ConsoleKey.UpArrow || _keyPress == ConsoleKey.DownArrow)
                    {
                        if (_howManyMiles == 0)
                        {
                            _howManyMiles = 1;

                            if (_settings.usingMetric == true)
                            {
                                int x = ToMetric(_ss.Oil());
                                Display(x.ToString() + " mi til Next Oil Change");
                            }
                            else
                            {
                                Display(_ss.Oil().ToString() + " mi til Next Oil Change");
                            }
                        }
                        else
                        {
                            _howManyMiles = 0;
                            if (_settings.usingMetric == true)
                            {
                                int y = ToMetric(_odometer.currentMileage());
                                Display(y.ToString() + " mi");
                            }
                            else
                            {
                                Display(_odometer.currentMileage().ToString() + " mi");
                            }
                        }
                        if(_keyPress == ConsoleKey.Enter)
                        {
                            _odometer.increment();
                        }
                    }
                    //switches between the 2 options and saves the users setting
                    else if (_keyPress == ConsoleKey.Spacebar)
                    {
                        if (_howManyMiles == 1)
                        {
                            if (_settings.usingMetric == true)
                            {
                                int y = ToMetric(_ss.ResetOil());
                                Display(y.ToString() + " km");
                            }
                            else
                            {
                                Display(_ss.ResetOil().ToString() + " km");
                            }
                        }
                    }
                }
                //displays any potential warning messages that the user can toggle to be on or off
                if (censor == 1 || censor == -4)
                {
                    Display("Warnings");
                    if (_messages.Ajar() == false && _messages.Engine() == false && _messages.ChangeOil() == false)
                    {
                        Display("No Warning Messages");
                    }
                    
                    else
                    {
                        if (_ajar == true)
                        {
                            Display("Door Ajar");
                        }
                        else if (_engine == true && _keyPress == ConsoleKey.UpArrow)
                        {
                            Display("Check Engine Soon");
                        }
                        else if (_changeOil == true && _keyPress == ConsoleKey.UpArrow)
                        {
                            Display("Oil Change");
                        }
                    }
                }
                //US vs Metric
                else if (censor == 2 || censor == -3)
                {
                    Display("US");
                    if (_keyPress == ConsoleKey.UpArrow)
                    {
                        _settings.Change();
                        if (_settings.usingMetric == true)
                        {
                            Display("Metric");
                        }
                        else
                        {
                            Display("US");
                        }
                    }
                    else if (_keyPress == ConsoleKey.DownArrow)
                    {
                        _settings.Change();
                        if (_settings.usingMetric == true)
                        {
                            Display("Metric");
                        }
                        else
                        {
                            Display("US");
                        }
                    }
                    else if (_keyPress == ConsoleKey.Spacebar)
                    {
                        _settings.Change();
                        if (_settings.usingMetric == true)
                        {
                            Display("Metric");
                        }
                        else
                        {
                            Display("US");
                        }
                    }
                    else { Display("US"); }
                }
                //displays and converts the temperature
                else if (censor == 3 || censor == -2)
                {
                    Display("Temperature");
                    if (_keyPress == ConsoleKey.UpArrow || _keyPress == ConsoleKey.DownArrow)
                    {
                        if (_inOrOut == 0)
                        {
                            _inOrOut = 1;
                            if (_settings.usingMetric == true)
                            {
                                int x = ToCelcius(_t.TempInside());
                                Display(x.ToString() + " Inside Temperature");
                            }
                            else
                            {
                                Display(_t.TempInside().ToString() + " Inside Temperature");
                            }
                        }
                        else
                        {
                            _inOrOut = 0;
                            if (_settings.usingMetric == true)
                            {
                                int y = ToCelcius(_t.TempOutside());
                                Display(y.ToString() + " Outside Temperature");
                            }
                            else
                            {
                                Display(_t.TempOutside().ToString() + " Outside Temperature");
                            }
                        }
                    }
                }
                //displays trip A and trip B, and if necessary, coverts them
                else if (censor == 4 || censor == -1)
                {
                    Display(_odometer.currentMileage().ToString() + " mi");
                    if (_keyPress == ConsoleKey.UpArrow || _keyPress == ConsoleKey.DownArrow)
                    {
                        if (_aOrB == 0)
                        {
                            _aOrB = 1;
                            if (_settings.usingMetric == true)
                            {
                                int x = ToMetric(trip.getTripAValue());
                                Display("Trip A: " + x.ToString() + " mi");
                            }
                            else
                            {
                                Display("Trip A: " + trip.getTripAValue().ToString() + " mi");
                            }
                        }
                        else
                        {
                            _aOrB = 0;
                            if (_settings.usingMetric == true)
                            {
                                int y = ToMetric(trip.getTripBValue());
                                Display("Trip B: " + y.ToString() + " mi");
                            }
                            else
                            {
                                Display("Trip B: " + trip.getTripBValue().ToString() + " mi");
                            }
                        }
                    }

                    else if (_keyPress == ConsoleKey.Spacebar)
                    {
                        if (_aOrB == 0)
                        {
                            trip.resetA();
                        }
                        else
                        {
                            trip.resetB();
                        }
                    }
                    else if(_keyPress == ConsoleKey.Enter)
                    {
                        _odometer.increment();
                    }
                }
                //loop
                else if(censor > 4 || censor < -4)
                {
                    censor = 0;
                }
                
                else
                {
                    censor = 0;
                }
                //displays the odometer and increments the mileage
                if(_keyPress == ConsoleKey.NumPad1)
                {
                    status(_odometer);
                }
                //displays warning messages and toggles the warnings
                else if(_keyPress == ConsoleKey.NumPad2)
                {
                    try
                    {
                        Console.WriteLine("A) Door Ajar \n B) Check Engine Soon \n C) Oil Change");
                        Console.WriteLine("Press the corresponding letter to turn the warning message on/off.");
                        if (_keyPress == ConsoleKey.A)
                        {
                            toggle(_ajar);
                        }
                        else if (_keyPress == ConsoleKey.B)
                        {
                            toggle(_engine);
                        }
                        else if (_keyPress == ConsoleKey.C)
                        {
                            toggle(_changeOil);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Must choose one of the three letters.");
                    }
                }
                //displays and translates the temperature
                else if(_keyPress == ConsoleKey.NumPad3)
                {
                    int valueA = 0;
                    int valueB = 0;

                    Console.WriteLine("A) Inside Temperature \n B) Outside Temperature");

                    if (Console.ReadKey().Key == ConsoleKey.A)
                    {
                        Console.WriteLine("Please enter the inside temperature: ");
                        valueA = temp();
                    }
                    if (Console.ReadKey().Key == ConsoleKey.B)
                    {
                        Console.WriteLine("Please enter the outside temperature of the vehicle: ");
                        valueB = temp();
                    }
                    _t = new Temperature(valueA, valueB);
                }
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
            if(s != "")
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