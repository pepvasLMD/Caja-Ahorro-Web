using CajaAhorro.BUSINESS;
using CajaAhorro.ENTITY.Parametros;
using CajaAhorro.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CajaAhorro.WEB.Controllers
{
    public class RegistroEmpresaController : Controller
    {
        private modelList model;
        private BUPais buPais;

        public RegistroEmpresaController()
        {
            model = new modelList();
            buPais = new BUPais();
        }

        public ActionResult RegistroEmpresa(ENRegistroEmpresa paramss)
        {
            //Porque en la clase de CLIENTS se envía el token vacío
            string token = "";

            model.listPais = buPais.listarPaises(paramss, token);

            return View(model);
        }

    }
}