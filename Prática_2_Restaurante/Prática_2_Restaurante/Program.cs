using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<int> filaPedidos = new Queue<int>();
        Queue<int> filaPagamentos = new Queue<int>();
        Queue<int> filaEncomendas = new Queue<int>();

        int clienteId = 1;
        int opcao;

        do
        {
            Console.WriteLine("\nRestaurante do Carlão");
            Console.WriteLine("1 - Inserção de cliente na fila de pedidos");
            Console.WriteLine("2 - Remoção de cliente da fila de pedidos");
            Console.WriteLine("3 - Remoção de cliente da fila de pagamentos");
            Console.WriteLine("4 - Remoção de cliente da fila de encomendas");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");

            opcao = int.Parse(Console.ReadLine() ?? "0");

            switch (opcao)
            {
                case 1:
                    filaPedidos.Enqueue(clienteId);
                    Console.WriteLine($"Cliente {clienteId} entrou na fila de pedidos.");
                    clienteId++;
                    break;

                case 2:
                    if (filaPedidos.Count > 0)
                    {
                        int cliente = filaPedidos.Dequeue();
                        Console.WriteLine($"Cliente {cliente} foi removido da fila de pedidos.");
                        filaPagamentos.Enqueue(cliente);
                        Console.WriteLine($"Cliente {cliente} entrou na fila de pagamentos.");
                    }
                    else
                        Console.WriteLine("Fila de pedidos está vazia.");
                    break;

                case 3:
                    if (filaPagamentos.Count > 0)
                    {
                        int cliente = filaPagamentos.Dequeue();
                        Console.WriteLine($"Cliente {cliente} foi removido da fila de pagamentos.");
                        filaEncomendas.Enqueue(cliente);
                        Console.WriteLine($"Cliente {cliente} entrou na fila de encomendas.");
                    }
                    else
                        Console.WriteLine("Fila de pagamentos está vazia.");
                    break;

                case 4:
                    if (filaEncomendas.Count > 0)
                    {
                        int cliente = filaEncomendas.Dequeue();
                        Console.WriteLine($"Cliente {cliente} foi removido da fila de encomendas.");
                        Console.WriteLine($"Cliente {cliente} recebeu sua encomenda e saiu do Restaurante.");
                    }
                    else
                        Console.WriteLine("Fila de encomendas está vazia.");
                    break;

                case 5:
                    Console.WriteLine("Encerrando o programa...");
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

        } while (opcao != 5);
    }
}

