using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midiaClasse
{
    class Livro:Midia
    {
        public string autor { get; set; }
        public string isbn { get; set; }

        public Livro(string autor, string isbn, int codigo, string titulo, int ano, float valor, string categoria) : base( codigo, titulo, ano, valor, categoria)
        {
            this.autor = autor;
            this.isbn = isbn;
        }

        public Livro()
        {
        }


    }
}
