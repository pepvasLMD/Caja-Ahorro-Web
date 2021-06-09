﻿using CajaAhorro.BUSINESS;
using CajaAhorro.ENTITY.Parametros;
using CajaAhorro.ENTITY.Response;
using CajaAhorro.WEB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CajaAhorro.WEB.Controllers
{
    public class LoginController : Controller
    {
        //Se envían a la API
        private BULogin buLogin;

        //Se enlaza para usar en todo el proyecto
        public LoginController()
        {
            buLogin = new BULogin();
        }

        //El que se llama en el js
        [HttpPost]
        public ActionResult Acceder(ENLogin paramss)
        {
            //var clave = Encrypt.GetSHA256(paramss.pass);
            //paramss.pass = clave;

            var respuesta = buLogin.Acceder(paramss);
            Session.Set(GlobalKey.CurrentUser, respuesta);
            SetCurrentUser(respuesta);

            return Json(new { dt = respuesta });
        }

        protected void SetCurrentUser(ResponseLogin login)
        {
            Session["Username"] = login;
        }
    }
}