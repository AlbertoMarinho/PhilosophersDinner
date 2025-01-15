using System;
using System.Threading;

class Program
{
    // Constantes
    const int QUANT = 5; // Quantidade de filósofos
    const int PENSANDO = 0; // Estado de Pensando
    const int FAMINTO = 1;  // Estado de Faminto
    const int COMENDO = 2;  // Estado de Comendo

    // Arrays e variáveis globais
    static int[] estado = new int[QUANT]; // Estado dos filósofos
    static Mutex[] muxFilo = new Mutex[QUANT]; // Mutex para cada filósofo
    static Mutex mutex = new Mutex(); // Região crítica
    static Thread[] jantar = new Thread[QUANT]; // Threads dos filósofos

    // Função que simula o comportamento de um filósofo
    static void Filosofo(object obj)
    {
        int id = (int)obj; // Repassa o id do filósofo

        while (true)
        {
            Pensar(id); // Filósofo pensa
            PegarHashi(id); // Filósofo tenta pegar os hashis
            Comer(id); // Filósofo come
            DevolverHashi(id); // Filósofo devolve os hashis
        }
    }

    // Função que filósofo pega os hashis
    static void PegarHashi(int idFilosofo)
    {
        mutex.WaitOne(); // Entra na região crítica
        try
        {
            Console.WriteLine($"Filósofo {idFilosofo} está faminto");
            estado[idFilosofo] = FAMINTO; // Filósofo fica faminto
            Intencao(idFilosofo); // Intenção de pegar os hashis
        }
        finally
        {
            mutex.ReleaseMutex(); // Sai da região crítica
        }

        muxFilo[idFilosofo].WaitOne(); // Bloqueia o mutex do filósofo
    }

    // Função que filósofo devolve os hashis
    static void DevolverHashi(int idFilosofo)
    {
        mutex.WaitOne(); // Entra na região crítica

        Console.WriteLine($"Filósofo {idFilosofo} está pensando");
        estado[idFilosofo] = PENSANDO; // Filósofo termina de comer
        Intencao((idFilosofo + QUANT - 1) % QUANT); // Vê se o vizinho da esquerda pode comer
        Intencao((idFilosofo + 1) % QUANT); // Vê se o vizinho da direita pode comer

        mutex.ReleaseMutex(); // Sai da região crítica
    }

    // Função de intenção do filósofo em pegar os hashis
    static void Intencao(int idFilosofo)
    {
        

        muxFilo[idFilosofo].WaitOne();

        // Garantir que o filósofo só comerá se ambos os vizinhos não estiverem comendo
        if (estado[idFilosofo] == FAMINTO &&
            estado[(idFilosofo + QUANT - 1) % QUANT] != COMENDO &&
            estado[(idFilosofo + 1) % QUANT] != COMENDO)
        {
            Console.WriteLine($"Filósofo {idFilosofo} ganhou a vez de comer");
            estado[idFilosofo] = COMENDO; // Filósofo consegue comer

            muxFilo[idFilosofo].ReleaseMutex(); // Libera o mutex do filósofo
        }
    }

    // Função de pensar
    static void Pensar(int idFilosofo)
    {
        Random rand = new Random();
        int r = rand.Next(1, 11); // Gera um tempo aleatório entre 1 e 10 segundos
        Console.WriteLine($"Filósofo {idFilosofo} pensa por {r} segundos");
        Thread.Sleep(r * 1000); // Filósofo pensa por r segundos
    }

    // Função de comer
    static void Comer(int idFilosofo)
    {
        Random rand = new Random();
        int r = rand.Next(1, 6); // Gera um tempo aleatório entre 1 e 10 segundos
        Console.WriteLine($"Filósofo {idFilosofo} come por {r} segundos");
        Thread.Sleep(r * 1000); // Filósofo come por r segundos
    }

    static void Main(string[] args)
    {
        // Inicializa os mutexes dos filósofos
        for (int i = 0; i < QUANT; i++)
        {
            muxFilo[i] = new Mutex(); // Mutex para cada filósofo
        }

        // Cria as threads (filósofos)
        for (int i = 0; i < QUANT; i++)
        {
            int id = i; // Cria uma cópia local do id para cada thread
            jantar[i] = new Thread(new ParameterizedThreadStart(Filosofo));
            jantar[i].Start(id); // Inicia a thread do filósofo
        }

        // Espera todas as threads terminarem (o que, neste caso, nunca ocorrerá)
        foreach (Thread t in jantar)
        {
            t.Join();
        }
    }
}
