using CajaAhorro.WEB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CajaAhorro.WEB.Controllers
{
    public class EstadoCajaController : Controller
    {
        // GET: EstadoCaja
        public ActionResult EstadoCaja()
        {
            return View();
        }

        [HttpPost]
        public ActionResult validarAccesoModulo()
        {
            var session = Session.GetCurrentUser();

            if (session.tipo == "admin")
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