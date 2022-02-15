using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GK_Zadanie4_PN.Objects;
using MathNet.Numerics.LinearAlgebra;

namespace GK_Zadanie4_PN.Scene
{
    public class SceneGenerator
    {
        public static SceneObject GenerateCube()
        {
            SceneObject sceneObject = new SceneObject();

            var material = new Material(0.5, 0.5, 0.5, 20);
            //front
            Vertice vertice11 = new Vertice(-1, -1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice12 = new Vertice(1, -1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice13 = new Vertice(1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice14 = new Vertice(-1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            MeshTriangle front1 = new MeshTriangle(vertice11, vertice12, vertice13, material);
            MeshTriangle front2 = new MeshTriangle(vertice13, vertice14, vertice11, material);
            sceneObject.MeshTriangles.Add(front1);
            sceneObject.MeshTriangles.Add(front2);

            //back
            Vertice vertice21 = new Vertice(-1, -1, -1, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice22 = new Vertice(1, -1, -1, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice23 = new Vertice(1, 1, -1, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice24 = new Vertice(-1, 1, -1, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            MeshTriangle back1 = new MeshTriangle(vertice22, vertice23, vertice24, material);
            MeshTriangle back2 = new MeshTriangle(vertice24, vertice21, vertice22, material);
            sceneObject.MeshTriangles.Add(back1);
            sceneObject.MeshTriangles.Add(back2);

            //left
            Vertice vertice31 = new Vertice(-1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice32 = new Vertice(-1, -1, 1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice33 = new Vertice(-1, 1, 1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice34 = new Vertice(-1, 1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            MeshTriangle left1 = new MeshTriangle(vertice31, vertice32, vertice33, material);
            MeshTriangle left2 = new MeshTriangle(vertice33, vertice34, vertice31, material);
            sceneObject.MeshTriangles.Add(left1);
            sceneObject.MeshTriangles.Add(left2);

            //right
            Vertice vertice41 = new Vertice(1, -1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice42 = new Vertice(1, -1, -1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice43 = new Vertice(1, 1, -1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice44 = new Vertice(1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            MeshTriangle right1 = new MeshTriangle(vertice41, vertice42, vertice43, material);
            MeshTriangle right2 = new MeshTriangle(vertice43, vertice44, vertice41, material);
            sceneObject.MeshTriangles.Add(right1);
            sceneObject.MeshTriangles.Add(right2);

            //up
            Vertice vertice51 = new Vertice(-1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice52 = new Vertice(1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice53 = new Vertice(1, 1, -1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice54 = new Vertice(-1, 1, -1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            MeshTriangle up1 = new MeshTriangle(vertice51, vertice52, vertice53, material);
            MeshTriangle up2 = new MeshTriangle(vertice53, vertice54, vertice51, material);
            sceneObject.MeshTriangles.Add(up1);
            sceneObject.MeshTriangles.Add(up2);

            //bottom
            Vertice vertice61 = new Vertice(-1, -1, -1, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice62 = new Vertice(-1, -1, 1, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice63 = new Vertice(1, -1, 1, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            Vertice vertice64 = new Vertice(1, -1, -1, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            MeshTriangle bottom1 = new MeshTriangle(vertice61, vertice62, vertice63, material);
            MeshTriangle bottom2 = new MeshTriangle(vertice63, vertice64, vertice61, material);
            sceneObject.MeshTriangles.Add(bottom1);
            sceneObject.MeshTriangles.Add(bottom2);


            return sceneObject;
        }

        public static SceneObject GenerateSphere(double R, int stackCount, int sectorCount)
        {
            var material = new Material(0.8, 0.8, 1, 50);
            var sceneObject = new SceneObject();
            double stackStep = MathF.PI / stackCount;
            double sectorStep = 2 * MathF.PI / sectorCount;
            List<Vertice> vertixes = new List<Vertice>();

            // tworze punkty które tworzą sfere
            for (int i = 1; i <= stackCount - 1; i++)
            {

                for (int j = 0; j < sectorCount; j++)
                {

                    double Psi = stackStep * i, Phi = sectorStep * j;
                    Vertice point1 = MakePointOnSphere(Psi, Phi, R);

                    vertixes.Add(point1);
                }

            }


            // łącze wierzchołek na górze i na dole z wierzchołkami poniżej/ powyrzej 
            Vertice North = MakePointOnSphere(0, 0, R);
            Vertice South = MakePointOnSphere(MathF.PI, 2 * MathF.PI, R);
            for (int j = 0; j < sectorCount; j++)
            {
                int next;
                if (j == sectorCount - 1)
                    next = 0;
                else
                    next = j + 1;

                sceneObject.MeshTriangles.Add(new MeshTriangle(
                        North,
                        vertixes[next],
                        vertixes[j],
                        material
                        ));
                sceneObject.MeshTriangles.Add(new MeshTriangle(
                    vertixes[vertixes.Count - sectorCount + j],
                    vertixes[vertixes.Count - sectorCount + next],
                    South,
                    material
                    ));
            }

            // łącze pozostały punkty
            for (int i = 0; i < stackCount - 2; i++)
            {

                for (int j = 0; j < sectorCount; j++)
                {
                    int next;
                    if (j == sectorCount - 1)
                        next = 0;
                    else
                        next = j + 1;

                    sceneObject.MeshTriangles.Add(new MeshTriangle(
                        vertixes[i * sectorCount + j],
                        vertixes[i * sectorCount + next],
                        vertixes[(i + 1) * sectorCount + next],
                        material
                        ));
                    sceneObject.MeshTriangles.Add(new MeshTriangle(
                        vertixes[i * sectorCount + j],
                        vertixes[(i + 1) * sectorCount + next],
                        vertixes[(i + 1) * sectorCount + j],
                        material
                        ));
                }

            }



            return sceneObject;
        }

        private static Vertice MakePointOnSphere(double Psi, double Phi, double R)
        {

            Vector<double> position = Vector<double>.Build.DenseOfArray(new double[] {R * Math.Sin(Psi) * Math.Cos(Phi),
                                R * Math.Cos(Psi),
                                R * Math.Sin(Psi) * Math.Sin(Phi) });
            Vector<double> tangent = Vector<double>.Build.DenseOfArray(new double[] {Math.Cos(Psi) * Math.Cos(Phi),
                                                    -Math.Sin(Psi),
                                                    Math.Cos(Psi) * Math.Sin(Phi) });
            Vector<double> binormal = Vector<double>.Build.DenseOfArray(new double[] {-Math.Sin(Psi) * Math.Sin(Phi),
                                            0,
                                            Math.Sin(Psi) * Math.Cos(Phi) });

            Vector<double> normal = (position - Vector<double>.Build.DenseOfArray(new double[] { 0, 0, 0 })).Normalize(2);
            return new Vertice(position, normal, binormal, tangent);
        }

        public static SceneObject GenerateFloor(double length, int cuts)
        {
            SceneObject sceneObject = new();
            var material = new Material(0.5, 0.5, 0.5, 20);

            double edge = length / ((double)cuts);
            double currentX = -1*length/2;
            
            for(int i = 0; i < cuts; i++)
            {
                double currentZ = -1 * length / 2;
                for (int j = 0; j < cuts; j++)
                {
                    Vertice vertice61 = new Vertice(currentX, 0, currentZ, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    Vertice vertice62 = new Vertice(currentX, 0, currentZ+edge, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    Vertice vertice63 = new Vertice(currentX+edge, 0, currentZ + edge, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    Vertice vertice64 = new Vertice(currentX + edge, 0, currentZ, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    MeshTriangle bottom1 = new MeshTriangle(vertice61, vertice62, vertice63, material);
                    MeshTriangle bottom2 = new MeshTriangle(vertice63, vertice64, vertice61, material);
                    sceneObject.MeshTriangles.Add(bottom1);
                    sceneObject.MeshTriangles.Add(bottom2);
                    currentZ+=edge;
                }
                currentX += edge;
            }
            

            return sceneObject;
        }
    }
}
