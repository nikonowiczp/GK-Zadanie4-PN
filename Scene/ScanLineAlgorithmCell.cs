using GK_Zadanie4_PN.Objects;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Zadanie4_PN.Scene
{
    public class ScanLineAlgorithmCell
    {
        public int yMax;
        public double currentX;
        public double addX;

        public double currentZ;
        public double addZ;


        public double currentNormalX;
        public double currentNormalY;
        public double currentNormalZ;

        public double addNormalX;
        public double addNormalY;
        public double addNormalZ;

        public double currentWorldX;
        public double currentWorldY;
        public double currentWorldZ;

        public double addWorldX;
        public double addWorldY;
        public double addWorldZ;

        public double currentColorR;
        public double currentColorG;
        public double currentColorB;

        public double addColorR;
        public double addColorG;
        public double addColorB;
        //tylko dla przypadku linii rownoleglej
        public int maxX;

        public void AddValues()
        {
            currentX += addX;
            currentZ += addZ;

            currentNormalX += addNormalX;
            currentNormalY += addNormalY;
            currentNormalZ += addNormalZ;

            currentWorldX += addWorldX;
            currentWorldY += addWorldY;
            currentWorldZ += addWorldZ;

            currentColorR += addColorR;
            currentColorG += addColorG;
            currentColorB += addColorB;
        }

        public void Initialize(Vertice lower, Vertice higher, Vector<double> lowerPixelColor = null, Vector<double> higherPixelColor = null, bool geurad = false)
        {
            yMax = (int)higher.modelPosition[1, 0];
            currentX = lower.modelPosition[0, 0];
            double lenY = higher.modelPosition[1, 0] - lower.modelPosition[1, 0];
            addX = lenY == 0 ? 0 : (higher.modelPosition[0, 0] - lower.modelPosition[0, 0]) / lenY;
            currentZ = lower.modelPosition[2, 0];
            addZ = lenY == 0 ? 0 : (higher.modelPosition[2, 0] - lower.modelPosition[2, 0]) / lenY;
            maxX = (int)higher.modelPosition[0, 0];

            currentNormalX = lower.modelNormal[0];
            currentNormalY = lower.modelNormal[1];
            currentNormalZ = lower.modelNormal[2];

            addNormalX = lenY == 0 ? 0 : (higher.modelNormal[0] - lower.modelNormal[0]) / lenY;
            addNormalY = lenY == 0 ? 0 : (higher.modelNormal[1] - lower.modelNormal[1]) / lenY;
            addNormalZ = lenY == 0 ? 0 : (higher.modelNormal[2] - lower.modelNormal[2]) / lenY;

            currentWorldX = lower.worldPosition[0, 0];
            currentWorldY = lower.worldPosition[1,0];
            currentWorldZ = lower.worldPosition[2,0];

            addWorldX = lenY == 0 ? 0 : (higher.worldPosition[0, 0] - lower.worldPosition[0, 0]) / lenY;
            addWorldY = lenY == 0 ? 0 : (higher.worldPosition[1, 0] - lower.worldPosition[1, 0]) / lenY;
            addWorldZ = lenY == 0 ? 0 : (higher.worldPosition[2, 0] - lower.worldPosition[2, 0]) / lenY;

            if (geurad)
            {
                currentColorR = lowerPixelColor[0];
                currentColorG = lowerPixelColor[1];
                currentColorB = lowerPixelColor[2];

                addColorR = lenY == 0 ? 0 : (higherPixelColor[0] - lowerPixelColor[0]) / lenY;
                addColorG = lenY == 0 ? 0 : (higherPixelColor[1] - lowerPixelColor[1]) / lenY;
                addColorB = lenY == 0 ? 0 : (higherPixelColor[2] - lowerPixelColor[2]) / lenY;
            }
        }
    }
}
