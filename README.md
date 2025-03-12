# PhilosophersDinner

**PhilosophersDinner** é um projeto desenvolvido para resolver o problema clássico do *Jantar dos Filósofos*, proposto na disciplina de Sistemas Operacionais. O objetivo do projeto é implementar uma solução que utilize **threads, mutex e semáforos**, garantindo a sincronização correta entre os filósofos. Além disso, o programa conta com uma **interface gráfica** para visualizar o estado de cada filósofo, indicando se ele está **comendo, esperando ou faminto**.

O problema do *Jantar dos Filósofos* envolve cinco pensadores sentados ao redor de uma mesa, onde cada um possui um prato e compartilha os garfos com seus vizinhos. Para que um filósofo possa comer, ele precisa segurar os dois garfos ao lado do seu prato, o que pode impedir que seus vizinhos façam o mesmo. Esse cenário exige um controle eficiente da concorrência para evitar condições como *deadlock* e *starvation*, garantindo que todos os filósofos tenham a oportunidade de se alimentar adequadamente.

Este projeto busca ilustrar, de forma prática e visual, como mecanismos de sincronização podem ser aplicados para resolver problemas concorrentes em sistemas computacionais.
