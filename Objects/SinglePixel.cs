using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK_Zadanie4_PN.Objects
{
    public class SinglePixel
    {
        public SinglePixel((double x, double y, double z) screenCoordinates,(double X, double Y, double Z) worldCoordinates ,(double normalX, double normalY, double normalZ) normalCoordinates, Color color)
        {
            X = screenCoordinates.x; Y = screenCoordinates.y; Z = screenCoordinates.z; 
            R = color.R; G = color.G; B = color.B;
            NormalX = normalCoordinates.normalX;
            NormalY = normalCoordinates.normalY;  
            NormalZ = normalCoordinates.normalZ;
            WorldX = worldCoordinates.X;
            WorldY = worldCoordinates.Y;
            WorldZ = worldCoordinates.Z;
        }

        public SinglePixel((double x, double y, double z) screenCoordinates, (double X, double Y, double Z) worldCoordinates, (double normalX, double normalY, double normalZ) normalCoordinates, double colorR, double colorG, double colorB)
        {
            X = screenCoordinates.x; Y = screenCoordinates.y; Z = screenCoordinates.z;
            R = colorR; G = colorG; B = colorB;
            NormalX = normalCoordinates.normalX;
            NormalY = normalCoordinates.normalY;
            NormalZ = normalCoordinates.normalZ;
            WorldX = worldCoordinates.X;
            WorldY = worldCoordinates.Y;
            WorldZ = worldCoordinates.Z;
        }

        public Color GetColor()
        {
            return Color.FromArgb((int)R,(int) G,(int) B);
        }
        public double GetColorFromVector(int i)
        {
            if (i == 0) return R;
            if( i ==1 )return G;
            if( i == 2 )return B;
            return -1;
        }
        public double R;
        public double G;
        public double B;

        public double X;
        public double Y;
        public double Z;

        public double WorldX;
        public double WorldY;
        public double WorldZ;

        public double NormalX;
        public double NormalY;
        public double NormalZ;  
    }
}
