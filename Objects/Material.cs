using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Zadanie4_PN.Objects
{
    public class Material
    {
        public Material(double kA, double kD, double kS,double shininess)
        {
            KA = kA;
            KD = kD;
            KS = kS;
            Shininess = shininess;
        }
        public double KA = 1;
        public double KD = 1;
        public double KS = 1;

        public double Shininess = 1;
    }
}
