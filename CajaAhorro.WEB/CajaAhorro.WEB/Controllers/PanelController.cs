using CajaAhorro.WEB.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CajaAhorro.WEB.Controllers
{
    public class PanelController : Controller
    {
        public ActionResult Panel()
        {
            
            var session = Session.GetCurrentUser();
            if (session != null)
            {
                //Deshabilita las flechas de atrás adelante
                Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                Response.Cache.SetAllowResponseInBrowserHistory(false);
                Response.Cache.SetNoStore();
                return View();
            }
            else
            {
                //Deshabilita las flechas de atrás adelante
                Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                Response.Cache.SetAllowResponseInBrowserHistory(false);
                Response.Cache.SetNoStore();
                return RedirectToAction("Index", "Home");
            }
            
            //return View();

        }

    }
}