using System;

namespace Pratica4
{
    public class MaxMin
    {
        public int ComparacoesMetodo1 { get; private set; }
        public int ComparacoesMetodo2 { get; private set; }
        public int ComparacoesMetodo3 { get; private set; }

        // ---------------- MÉTODO 1 ----------------
        public void Metodo1(int[] vetor, out int menor, out int maior)
        {
            ComparacoesMetodo1 = 0;

            menor = vetor[0];
            maior = vetor[0];

            for (int i = 1; i < vetor.Length; i++)
            {
                ComparacoesMetodo1++;
                if (vetor[i] < menor)
                {
                    menor = vetor[i];
                }

                ComparacoesMetodo1++;
                if (vetor[i] > maior)
                {
                    maior = vetor[i];
                }
            }
        }

        // ---------------- MÉTODO 2 ----------------
        public void Metodo2(int[] vetor, out int menor, out int maior)
        {
            ComparacoesMetodo2 = 0;

            menor = vetor[0];
            maior = vetor[0];

            for (int i = 1; i < vetor.Length; i++)
            {
                ComparacoesMetodo2++;
                if (vetor[i] < menor)
                {
                    menor = vetor[i];
                }
                else
                {
                    ComparacoesMetodo2++;
                    if (vetor[i] > maior)
                    {
                        maior = vetor[i];
                    }
                }
            }
        }

        // ---------------- MÉTODO 3 ----------------
        // Comparações em pares (melhor desempenho)
        public void Metodo3(int[] vetor, out int menor, out int maior)
        {
            ComparacoesMetodo3 = 0;

            int inicio;
            if (vetor.Length % 2 == 0)
            {
                ComparacoesMetodo3++;
                ComparacoesMetodo3++;
                if (vetor[0] < vetor[1])
                {
                    menor = vetor[0];
                    maior = vetor[1];
                }
                else
                {
                    menor = vetor[1];
                    maior = vetor[0];
                }
                inicio = 2;
            }
            else
            {
                menor = maior = vetor[0];
                inicio = 1;
            }

            for (int i = inicio; i < vetor.Length - 1; i += 2)
            {
                ComparacoesMetodo3++;
                if (vetor[i] < vetor[i + 1])
                {
                    ComparacoesMetodo3++;
                    if (vetor[i] < menor) menor = vetor[i];
                    ComparacoesMetodo3++;
                    if (vetor[i + 1] > maior) maior = vetor[i + 1];
                }
                else
                {
                    ComparacoesMetodo3++;
                    if (vetor[i + 1] < menor) menor = vetor[i + 1];
                    ComparacoesMetodo3++;
                    if (vetor[i] > maior) maior = vetor[i];
                }
            }
        }
    }
}
