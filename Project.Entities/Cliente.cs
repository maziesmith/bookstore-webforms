using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Cliente : Usuario
    {
        public int IdCliente { get; set; }        
        public string CPF { get; set; }        
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
               

        public Endereco Endereco { get; set; }

        public Cliente()
        {

        }

        public Cliente(int idCliente, string cPF, string sexo, DateTime dataNascimento)
        {
            IdCliente = idCliente;
            CPF = cPF;
            Sexo = sexo;
            DataNascimento = dataNascimento;
        }
    }
}
