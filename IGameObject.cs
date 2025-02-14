using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engin_Bliiard
{
    public interface IGameObject
    {
        public double Radius { get; }
        public bool Movable { get; }
    }
}
