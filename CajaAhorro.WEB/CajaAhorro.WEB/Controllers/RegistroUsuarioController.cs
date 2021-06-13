using CajaAhorro.BUSINESS;
using CajaAhorro.ENTITY.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CajaAhorro.WEB.Controllers
{
    public class RegistroUsuarioController : Controller
    {
        
        private BUUsuario buUsuario;

        public RegistroUsuarioController()
        {
            buUsuario = new BUUsuario();
        }

        // GET: RegistroUsuario
        public ActionResult RegistroUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult registrarUsuario(ENUsuario paramss)
        {
            var respuesta = buUsuario.registrarUsuario(paramss);
            return Json(new { dt = respuesta });
        }

    }
}