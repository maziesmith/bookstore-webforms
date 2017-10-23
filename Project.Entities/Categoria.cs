using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
   
        public Categoria()
        {

        }
        public Categoria(int idCategoria, string nome, string descricao)
        {
            IdCategoria = idCategoria;
            Nome = nome;            
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", IdCategoria, Nome);
        }
    }
}
