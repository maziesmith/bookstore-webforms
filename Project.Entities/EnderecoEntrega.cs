using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class EnderecoEntrega
    {
        public int IdEnderecoEntrega { get; set; }
        public string Destinatario { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Estados Estado { get; set; }
        public string Cep { get; set; }
    }
}
