/*
*Written By: Leah Devers and Sarah Martin
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EVIC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
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

            while (true)
            {

                _keyPress = Console.ReadKey().Key;

                int censor = 0;

                if (_keyPress == ConsoleKey.RightArrow)
                {
                    censor++;
                }
                else if(_keyPress == ConsoleKey.LeftArrow)
                {
                    censor--;
                }

                if (censor == 0)
                {
                    if (_keyPress == ConsoleKey.UpArrow || _keyPress == ConsoleKey.DownArrow)
                    {
                        if (_howManyMiles == 0)
                        {
                            _howManyMiles = 1;

                            if (_settings.usingMetric == true)
                            {
                                int x = ToMetric(_ss.Oil());
                                Display(x.ToString());
                            }
                            else
                            {
                                Display(_ss.Oil().ToString());
                            }
                        }
                        else
                        {
                            _howManyMiles = 0;
                            if (_settings.usingMetric == true)
                            {
                                int y = ToMetric(_odometer.currentMileage());
                                Display(y.ToString());
                            }
                            else
                            {
                                Display(_odometer.currentMileage().ToString());
                            }
                        }
                    }

                    else if (_keyPress == ConsoleKey.Spacebar)
                    {
                        if (_howManyMiles == 1)
                        {
                            if (_settings.usingMetric == true)
                            {
                                int y = ToMetric(_ss.ResetOil());
                                Display(y.ToString());
                            }
                            else
                            {
                                Display(_ss.ResetOil().ToString());
                            }
                        }
                    }
                }

                if (censor == 1 || censor == -4)
                {
                    if (_ajar == false && _engine == false && _changeOil == false)
                    {
                        Display("No Warning Messages");
                    }
                    
                    else
                    {
                        while (_keyPress == ConsoleKey.UpArrow)
                        {
                            if(_ajar == true && _keyPress == ConsoleKey.UpArrow)
                            {
                                Display("Door Ajar");
                            }
                            else if(_engine == true && _keyPress == ConsoleKey.UpArrow)
                            {
                                Display("Check Engine Soon");
                            }
                            else if(_changeOil == true && _keyPress == ConsoleKey.UpArrow)
                            {
                                Display("Oil Change");
                            }
                        }
                        
                    }
                }

                else if (censor == 2 || censor == -3)
                {
                    if (_keyPress == ConsoleKey.UpArrow || _keyPress == ConsoleKey.DownArrow || _keyPress == ConsoleKey.Spacebar)
                    {
                        _settings.Change();
                    }
                }
                else if (censor == 3 || censor == -2)
                {
                    if (_keyPress == ConsoleKey.UpArrow || _keyPress == ConsoleKey.DownArrow)
                    {
                        if (_inOrOut == 0)
                        {
                            _inOrOut = 1;
                            if (_settings.usingMetric == true)
                            {
                                int x = ToCelcius(_t.TempInside());
                                Display(x.ToString());
                            }
                            else
                            {
                                Display(_t.TempInside().ToString());
                            }
                        }
                        else
                        {
                            _inOrOut = 0;
                            if (_settings.usingMetric == true)
                            {
                                int y = ToCelcius(_t.TempOutside());
                                Display(y.ToString());
                            }
                            else
                            {
                                Display(_t.TempOutside().ToString());
                            }
                        }
                    }
                }

                else if (censor == 4 || censor == -1)
                {
                    if (_keyPress == ConsoleKey.UpArrow || _keyPress == ConsoleKey.DownArrow)
                    {
                        if (_aOrB == 0)
                        {
                            _aOrB = 1;
                            if (_settings.usingMetric == true)
                            {
                                int x = ToMetric(trip.getTripAValue());
                                Display(x.ToString());
                            }
                            else
                            {
                                Display(trip.getTripAValue().ToString());
                            }
                        }
                        else
                        {
                            _aOrB = 0;
                            if (_settings.usingMetric == true)
                            {
                                int y = ToMetric(trip.getTripBValue());
                                Display(y.ToString());
                            }
                            else
                            {
                                Display(trip.getTripBValue().ToString());
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

                else if(censor > 4 || censor < -4)
                {
                    censor = 4;
                }
                
                else
                {
                    censor = 0;
                }

                if(_keyPress == ConsoleKey.NumPad1)
                {
                    status(_odometer);
                }
                else if(_keyPress == ConsoleKey.NumPad2)
                {
                    try
                    {
                        Console.WriteLine("A) Door Ajar \n B) Check Engine Soon \n C) Oil Change");
                        Console.WriteLine("Press the corresponding letter to turn the warning message on/off");
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
                else if(_keyPress == ConsoleKey.NumPad3)
                {
                    int valueA = 0;
                    int valueB = 0;

                    Console.WriteLine("A) Outside Temperature \n B) Inside Temperature");

                    if (Console.ReadKey().Key == ConsoleKey.A)
                    {
                        Console.WriteLine("Please enter the outside temperature: ");
                        valueA = temp();
                    }
                    if (Console.ReadKey().Key == ConsoleKey.B)
                    {
                        Console.WriteLine("Please enter the inside temperature of the vehicle: ");
                        valueB = temp();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="miles"></param>
        /// <returns></returns>
        public static int ToMetric(int miles)
        {
            return Convert.ToInt32(1.609 * miles);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public static void Display(string s)
        {
            Console.WriteLine(string.Format("[{0}]"), s);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static int ToCelcius(int temp)
        {
            return Convert.ToInt32((temp - 32) / 1.8);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int temp()
        {
            int degree;
            return degree = Convert.ToInt32(Console.ReadLine());
        }

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

        public static bool toggle(bool w)
        {
            return !w;
        }
    }
}