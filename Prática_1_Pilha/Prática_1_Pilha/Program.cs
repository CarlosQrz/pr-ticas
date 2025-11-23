using System;

class Pilha
{
    private int[] dados;
    private int topo;

    public Pilha(int tamanho)
    {
        dados = new int[tamanho];
        topo = -1;
    }

    public bool EstaVazia()
    {
        return topo == -1;
    }

    public bool EstaCheia()
    {
        return topo == dados.Length - 1;
    }

    public void Empilhar(int valor)
    {
        if (EstaCheia())
        {
            Console.WriteLine("ERRO: A pilha está cheia! Não é possível empilhar.");
            return;
        }
        dados[++topo] = valor;
    }

    public int Desempilhar()
    {
        if (EstaVazia())
        {
            Console.WriteLine("ERRO: A pilha está vazia! Não há valores para desempilhar.");
            return int.MinValue;
        }
        return dados[topo--];
    }

    public void Mostrar()
    {
        Console.Write("Estado da pilha: ");
        if (EstaVazia())
        {
            Console.WriteLine("(vazia)");
            return;
        }

        for (int i = topo; i >= 0; i--)
        {
            Console.Write(dados[i] + (i > 0 ? ", " : ""));
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Pilha pilha = new Pilha(100);
        Console.WriteLine("Calculadora de Pilha");
        Console.WriteLine("Digite números inteiros para empilhar e a calculadore funcionar.");
        Console.WriteLine("Digite +  -  *  /  para operar na calculadora.");
        Console.WriteLine("Digite S para sair  da calculadora.");


        while (true)
        {
            Console.Write("Entrada: ");
            string entrada = Console.ReadLine().Trim();

            if (entrada.ToUpper() == "S")
                break;

            int numero;
            // Se for número → empilha
            if (int.TryParse(entrada, out numero))
            {
                pilha.Empilhar(numero);
                pilha.Mostrar();
                continue;
            }

            // Se for operador → calcula
            if (entrada == "+" || entrada == "-" || entrada == "*" || entrada == "/")
            {
                if (pilha.EstaVazia())
                {
                    Console.WriteLine("ERRO: Pilha vazia. Não é possível realizar operação.");
                    continue;
                }

                int a = pilha.Desempilhar();
                int b = pilha.Desempilhar();

                if (a == int.MinValue || b == int.MinValue)
                    continue;

                int resultado = 0;

                switch (entrada)
                {
                    case "+": resultado = b + a; break;
                    case "-": resultado = b - a; break;
                    case "*": resultado = b * a; break;
                    case "/":
                        if (a == 0)
                        {
                            Console.WriteLine("ERRO: Divisão por zero!");
                            // devolve valores à pilha
                            pilha.Empilhar(b);
                            pilha.Empilhar(a);
                            continue;
                        }
                        resultado = b / a;
                        break;
                }

                pilha.Empilhar(resultado);
                pilha.Mostrar();
                continue;
            }

            Console.WriteLine("Entrada inválida! Digite um número ou operador válido.");
        }
    }
}
