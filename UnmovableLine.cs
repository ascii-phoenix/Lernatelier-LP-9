using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engin_Bliiard
{
    public class UnmovableLine : IGameObject
    {
        public Position Start { get; set; }
        public Position End { get; set; }
        public double Radius { get => 0; }

        public bool Movable => false;

        public Position Position
        {
            get => new Position((Start.X + End.X) / 2, (Start.Y + End.Y) / 2);
            set => throw new InvalidOperationException("UnmovableLine cannot be moved.");
        }

        public UnmovableLine(Position start, Position end)
        {
            Start = start;
            End = end;
        }

        public Position GetPosition()
        {
            throw new NotImplementedException();
        }
    }
}
