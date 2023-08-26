using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_Art
{
    internal class GeneticArtTrainer
    {
        TriangleArt[] population;
        public double bestError = double.MaxValue;
        public GeneticArtTrainer(Bitmap orignalImage, int maxTriangles, int populationSize)
        {
            population= new TriangleArt[populationSize];
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = new TriangleArt(maxTriangles, orignalImage);
            }
        }

        public double Train(Random random)
        {
            int currentIndex = 0;
            for (int i = 1; i < population.Length; i++)
            {
                population[0].CopyTo(population[i]);
                population[i].Mutate(random);
                double currentError = population[i].GetError();
                if (bestError> currentError)
                {
                    bestError = currentError;
                    currentIndex = i;
                } 
            }
            double firstError = population[0].GetError();
            if (bestError < firstError)
            {
                var temp = population[0];
                population[0] = population[currentIndex];
                population[currentIndex] = temp;
                return bestError;
            }
            return firstError;
        }

        public Bitmap GetBestImage(int x, int y)
        {
            return population[0].DrawImage(x, y);
        }
        public Bitmap GetImage(int x, int y, int index)
        {
            return population[index].DrawImage(x, y);
        }


    }
}
