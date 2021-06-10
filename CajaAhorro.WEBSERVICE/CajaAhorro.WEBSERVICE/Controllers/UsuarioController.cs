using CajaAhorro.DATOS;
using CajaAhorro.ENTITY.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CajaAhorro.WEBSERVICE.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        private DAUsuario daUsuario;

        public UsuarioController()
        {
            daUsuario = new DAUsuario();
        }

        [HttpPost]
        [Route("estadoCuenta")]
        public IHttpActionResult estadoCuenta(ENUsuario paramss)
        {
            try
            {
                var rpt = daUsuario.getEstadoCuenta(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("darAportacion")]
        public IHttpActionResult darAportacion(ENTransaccion paramss)
        {
            try
            {
                var rpt = daUsuario.getDarAportacion(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("deposito")]
        public IHttpActionResult deposito(ENTransaccion paramss)
        {
            try
            {
                var rpt = daUsuario.getDeposito(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("retiro")]
        public IHttpActionResult retiro(ENTransaccion paramss)
        {
            try
            {
                var rpt = daUsuario.getRetiro(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}