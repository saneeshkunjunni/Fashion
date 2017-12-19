using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionModeling.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profiles()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Jobs()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}