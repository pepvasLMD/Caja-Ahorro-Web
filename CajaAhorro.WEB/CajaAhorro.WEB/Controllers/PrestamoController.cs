using CajaAhorro.WEB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CajaAhorro.WEB.Controllers
{
    public class PrestamoController : Controller
    {
        // GET: Prestamo
        public ActionResult Prestamo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult validarAccesoModulo()
        {
            var session = Session.GetCurrentUser();

            if (session.tipo == "cliente")
            {
                var respuesta = "ok";
                return Json(new { dt = respuesta });
            }
            else
            {
                var respuesta = "error";
                return Json(new { dt = respuesta });
            }
        }
    }
}