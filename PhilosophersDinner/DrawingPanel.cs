namespace PhilosophersDinner
{
    public partial class DrawingPanel
    {
        private void StartButton_Click(object sender, EventArgs e)
        {
            // Ocultar a tela atual
            this.Hide();

            // Criar a nova tela (PhilosopherDinnerForm)
            PhilosopherDinnerForm dinnerForm = new PhilosopherDinnerForm
            {
                StartPosition = FormStartPosition.Manual,
                Location = this.Location,
                Size = this.Size
            };

            // Exibir a nova tela
            dinnerForm.ShowDialog(); // Use Show() para não bloquear a tela atual

            // Quando a segunda tela for fechada, fechar a primeira tela também
            this.Close();
        }

    }
}
