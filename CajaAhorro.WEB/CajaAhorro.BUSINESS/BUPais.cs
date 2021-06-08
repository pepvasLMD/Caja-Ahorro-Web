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
    public class BUPais
    {
        private Client client;

        public BUPais()
        {
            client = new Client();
        }

        public List<ResponsePais> listarPaises(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponsePais>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarPaises", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
