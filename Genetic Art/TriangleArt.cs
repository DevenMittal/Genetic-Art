using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Genetic_Art
{
    internal class TriangleArt
    {
        int maxTriangles;
        List<Triangle> triangles;
        Bitmap originalImage;
        public TriangleArt(int maxTriangles, Bitmap originalImage)
        {
            this.maxTriangles = maxTriangles;
            this.originalImage = originalImage;
            triangles = new List<Triangle>();
            triangles.Add(Triangle.RandomTriangle(new Random()));
        }
        public TriangleArt()
        {
            this.maxTriangles = Constants.maxTriangles;
            triangles = new List<Triangle>();
            triangles.Add(Triangle.RandomTriangle(new Random()));
        }

        public void Mutate(Random random)
        {
            
            double aColor = random.NextDouble();
            if (aColor > 0 && aColor < Constants.addChance)
            {
                triangles.Add(Triangle.RandomTriangle(random));
                if (triangles.Count > maxTriangles)
                {
                    triangles.Remove(triangles[0]);
                }
            }
            else if (aColor < Constants.addChance+Constants.removeChance)
            {
                int randIndex = random.Next(0, triangles.Count);
                triangles.Remove(triangles[randIndex]);
            }
            else
            {
                int randIndex = random.Next(0, triangles.Count);
                triangles[randIndex].Mutate(random);
                if (triangles[randIndex].color.A == 0)
                {
                    triangles.Remove(triangles[randIndex]);
                }
            }
        }
        public Bitmap DrawImage(int width, int height)
        {
            var GaryB = new Bitmap(width, height);

            Graphics gfx = Graphics.FromImage(GaryB);

            for (int i = 0; i < triangles.Count; i++)
            {
                triangles[i].DrawTriangle(gfx, width, height);
            }
            return GaryB;

        }
        public void CopyTo(TriangleArt other)
        {
            other.triangles.Clear();
            for (int i = 0; i < triangles.Count; i++)
            {
                other.triangles.Add(triangles[i].Copy());
            }
        }
        public double GetError()
        {
            Bitmap Map = DrawImage(originalImage.Width, originalImage.Height);

            Rectangle rect1 = new Rectangle(0, 0, Map.Width, Map.Height);
            Rectangle rect2 = new Rectangle(0, 0, originalImage.Width, originalImage.Height);

            BitmapData MapData1 = Map.LockBits(rect1, ImageLockMode.ReadOnly, Map.PixelFormat);
            BitmapData MapData2 = originalImage.LockBits(rect2, ImageLockMode.ReadOnly, originalImage.PixelFormat);

            IntPtr ptr1 = MapData1.Scan0;
            IntPtr ptr2 = MapData2.Scan0;

            int bytes1 = Math.Abs(MapData1.Stride) * Map.Height;
            int bytes2 = Math.Abs(MapData2.Stride) * originalImage.Height;

            byte[] rgbValues1 = new byte[bytes1];
            byte[] rgbValues2 = new byte[bytes2];

            Marshal.Copy(ptr1, rgbValues1, 0, bytes1);
            Marshal.Copy(ptr2, rgbValues2, 0, bytes2);

            double currentError = 0;

            for (int i = 0; i < rgbValues1.Length; i++)
            {
                int difference = (rgbValues2[i] - rgbValues1[i]);
                currentError += difference*difference;
            }

            originalImage.UnlockBits(MapData2);

            return currentError / (originalImage.Width * originalImage.Height);

            /*
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    currentError += Math.Pow(originalImage.GetPixel(x, y).A - Map.GetPixel(x, y).A, 2);
                    currentError += Math.Pow(originalImage.GetPixel(x, y).R - Map.GetPixel(x, y).R, 2);
                    currentError += Math.Pow(originalImage.GetPixel(x, y).G - Map.GetPixel(x, y).G, 2);
                    currentError += Math.Pow(originalImage.GetPixel(x, y).B - Map.GetPixel(x, y).B, 2);
                }
            }
            */
        }
    }
}
