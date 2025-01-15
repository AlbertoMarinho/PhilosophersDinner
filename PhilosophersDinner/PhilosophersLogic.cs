namespace PhilosophersDinner
{
    class PhilosophersLogic
    {
        private const int NUM_FILOSOFOS = 5;
        private static Semaphore semaforo = new Semaphore(2, 2); // Apenas 2 filósofos podem comer simultaneamente
        private static object[] garfos = new object[NUM_FILOSOFOS]; // Controle dos garfos
        private static string[] estados = new string[NUM_FILOSOFOS]; // Estados dos filósofos
        private const int TEMPO_AGUARDANDO = 6000; // Tempo que o filósofo pensa antes de ficar faminto (ms)
        private const int TEMPO_COMENDO = 5000;   // Tempo que o filósofo leva para comer (ms)
        public static event Action<int, string> EstadoAlterado;

        public static string[] Estados
        {
            get
            {
                return (string[])estados.Clone(); // Retorna uma cópia para não permitir alterações diretas
            }
        }

        public static void Execute()
        {
            // Inicializa os garfos e estados
            for (int i = 0; i < NUM_FILOSOFOS; i++)
            {
                garfos[i] = new object();
                estados[i] = "Aguardando";
            }

            // Inicializa o estado de dois filósofos como comendo
            estados[0] = "Comendo";
            estados[3] = "Comendo";

            // Cria e inicia threads para os filósofos
            Thread[] filosofos = new Thread[NUM_FILOSOFOS];
            for (int i = 0; i < NUM_FILOSOFOS; i++)
            {
                int filosofoId = i; // Necessário para capturar o índice corretamente
                filosofos[i] = new Thread(() => CicloFilosofo(filosofoId));
                filosofos[i].IsBackground = true;
                filosofos[i].Start();
            }

            // Aguarda threads terminarem (não acontece devido ao loop infinito)
            //foreach (Thread filosofo in filosofos)
            //{
            //    filosofo.Join();
            //}
        }

        private static void CicloFilosofo(int filosofoId)
        {
            while (true)
            {
                switch (estados[filosofoId])
                {
                    case "Aguardando":
                        Thread.Sleep(TEMPO_AGUARDANDO); // Simula tempo aguardando
                        AtualizarEstado(filosofoId, "Faminto");
                        break;

                    case "Faminto":
                        TentarComer(filosofoId);
                        break;

                    case "Comendo":
                        Thread.Sleep(TEMPO_COMENDO); // Simula tempo comendo
                        AtualizarEstado(filosofoId, "Aguardando");
                        break;
                }
            }
        }

        private static void TentarComer(int filosofoId)
        {
            semaforo.WaitOne(); // Aguarda permissão para comer
            lock (garfos[filosofoId]) // Pega o garfo esquerdo
            {
                lock (garfos[(filosofoId + 1) % NUM_FILOSOFOS]) // Pega o garfo direito
                {
                    AtualizarEstado(filosofoId, "Comendo");
                    Thread.Sleep(TEMPO_COMENDO); // Simula tempo comendo
                    AtualizarEstado(filosofoId, "Aguardando");
                }
            }
            semaforo.Release(); // Libera o semáforo para outro filósofo
        }

        private static void AtualizarEstado(int filosofoId, string novoEstado)
        {
            estados[filosofoId] = novoEstado;
            // Verifique se a UI thread é válida e, se necessário, invoque a atualização
            EstadoAlterado?.Invoke(filosofoId, novoEstado); // Notifica a interface sobre a mudança
        }
    }
}
