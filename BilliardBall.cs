using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engin_Bliiard
{

    public class BilliardBall : IGameObject
    {
        public Position Position { get; set; }
        public Vector Velocity { get; set; }
        public double Radius { get => 0.5; }
        public bool Movable { get => true;}

        private const double friction = 0.99;

        public BilliardBall(double x, double y, double vx = 0, double vy = 0)
        {
            Position = new Position(x, y);
            Velocity = new Vector ( vx,vy );
        }

        public void UpdatePosition(double dt)
        {
            Position.X += Velocity.Vx * dt - friction * dt;
            Position.Y += Velocity.Vy * dt - friction * dt;
        }

        
        protected void SetVelocity(double vx, double vy)
        {
            Velocity.Vx = vx;
            Velocity.Vy = vy;
        }
        

        public Position GetPosition()
        {
            return Position;
        }
    }

}
