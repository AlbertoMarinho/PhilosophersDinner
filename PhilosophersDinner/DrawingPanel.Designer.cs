namespace PhilosophersDinner
{
    partial class DrawingPanel
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TitleLabel = new Label();
            StartButton = new Button();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.BackColor = Color.Transparent;
            TitleLabel.Dock = DockStyle.Top;
            TitleLabel.Font = new Font("Arial", 20F, FontStyle.Bold);
            TitleLabel.Location = new Point((this.ClientSize.Width - TitleLabel.Width) / 2, this.ClientSize.Height / 4);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(284, 32);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Jantar dos Filósofos";
            TitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StartButton
            // 
            StartButton.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartButton.Location = new Point(326, 409);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(95, 37);
            StartButton.TabIndex = 1;
            StartButton.Text = "Iniciar";
            StartButton.UseVisualStyleBackColor = true;
            // 
            // DrawingPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(StartButton);
            Controls.Add(TitleLabel);
            Name = "DrawingPanel";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label TitleLabel;
        private Button StartButton;
    }
}
