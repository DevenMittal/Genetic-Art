namespace Genetic_Art
{
    using System.Drawing.Imaging;

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Any(argument => argument.Equals("--export", StringComparison.OrdinalIgnoreCase)))
            {
                ExportCheckpoints();
                return;
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static void ExportCheckpoints()
        {
            string outputDirectory = Path.Combine(AppContext.BaseDirectory, "checkpoints");
            Directory.CreateDirectory(outputDirectory);
            using Bitmap original = new Bitmap((Bitmap)Properties.Resources.ResourceManager.GetObject("Original.Image")!);
            GeneticArtTrainer trainer = new GeneticArtTrainer(original, Constants.maxTriangles, 8, new Random(20261101));
            int[] checkpoints = { 0, 25, 100, 250, 500, 1000 };
            int completed = 0;
            foreach (int checkpoint in checkpoints)
            {
                while (completed < checkpoint)
                {
                    trainer.Train(new Random(20261101 + completed));
                    completed++;
                }
                using Bitmap image = trainer.GetBestImage(original.Width, original.Height);
                image.Save(Path.Combine(outputDirectory, $"generation-{checkpoint:D4}.png"), ImageFormat.Png);
                File.AppendAllText(Path.Combine(outputDirectory, "metrics.csv"), $"{checkpoint},{trainer.bestError}{Environment.NewLine}");
            }
        }
    }
}
