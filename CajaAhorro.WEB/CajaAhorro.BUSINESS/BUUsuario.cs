using CajaAhorro.CLIENTS;
using CajaAhorro.ENTITY.Parametros;
using CajaAhorro.ENTITY.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaAhorro.BUSINESS
{
    public class BUUsuario
    {
        private Client clients;

        public BUUsuario()
        {
            clients = new Client();
        }

        public ResponseUsuario registrarUsuario(ENUsuario paramss)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseUsuario>(clients.Post<ENUsuario>("Usuario/registrarUsuario", paramss));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ResponseUsuario deposito(ENUsuario paramss,string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseUsuario>(clients.Post<ENUsuario>("Usuario/deposito", paramss,token));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
