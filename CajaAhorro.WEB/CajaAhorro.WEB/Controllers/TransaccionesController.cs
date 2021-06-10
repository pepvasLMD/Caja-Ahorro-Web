using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CajaAhorro.WEB.Controllers
{
    public class TransaccionesController : Controller
    {
        // GET: Transacciones
        public ActionResult Transacciones()
        {
            return View();
        }
    }
}