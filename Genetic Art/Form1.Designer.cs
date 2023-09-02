namespace Genetic_Art
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Original = new System.Windows.Forms.PictureBox();
            this.doButton = new System.Windows.Forms.Button();
            this.iLabel = new System.Windows.Forms.Label();
            this.OutputPanel = new System.Windows.Forms.Panel();
            this.bestLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Original)).BeginInit();
            this.SuspendLayout();
            // 
            // Original
            // 
            this.Original.Image = ((System.Drawing.Image)(resources.GetObject("Original.Image")));
            this.Original.Location = new System.Drawing.Point(12, 12);
            this.Original.Name = "Original";
            this.Original.Size = new System.Drawing.Size(100, 100);
            this.Original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Original.TabIndex = 0;
            this.Original.TabStop = false;
            // 
            // doButton
            // 
            this.doButton.Location = new System.Drawing.Point(1683, 12);
            this.doButton.Name = "doButton";
            this.doButton.Size = new System.Drawing.Size(75, 23);
            this.doButton.TabIndex = 2;
            this.doButton.Text = "Do";
            this.doButton.UseVisualStyleBackColor = true;
            this.doButton.Click += new System.EventHandler(this.doButton_Click);
            // 
            // iLabel
            // 
            this.iLabel.AutoSize = true;
            this.iLabel.Location = new System.Drawing.Point(1745, 48);
            this.iLabel.Name = "iLabel";
            this.iLabel.Size = new System.Drawing.Size(13, 15);
            this.iLabel.TabIndex = 3;
            this.iLabel.Text = "0";
            // 
            // OutputPanel
            // 
            this.OutputPanel.Location = new System.Drawing.Point(167, 12);
            this.OutputPanel.Name = "OutputPanel";
            this.OutputPanel.Size = new System.Drawing.Size(1510, 828);
            this.OutputPanel.TabIndex = 13;
            // 
            // bestLabel
            // 
            this.bestLabel.AutoSize = true;
            this.bestLabel.Location = new System.Drawing.Point(1704, 133);
            this.bestLabel.Name = "bestLabel";
            this.bestLabel.Size = new System.Drawing.Size(13, 15);
            this.bestLabel.TabIndex = 14;
            this.bestLabel.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1770, 852);
            this.Controls.Add(this.bestLabel);
            this.Controls.Add(this.iLabel);
            this.Controls.Add(this.doButton);
            this.Controls.Add(this.Original);
            this.Controls.Add(this.OutputPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Original)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox Original;
        private Button doButton;
        private Label iLabel;
        private Panel OutputPanel;
        private Label bestLabel;
    }
}
