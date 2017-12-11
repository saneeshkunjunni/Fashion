using FashionModeling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionModeling.Controllers
{
    public class AdminController : Controller
    {
        private readonly IJobServices jobServices;
        public AdminController(IJobServices jobServices)
        {
            this.jobServices = jobServices;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        #region Job
        public ActionResult Job()
        {
            return View();
        }
        #endregion


        #region Profiles
        public ActionResult Profiles()
        {
            return View();
        }
        #endregion

        #region Subscriptions
        public ActionResult Subscriptions()
        {
            return View();
        }
        #endregion

        #region JobRoles
        public ActionResult JobRoles()
        {
            return View();
        }
        #endregion
        #region Tags
        public ActionResult Tags()
        {
            return View();
        }
        #endregion
        #region Users
        public ActionResult Users()
        {
            return View();
        }
        #endregion
    }
}