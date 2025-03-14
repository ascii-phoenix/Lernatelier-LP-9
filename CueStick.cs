using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engin_Bliiard
{
    public class CueStick : IGameObject
    {
        public double Radius { get => 0.1; }
        public bool Movable { get => true; }
        public CueBall cueBall;
        public Position position;
        private Position beginningOfimpact;
        private bool IsMouseKlicking;
        private const double MaxVelocity = 100;
        public CueStick(CueBall CueBall, Position Position = null)
        {
            cueBall = CueBall;
            position = Position ?? new Position(0,0);

        }
        public void updatePosition(Position NewPosition)
        {
            position = NewPosition;
        }
        public void StartSwing()
        {
            beginningOfimpact = position;
        }
        public void EndSwing()
        {
            Vector direction = new Vector
            (
                beginningOfimpact.X - cueBall.Position.X,
                beginningOfimpact.Y - cueBall.Position.Y
            ).Normalize();

            double velocity = Math.Sqrt
            (
                Math.Pow(position.X - beginningOfimpact.X, 2) +
                Math.Pow(position.Y - beginningOfimpact.Y, 2)
            );
            velocity = Math.Min(velocity, MaxVelocity);

            cueBall.InitialHit(direction * velocity);
        }
    }
}
