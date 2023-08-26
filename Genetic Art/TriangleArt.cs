using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            triangles= new List<Triangle>();
            triangles.Add(Triangle.RandomTriangle(new Random()));
        }

        public void Mutate(Random random)
        {
            double aColor = random.NextDouble();
            if (aColor > 0 && aColor < Constants.removeChance)
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
                other.triangles.Add(triangles[i]);
            }
        }
        public double GetError()
        {
            Bitmap Map = DrawImage(originalImage.Width, originalImage.Height);
            double currentError = 0;
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
            return currentError / (originalImage.Width * originalImage.Height);
        }
    }
}
