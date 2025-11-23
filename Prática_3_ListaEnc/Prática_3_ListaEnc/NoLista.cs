using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prática_3_ListaEnc
{
    public class NoLista
    {
        public int Chave { get; set; }
        public string Nome { get; set; }
        public NoLista Prox { get; set; }

        public NoLista(int chave, string nome)
        {
            Chave = chave;
            Nome = nome;
            Prox = null;
        }
    }

}
