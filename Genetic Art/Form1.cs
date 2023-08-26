namespace Genetic_Art
{
    public partial class Form1 : Form
    {
        GeneticArtTrainer moira;
        Random random = new Random();
        Bitmap Image;
        public Form1()
        {
            InitializeComponent();
            Image = new Bitmap(Original.Image);

            for (int x = 0; x < OutputPanel.Width; x++)
            {
                if (x % Original.Width == 0 && OutputPanel.Width - x >= Original.Width)
                {
                    for (int y = 0; y < OutputPanel.Height; y++)
                    {
                        if (y % Original.Height == 0 && OutputPanel.Height - y >= Original.Height)
                        {
                            PictureBox picturebox = new PictureBox();
                            picturebox.Size = Original.Size;
                            picturebox.Location = new Point(x, y);

                            OutputPanel.Controls.Add(picturebox);
                        }
                    }
                }
            }

            moira = new GeneticArtTrainer(Image, Constants.maxTriangles, OutputPanel.Controls.Count);
        }

        private void doButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                iLabel.Text = i.ToString();
                iLabel.Update();

                moira.Train(random);

                bestLabel.Text = moira.bestError.ToString();
                bestLabel.Update();

                for (int j = 0; j < OutputPanel.Controls.Count; j++)
                {
                    PictureBox box = (PictureBox)OutputPanel.Controls[j];

                    box.Image = moira.GetImage(Original.Image.Width, Original.Image.Height, j);
                    box.Update();
                }
            }
        }
    }
}