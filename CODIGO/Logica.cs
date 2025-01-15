using System;
using System.Threading;

class Program
{
    // Número de filósofos
    const int NUM_FILOSOFOS = 5;

    // Semáforo para garantir que no máximo 4 filósofos possam tentar comer ao mesmo tempo
    static Semaphore semaforo = new Semaphore(NUM_FILOSOFOS - 1, NUM_FILOSOFOS - 1);

    // Mutex para proteger o acesso ao garfo
    static Mutex[] mutex = new Mutex[NUM_FILOSOFOS];

    // Definindo os estados
    const int PENSANDO = 0;
    const int FAMINTO = 1;
    const int COMENDO = 2;

    // Estado de cada filósofo
    static int[] estado = new int[NUM_FILOSOFOS];

    // Função que simula o comportamento de um filósofo
    static void Comer(int filosofoId)
    {
        while (true)
        {
            // Filósofo pensa
            Pensar(filosofoId);

            // Filósofo fica faminto
            FicarFaminto(filosofoId);

            // Filósofo tenta pegar os garfos
            semaforo.WaitOne();  // Aguardando para tentar comer

            // Só deixa dois filósofos comerem simultaneamente se não forem vizinhos
            if (PodeComerJuntos(filosofoId))
            {
                // Tenta pegar o garfo esquerdo
                mutex[filosofoId].WaitOne();
                // Tenta pegar o garfo direito (com verificação de vizinhos)
                mutex[(filosofoId + 1) % NUM_FILOSOFOS].WaitOne();

                // Alterando o estado para COMENDO
                estado[filosofoId] = COMENDO;
                Console.WriteLine($"Filósofo {filosofoId} está comendo...");

                // Simula o tempo que o filósofo leva para comer
                Thread.Sleep(2000);

                // Devolve os garfos após comer
                mutex[(filosofoId + 1) % NUM_FILOSOFOS].ReleaseMutex();
                mutex[filosofoId].ReleaseMutex();

                // Alterando o estado para PENSANDO
                estado[filosofoId] = PENSANDO;
                Console.WriteLine($"Filósofo {filosofoId} terminou de comer.");
            }
            else
            {
                Console.WriteLine($"Filósofo {filosofoId} não pode comer agora.");
            }

            // Filósofo pensa por um tempo antes de tentar pegar os garfos novamente
            Thread.Sleep(1000);
            semaforo.Release();  // Liberando para outro filósofo tentar comer
        }
    }

    // Função que verifica se o filósofo pode comer com outro (não vizinho)
    static bool PodeComerJuntos(int filosofoId)
    {
        int[] combinacoes = new int[] {
            0, 2, 0,3, 1, 3, 1, 4, 2, 0, 2,4,3,0,3,1,4,1,4,2 
        };

        for (int i = 0; i < combinacoes.Length; i += 2)
        {
            if (filosofoId == combinacoes[i] && combinacoes[i + 1] < estado.Length && estado[combinacoes[i + 1]] == FAMINTO)
            {
                return true;
            }
        }

        return false;
    }

    // Função que simula o filósofo pensando
    static void Pensar(int filosofoId)
    {
        estado[filosofoId] = PENSANDO;
        Console.WriteLine($"Filósofo {filosofoId} está pensando...");
        Thread.Sleep(1000); // Simula o tempo que o filósofo gasta pensando
    }

    // Função que simula o filósofo ficando faminto
    static void FicarFaminto(int filosofoId)
    {
        estado[filosofoId] = FAMINTO;
        Console.WriteLine($"Filósofo {filosofoId} está faminto...");
    }

    static void Main(string[] args)
    {
        // Inicializa os Mutexes para cada filósofo e os garfos
        for (int i = 0; i < NUM_FILOSOFOS; i++)
        {
            mutex[i] = new Mutex();
            estado[i] = PENSANDO; // Inicia todos os filósofos como pensando
        }

        // Cria threads para os filósofos
        Thread[] threads = new Thread[NUM_FILOSOFOS];
        for (int i = 0; i < NUM_FILOSOFOS; i++)
        {
            int id = i; // Cópia local do id para a thread
            threads[i] = new Thread(() => Comer(id));
            threads[i].Start();
        }

        // Aguarda todas as threads terminarem (o que não vai acontecer devido ao loop infinito)
        foreach (var t in threads)
        {
            t.Join();
        }
    }
}
