using System;

namespace Pratica4
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxMin maxMin = new MaxMin();

            const int tamanho = 1000;

            int[] crescente = new int[tamanho];
            int[] decrescente = new int[tamanho];
            int[] aleatorio = new int[tamanho];

            // Preenchendo crescente
            for (int i = 0; i < tamanho; i++)
                crescente[i] = i;

            // Preenchendo decrescente
            for (int i = 0; i < tamanho; i++)
                decrescente[i] = tamanho - i;

            // Preenchendo aleatório
            Random rnd = new Random();
            for (int i = 0; i < tamanho; i++)
                aleatorio[i] = rnd.Next(0, 5000);

            // ---------- Execuções ----------

            Executar(maxMin, crescente, "Crescente");
            Executar(maxMin, decrescente, "Decrescente");
            Executar(maxMin, aleatorio, "Aleatória");

            Console.WriteLine("\nFinalizado! Pressione qualquer tecla...");
            Console.ReadKey();
        }


        static void Executar(MaxMin m, int[] vetor, string nome)
        {
            Console.WriteLine($"\nem ordem {nome}");

            m.Metodo1(vetor, out _, out _);
            Console.WriteLine($"Método 1: {m.ComparacoesMetodo1} comparações");

            m.Metodo2(vetor, out _, out _);
            Console.WriteLine($"Método 2: {m.ComparacoesMetodo2} comparações");

            m.Metodo3(vetor, out _, out _);
            Console.WriteLine($"Método 3: {m.ComparacoesMetodo3} comparações");
        }
    }
}
