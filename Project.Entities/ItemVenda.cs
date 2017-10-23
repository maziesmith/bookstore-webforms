using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class ItemVenda
    {
        public int IdItemVenda { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }

        public Venda Venda { get; set; }    
        public Livro Livro { get; set; }
    }
}
