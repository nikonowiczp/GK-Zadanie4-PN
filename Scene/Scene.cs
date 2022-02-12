using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GK_Zadanie4_PN.Objects;
using GK_Zadanie4_PN.BitmapController;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GK_Zadanie4_PN.Scene
{
    internal class Scene
    {
        public List<SceneObject> SceneObjects = new List<SceneObject>();

        public void AddObject(SceneObject sceneObject)
        {
            SceneObjects.Add(sceneObject);
        }

        public void GenerateNextFrame()
        {
            throw new NotImplementedException();
        }

    }
}
