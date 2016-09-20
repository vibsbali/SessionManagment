using SessionManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SessionManagement(string uac)
        {
            var currentClient = (Client)Session[uac];

            if (currentClient == null)
            {
                currentClient = new Client
                {
                    Uac = uac,
                    TimeInitialised = DateTime.Now
                };

                //Add it to session 
                Session[uac] = currentClient;
            }

            return View(currentClient);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }    
}