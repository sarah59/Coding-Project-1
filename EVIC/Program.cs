using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVIC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            if (Console.ReadKey().Key == ConsoleKey.UpArrow)
            {
                Console.WriteLine("1) System Status\n 2) Warning Message\n 3) Personal Setting\n 4) Temperature Display\n 5) Trip Info\n");
                if(Console.ReadKey().Key == ConsoleKey.NumPad1)
                {
                    System_Status _oilChange = new System_Status(); 
                }
                else if(Console.ReadKey().Key == ConsoleKey.NumPad2)
                {
                    Warning _warning = new Warning();
                }
                else if(Console.ReadKey().Key == ConsoleKey.NumPad3)
                {
                    Settings _units = new Settings();
                }
                else if(Console.ReadKey().Key == ConsoleKey.NumPad4)
                {
                    //Temperature _degree = new Temperature();
                }
                else if(Console.ReadKey().Key == ConsoleKey.NumPad5)
                {
                    Odometer _odometer = new Odometer();
                }

                
            }
            

        }

        public int temp()
        {
            try
            {
                Console.WriteLine("Please enter the outside temperature: ");
                int outside = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the inside temperature of the vehicle: ");
                int inside = Convert.ToInt32(Console.ReadLine());

                Temperature _change = new Temperature(outside, inside);

                while (Console.ReadKey().Key == ConsoleKey.UpArrow)
                {
                    if (Console.ReadKey().Key == ConsoleKey.UpArrow)
                    {
                        Console.WriteLine(_change.TempOutside());
                    }
                    else
                    {
                        Console.WriteLine(_change.TempInside());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter a valid number for the temperature");
            }
            
    }
}
