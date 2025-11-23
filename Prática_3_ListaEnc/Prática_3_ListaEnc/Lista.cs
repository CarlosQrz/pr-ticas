using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prática_3_ListaEnc
{
    using System;

    public class Lista
    {
        private NoLista primeiro;

        public Lista()
        {
            primeiro = null;
        }

        // Verifica duplicata
        public bool Existe(int chave)
        {
            NoLista atual = primeiro;
            while (atual != null)
            {
                if (atual.Chave == chave)
                    return true;
                atual = atual.Prox;
            }
            return false;
        }

        // Inserir no início (sem duplicata)
        public void Inserir(int chave, string nome)
        {
            if (Existe(chave))
            {
                Console.WriteLine($"Erro: a chave {chave} já existe na lista.");
                return;
            }

            NoLista novo = new NoLista(chave, nome);
            novo.Prox = primeiro;
            primeiro = novo;
            Console.WriteLine($"Inserido: ({chave}, {nome})");
        }

        // Pesquisar e retornar nó
        public NoLista Pesquisar(int chave)
        {
            NoLista atual = primeiro;
            while (atual != null)
            {
                if (atual.Chave == chave)
                    return atual;
                atual = atual.Prox;
            }
            return null;
        }

        // Remover nó
        public bool Remover(int chave)
        {
            NoLista atual = primeiro;
            NoLista anterior = null;

            while (atual != null && atual.Chave != chave)
            {
                anterior = atual;
                atual = atual.Prox;
            }

            if (atual == null)
                return false; // não achou

            if (anterior == null) // remove o primeiro
                primeiro = atual.Prox;
            else
                anterior.Prox = atual.Prox;

            return true;
        }

        // Imprimir toda a lista
        public void Imprimir()
        {
            if (primeiro == null)
            {
                Console.WriteLine("Lista vazia.");
                return;
            }

            Console.WriteLine("Conteúdo da lista:");
            NoLista atual = primeiro;
            while (atual != null)
            {
                Console.WriteLine($"Chave: {atual.Chave}, Nome: {atual.Nome}");
                atual = atual.Prox;
            }
        }
    }

}
