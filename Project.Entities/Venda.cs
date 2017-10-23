using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal Valor { get; set; }
        public string Pagamento { get; set; }        

        public EnderecoEntrega EnderecoEntrega { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemVenda> Itens { get; set; }
    }
}
