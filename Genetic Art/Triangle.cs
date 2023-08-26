using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Art
{
    internal class Triangle
    {
        public Color color;
        public PointF[] points;
        public Triangle(PointF point0, PointF point1, PointF point2, Color color) 
        {
            points= new PointF[3];
            points[0] = point0;
            points[1] = point1;
            points[2] = point2;
            this.color = color;
        }

        public void DrawTriangle(Graphics gfx, float xCoefficent, float yCoefficent)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[0].X *= xCoefficent;
                points[0].Y *= yCoefficent;
            }
            gfx.FillPolygon(new SolidBrush(color), points);
        }

        public void Mutate(Random random)
        {
            double num = random.NextDouble();
            if (num > Constants.MutatePoint && num >= 0)
            {
                double aColor = random.NextDouble();
                int colorVariance = random.Next(-(int)Constants.MaxColorVariance, (int)Constants.MaxColorVariance + 1);
                if (aColor > 0 && aColor < 0.25)
                {
                    color = Color.FromArgb(color.A+colorVariance, color.R, color.G, color.B);
                }
                else if(aColor < 0.5)
                {
                    color = Color.FromArgb(color.A, color.R + colorVariance, color.G, color.B);
                }
                else if (aColor < 0.75)
                {
                    color = Color.FromArgb(color.A, color.R, color.G + colorVariance, color.B);
                }
                else if (aColor < 1)
                {
                    color = Color.FromArgb(color.A, color.R, color.G, color.B + colorVariance);
                }
            }
            else
            {
                double aPoint = random.NextDouble();
                int XorY = random.Next(0, 2);
                int pointVariance = random.Next(-(int)Constants.MaxPointVariance, (int)Constants.MaxPointVariance + 1);
                if (aPoint > 0 && aPoint < 0.33)
                {
                    if (XorY == 0) points[0].X += pointVariance;
                    if (XorY == 0) points[0].Y += pointVariance;
                }
                else if (aPoint < 0.66)
                {
                    if (XorY == 0) points[0].X += pointVariance;
                    if (XorY == 0) points[0].Y += pointVariance;
                }
                else if (aPoint < 1)
                {
                    if (XorY == 0) points[0].X += pointVariance;
                    if (XorY == 0) points[0].Y += pointVariance;
                }                
            }
        }

        public Triangle Copy()
        {
            return new Triangle(points[0], points[1], points[2], color);
        }

        public static Triangle RandomTriangle(Random random)
        {
            return new Triangle(new PointF((float)(random.NextDouble() * Constants.MaxPointPosition.X),
                                          (float)random.NextDouble() * Constants.MaxPointPosition.Y),
                                new PointF((float)(random.NextDouble() * Constants.MaxPointPosition.X),
                                          (float)random.NextDouble() * Constants.MaxPointPosition.Y), 
                                new PointF((float)(random.NextDouble() * Constants.MaxPointPosition.X),
                                          (float)random.NextDouble() * Constants.MaxPointPosition.Y),
                                           Color.FromArgb(random.Next(30, Constants.RandAMax + 1),
                                                          random.Next(0, Constants.RandRGBMax + 1),
                                                          random.Next(0, Constants.RandRGBMax + 1),
                                                          random.Next(0, Constants.RandRGBMax + 1)));
        }






    }
}
