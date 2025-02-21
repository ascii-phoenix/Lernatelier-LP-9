using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engin_Bliiard
{
    public class Vector
    {
        public double Vx { get; set; }
        public double Vy { get; set; }

        public Vector(double vx, double vy)
        {
            Vx = vx;
            Vy = vy;
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.Vx + b.Vx, a.Vy + b.Vy);
        }

        // Subtraktion zweier Vektoren
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.Vx - b.Vx, a.Vy - b.Vy);
        }

        // Skalarprodukt
        public static Vector operator *(Vector a, double scalar)
        {
            return new Vector(a.Vx * scalar, a.Vy * scalar);
        }

        public static Vector operator /(Vector a, double scalar)
        {
            return new Vector(a.Vx / scalar, a.Vy / scalar);
        }

        public double Length()
        {
            return Math.Sqrt(Vx * Vx + Vy * Vy);
        }

        public Vector Normalize()
        {
            double length = Length();
            if (length != 0)
            {
                return new Vector(Vx / length, Vy / length);
            }
            return new Vector(0, 0);
        }
    }
}

