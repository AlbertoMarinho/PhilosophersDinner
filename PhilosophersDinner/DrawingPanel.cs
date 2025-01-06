namespace PhilosophersDinner
{
    public partial class DrawingPanel
    {
        public DrawingPanel()
        {
            InitializeComponent();

            // Adicionar evento ao botão
            StartButton.Click += StartButton_Click;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Criar a nova tela (PhilosopherDinnerForm)
            PhilosopherDinnerForm dinnerForm = new PhilosopherDinnerForm{
                StartPosition = FormStartPosition.Manual,
                Location = this.Location,
                Size = this.Size
            };

            // Exibir a nova tela como modal
            dinnerForm.ShowDialog();

            // Fechar a janela atual após o retorno da nova tela
            this.Close();
        }
    }
}
