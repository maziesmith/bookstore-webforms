using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {

        }

        public Usuario(string nome, string sobrenome, string email, string senha)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Senha = senha;
        }
    }
}
