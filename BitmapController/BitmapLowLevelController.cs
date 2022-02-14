using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;


namespace GK_Zadanie4_PN.BitmapController
{
    public class BitmapLowLevelController : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        public int BitCount { get; private set; }
        protected GCHandle BitsHandle { get; private set; }
        
        public BitmapLowLevelController(int width, int height)
        {
            Width = width;
            Height = height;
            BitCount = width * height;

            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void SetSinglePixel(int x, int y, Color colour)
        {
            if (x >= Width || y>=Height) return;
            if(x<=0 || y<=0) return;
            int index = x + (y * Width);
            int col = colour.ToArgb();

            if (index >= BitCount || index < 0) return;
            Bits[index] = col;
        }

        public Color GetSinglePixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }
        public void CleanBitmap()
        {
            Array.Clear(Bits, 0, Width * Height);
        }
        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
        
        public void DrawLine(Point point1, Point point2, Color color)
        {
            WriteLowLevelLine(point1, point2, color);
        }
        public void WriteLowLevelLine(Point begin, Point end, Color colour)
        {

            int x = begin.X, y = begin.Y, x2 = end.X, y2 = end.Y;
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }
            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                SetSinglePixel(x, y, colour);
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }
    }
}
