namespace PhilosophersDinner
{
    public partial class PhilosopherDinnerForm : Form
    {
        private const int NUM_FILOSOFOS = 5;
        private readonly Brush[] estadoCores = new Brush[]
        {
            Brushes.Blue, // Aguardando
            Brushes.Red,  // Faminto
            Brushes.Green // Comendo
        };

        public PhilosopherDinnerForm()
        {
            InitializeComponent();
            PhilosophersLogic.EstadoAlterado += (filosofoId, novoEstado) =>
            {
                // Garantir que a UI seja atualizada na thread correta
                if (InvokeRequired)
                {
                    Invoke(new Action(() => Invalidate()));
                }
                else
                {
                    Invalidate();
                }
            };
        }

        private void PhilosopherDinnerForm_Shown(object sender, EventArgs e)
        {
            PhilosophersLogic.Execute(); // Chama Execute após a montagem do formulário
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawPhilosophers(e.Graphics);
        }

        private void DrawPhilosophers(Graphics g)
        {
            float centerX = ClientSize.Width / 2;
            float centerY = ClientSize.Height / 2;
            float radius = Math.Min(ClientSize.Width, ClientSize.Height) * 0.3f; // Ajustar o tamanho com base na tela
            float angleStep = 360.0f / NUM_FILOSOFOS;

            // Define o tamanho da bola com base no tamanho da tela
            float ballSize = Math.Min(ClientSize.Width, ClientSize.Height) * 0.1f; // Ajuste para o tamanho da bola

            for (int i = 0; i < NUM_FILOSOFOS; i++)
            {
                float angle = i * angleStep;
                float x = centerX + radius * (float)Math.Cos(angle * Math.PI / 180);
                float y = centerY + radius * (float)Math.Sin(angle * Math.PI / 180);

                // Desenhar círculo representando o filósofo com borda preta
                g.FillEllipse(estadoCores[GetEstadoIndex(PhilosophersLogic.Estados[i])], x - ballSize / 2, y - ballSize / 2, ballSize, ballSize);
                g.DrawEllipse(Pens.Black, x - ballSize / 2, y - ballSize / 2, ballSize, ballSize); // Borda preta

                // Adicionar nome do filósofo e estado
                string nomeFilosofo = $"Filósofo {i + 1}";
                g.DrawString(nomeFilosofo, this.Font, Brushes.Black, x - ballSize / 2, y - ballSize / 2 - 20);
                g.DrawString(PhilosophersLogic.Estados[i], this.Font, Brushes.Black, x - ballSize / 2, y + ballSize / 2 + 5);
            }
        }

        private int GetEstadoIndex(string estado)
        {
            switch (estado)
            {
                case "Aguardando":
                    return 0;
                case "Faminto":
                    return 1;
                case "Comendo":
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
