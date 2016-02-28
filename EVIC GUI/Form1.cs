using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVIC_GUI
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        static Class_Library.Class1.Odometer _odometer = new Class_Library.Class1.Odometer();
        Class_Library.Class1.TripInfo trip = new Class_Library.Class1.TripInfo(_odometer);
        Class_Library.Class1.Settings _settings = new Class_Library.Class1.Settings();
        Class_Library.Class1.System_Status _ss = new Class_Library.Class1.System_Status(_odometer);
        Class_Library.Class1.Temperature _t = new Class_Library.Class1.Temperature(0, 0);
        Class_Library.Class1.Warnings _messages = new Class_Library.Class1.Warnings();

        int censor = 0;


        private void button_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "System Status")
            {
                censor = 0;
                listViewBox.Items.Add(_odometer.currentMileage() + " mi");
                listViewBox.Items.Add(_ss.Oil().ToString());
                MessageBox.Show("Please enter 'ENTER' into the textbox to increment the mileage.");
            }
            else if(comboBox1.Text == "Warning Messages")
            {
                censor = 1;
                MessageBox.Show("Please enter a warning message you wish to display in the text box and press ENTER. Otherwise, just press ENTER");         
            }
            else if(comboBox1.Text == "Personal Settings")
            {
                censor = 2;
                MessageBox.Show("Please enter either US or METRIC in the textbox and press ENTER."); 
            }
            else if(comboBox1.Text == "Temperature Information")
            {
                censor = 3;
                MessageBox.Show("Please enter a temperature in Farenheit then press ENTER.");
            }
            else if(comboBox1.Text == "Trip Information")
            {
                censor = 4;
                listViewBox.Items.Add("Trip A: " + trip.getTripAValue());
                listViewBox.Items.Add("Trip B: " + trip.getTripBValue());
            }
            else
            {
                MessageBox.Show("Please enter a valid option.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(censor == 0)
            {
                if(textBox.Text.Trim().ToUpper() == "ENTER")
                {
                    _odometer.increment();
                }
                else
                {
                    MessageBox.Show("Please enter 'ENTER' if you want to increment the mileage.");
                }
            }
            if(censor == 1)
            {
                if (textBox.Text.ToUpper().Trim() == "DOOR AJAR")
                {
                    listViewBox.Items.Add("Door Ajar: On");
                }
                else if (textBox.Text.ToUpper().Trim() == "CHECK ENGINE SOON")
                {
                    listViewBox.Items.Add("Check Engine Soon: On");
                }
                else if (textBox.Text.ToUpper().Trim() == "OIL CHANGE")
                {
                    listViewBox.Items.Add("Oil Change: On");
                }
                else
                {
                    listViewBox.Items.Add("No Warning Messages.");
                }
            }
            else if(censor == 2)
            {
                if(textBox.Text.ToUpper().Trim() == "US")
                {
                    listViewBox.Items.Add("Personal Setting: US");
                }
                else if(textBox.Text.Trim().ToUpper() == "METRIC")
                {
                    listViewBox.Items.Add("Personal Settings: METRIC");
                }
                else
                {
                    MessageBox.Show("Please enter a valid measurement system (US or METRIC).");
                }
            }
            else if(censor == 3)
            {
                listViewBox.Items.Add("Temperature is: " + textBox.Text.Trim());
                listViewBox.Items.Add("Temperature in Celcius is: " + Class_Library.Class1.ToCelcius(Convert.ToInt32(textBox.Text.Trim())));
            }
        }
    }
}