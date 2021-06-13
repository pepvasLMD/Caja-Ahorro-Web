using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaAhorro.ENTITY.Response
{
    public class ResponseUsuario
    {
        public string response { get; set; }
        public int idusuario { get; set; }
        public string tipo { get; set; }

        public int idcuenta { get; set; }

        public double dinero { get; set; }

        public double disponible { get; set; }

        public string nombre { get; set; }
        public string email { get; set; }

        public string password { get; set; }
    }
}
