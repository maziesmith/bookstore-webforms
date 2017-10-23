using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class Administrador : Usuario
    {
        public int IdAdministrador { get; set; }

        public Administrador()
        {

        }

        public Administrador(int idAdministrador)
        {
            IdAdministrador = idAdministrador;
        }
    }
}
