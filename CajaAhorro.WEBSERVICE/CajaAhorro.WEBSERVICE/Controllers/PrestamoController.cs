using CajaAhorro.DATOS;
using CajaAhorro.ENTITY.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CajaAhorro.WEBSERVICE.Controllers
{
    [RoutePrefix("api/Prestamo")]
    public class PrestamoController : ApiController
    {
        private DAPrestamo daPrestamo;

        public PrestamoController()
        {
            daPrestamo = new DAPrestamo();
        }

        [HttpPost]
        [Route("prestar")]
        public IHttpActionResult Prestar(ENPrestamo paramss)
        {
            try
            {
                var rpt = daPrestamo.getPrestar(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}