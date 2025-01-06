﻿namespace PhilosophersDinner
{
    partial class DrawingPanel : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Label TitleLabel;
        private Button StartButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            TitleLabel.Font = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point);
            TitleLabel.Text = "Jantar dos Filósofos";
            TitleLabel.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // StartButton
            // 
            StartButton.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            StartButton.Text = "Iniciar";
            StartButton.Size = new Size(100, 40); // Tamanho fixo

            // 
            // DrawingPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            // Definir tamanho do formulário como 70% da largura e 60% da altura da tela
            var screenWidth = Screen.PrimaryScreen.Bounds.Width;
            var screenHeight = Screen.PrimaryScreen.Bounds.Height;
            ClientSize = new Size((int)(screenWidth * 0.7), (int)(screenHeight * 0.6));

            // Adicionar controles
            Controls.Add(StartButton);
            Controls.Add(TitleLabel);

            Name = "DrawingPanel";
            Text = "Jantar dos Filósofos";

            // Centralizar controles inicialmente
            CenterControls();

            // Redefinir posições ao redimensionar o formulário
            Resize += (sender, e) => CenterControls();

            ResumeLayout(false);
            PerformLayout();
        }

        private void CenterControls()
        {
            // Centralizar título
            TitleLabel.Location = new Point((ClientSize.Width - TitleLabel.Width) / 2, 20);

            // Centralizar botão na parte inferior
            StartButton.Location = new Point((ClientSize.Width - StartButton.Width) / 2, ClientSize.Height - StartButton.Height - 20);
        }
    }
}
