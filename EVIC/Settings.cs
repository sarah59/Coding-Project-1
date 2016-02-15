using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVIC
{
    class Settings
    {
        int us;
        int metric;

        public int ConvertMetric(int miles)
        {
            metric = Convert.ToInt32(1.609 * miles);
                return metric;
        }
        public int ConvertUS(int kilo)
        {
            us = Convert.ToInt32(0.6213 * kilo);
            return us;
        }
    }
}
