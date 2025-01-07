namespace PhilosophersDinner
{
    public partial class DrawingPanel
    {
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
