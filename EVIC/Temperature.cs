using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVIC
{
    public class Temperature
    {
        int inside;
        int outside;

    public Temperature(int a, int b)
    {
            inside = a;
            b = outside;
    }
        
    public string TempOutside()
        {
            return outside.ToString();
        }
    public string TempInside()
        {
            return inside.ToString();
        }
}
}
