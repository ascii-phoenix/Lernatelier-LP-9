using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engin_Bliiard
{
    public class Position
    {
        public double X { get;  set; }
        public double Y { get;  set; }

        public Position(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }
    }
}
