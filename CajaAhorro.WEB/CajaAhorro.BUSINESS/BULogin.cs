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
    public class BULogin
    {
        private Client clients;

        public BULogin()
        {
            clients = new Client();
        }

        public ResponseLogin Acceder(ENLogin paramss)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseLogin>(clients.Post<ENLogin>("Login/Acceder", paramss));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
