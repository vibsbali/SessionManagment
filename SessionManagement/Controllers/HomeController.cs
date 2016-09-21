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
        public static HttpCookieCollection cookies = new HttpCookieCollection();

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

        public ActionResult CookieSessionManagement(string uac)
        {
            if (Request.Cookies[uac] == null)
            {
                Response.Cookies[uac].Value = uac;
                Response.Cookies[uac].Expires = DateTime.Now.AddMinutes(20d);


                HttpCookie aCookie = new HttpCookie("lastVisit");
                aCookie.Value = DateTime.Now.ToString();
                aCookie.Expires = DateTime.Now.AddMinutes(20d);
                Response.Cookies.Add(aCookie);                
            }
            else
            {
                HttpCookie cookie = Request.Cookies[uac];
                Response.Cookies[uac].Value = cookie.Value;
                Response.Cookies[uac].Value = cookie.Expires.ToString();
            }
            var currentClient = Response.Cookies[uac].Value;
            ViewBag.currentClient = currentClient;
            ViewBag.CurrentClientSessionExpiry = Response.Cookies[uac].Expires;
            return View();
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