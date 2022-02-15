using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Zadanie4_PN.Animations
{
    public class MovementAlongCircle
    {
        private int length;
        public MovementAlongCircle(int howLong)
        {
            length = howLong;
        }

        public (double X, double Y, double Z) GetNextVector()
        {
            return (0, 0, 0);
        }
    }
}
