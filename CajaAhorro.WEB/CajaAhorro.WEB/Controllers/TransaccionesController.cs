using CajaAhorro.BUSINESS;
using CajaAhorro.ENTITY.Parametros;
using CajaAhorro.WEB.Helpers;
using CajaAhorro.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CajaAhorro.WEB.Controllers
{
    public class TransaccionesController : Controller
    {
        private BUUsuario buUsuario;
        private modelList model;

        public TransaccionesController()
        {
            buUsuario = new BUUsuario();
        }
        public ActionResult Transacciones()
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

        [HttpPost]
        public ActionResult deposito(ENUsuario paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.idusuario = session.iduser;

            var respuesta = buUsuario.deposito(paramss, token);
            return Json(new { dt = respuesta });
        }
    }
}