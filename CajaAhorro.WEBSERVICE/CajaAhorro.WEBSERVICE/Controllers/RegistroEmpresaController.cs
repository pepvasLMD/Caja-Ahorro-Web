using CajaAhorro.DATOS;
using CajaAhorro.ENTITY.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CajaAhorro.WEBSERVICE.Controllers
{
    [RoutePrefix("api/RegistroEmpresa")]
    public class RegistroEmpresaController : ApiController
    {
        private DAPaises dapaises;
        private DARegistroEmpresas daregistroempresa;

        public RegistroEmpresaController()
        {
            dapaises = new DAPaises();
            daregistroempresa = new DARegistroEmpresas();
        }

        [HttpPost]
        [Route("listarPaises")]
        public IHttpActionResult listarPaises(ENRegistroEmpresa paramss)
        {
            try
            {
                var rpt = dapaises.listarPaises(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
