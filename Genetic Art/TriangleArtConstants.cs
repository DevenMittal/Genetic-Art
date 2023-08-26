using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Art
{
    public static class Constants
    {
        public static double MutateColor = 0.5;
        public static double MutatePoint = 0.5;
        
        public static double MaxColorVariance = 20;
        public static double MaxPointVariance = 10;

        public static Vector2 MaxPointPosition = new Vector2(0.2f, 0.2f);

        public static int RandRGBMax = 255;
        public static int RandAMax = 225;


        public static float addChance = 0.2f;
        public static float mutateChance = 0.7f;
        public static float removeChance = 0.1f;

        public static int maxTriangles = 400;

    }
}
