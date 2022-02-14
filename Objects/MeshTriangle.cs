using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Zadanie4_PN.Objects
{
    public class MeshTriangle
    {
        public MeshTriangle(Vertice vertice1, Vertice vertice2, Vertice vertice3, Material material)
        {
            Vertices[0] = vertice1;
            Vertices[1] = vertice2;
            Vertices[2] = vertice3;
            Material = material;
        }
        public Vertice[] Vertices = new Vertice[3];
        public Material Material;
        public bool IsClockWise()
        {
            throw new NotImplementedException();
        }
    }

    public class NotClockwiseOnCreationException : Exception
    {

    }
}
