using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prática_3_ListaEnc
{
    using System;

    class TestaLista
    {
        static void Main()
        {
            Lista lista = new Lista();
            int opcao;

            do
            {
                Console.WriteLine("\nLista Encadeada");
                Console.WriteLine("1 - Inserir na Lista");
                Console.WriteLine("2 - Pesquisar na Lista");
                Console.WriteLine("3 - Imprimir a Lista");
                Console.WriteLine("4 - Sair da Lista");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite a chave (int): ");
                        int chave;
                        if (!int.TryParse(Console.ReadLine(), out chave))
                        {
                            Console.WriteLine("Chave inválida!");
                            break;
                        }
                        Console.Write("Digite o nome: ");
                        string nome = Console.ReadLine();
                        lista.Inserir(chave, nome);
                        break;

                    case 2:
                        Console.Write("Digite a chave a pesquisar: ");
                        if (!int.TryParse(Console.ReadLine(), out chave))
                        {
                            Console.WriteLine("Chave inválida!");
                            break;
                        }

                        NoLista encontrado = lista.Pesquisar(chave);
                        if (encontrado != null)
                        {
                            Console.WriteLine($"Encontrado: Chave {encontrado.Chave}, Nome {encontrado.Nome}");
                            Console.Write("Deseja remover este nó? (s/n): ");
                            string resp = Console.ReadLine().ToLower();
                            if (resp == "s")
                            {
                                lista.Remover(chave);
                                Console.WriteLine("Nó removido com sucesso.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Chave não encontrada.");
                        }
                        break;

                    case 3:
                        lista.Imprimir();
                        break;

                    case 4:
                        Console.WriteLine("Saindo do programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != 4);
        }
    }

}
