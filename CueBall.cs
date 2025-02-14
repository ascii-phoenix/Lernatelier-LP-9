using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engin_Bliiard
{
    public class CueBall : BilliardBall
    {
        public CueBall(double x, double y, double vx = 0, double vy = 0) : base(x, y, vx, vy)
        {
        }
        public void InitialHit(double angle, double force)
        {
            SetVelocity(force * Math.Cos(angle), force * Math.Sin(angle));
        }
    }
}
