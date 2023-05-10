using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midiaClasse
{
    class Midia
    {
        public int codigo { get; set; }
        public string titulo { get; set; }
        public int ano { get; set; }
        public float valor { get; set; }
        public string categoria { get; set; }

        public Midia(int codigo, string titulo, int ano, float valor, string categoria)
        {
            this.codigo = codigo;
            this.titulo = titulo;
            this.ano = ano;
            this.valor = valor;
            this.categoria = categoria;
        }

        public Midia()
        {
        }
    }
}
