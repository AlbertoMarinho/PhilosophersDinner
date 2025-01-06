namespace PhilosophersDinner
{
    partial class PhilosopherDinnerForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label infoLabel;

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
            this.infoLabel = new Label();
            this.SuspendLayout();

            // 
            // infoLabel
            // 
            this.infoLabel.Text = "Tela do Jantar dos Filósofos";
            this.infoLabel.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.infoLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.infoLabel.Dock = DockStyle.Fill;

            // 
            // PhilosopherDinnerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            // Definir tamanho do formulário como 70% da largura e 60% da altura da tela
            var screenWidth = Screen.PrimaryScreen.Bounds.Width;
            var screenHeight = Screen.PrimaryScreen.Bounds.Height;
            ClientSize = new Size((int)(screenWidth * 0.7), (int)(screenHeight * 0.6));

            Name = "PhilosopherDinnerForm";
            Text = "Jantar dos Filósofos - Simulação";

            // Adicionar o rótulo ao formulário
            Controls.Add(this.infoLabel);

            ResumeLayout(false);
        }
    }
}
