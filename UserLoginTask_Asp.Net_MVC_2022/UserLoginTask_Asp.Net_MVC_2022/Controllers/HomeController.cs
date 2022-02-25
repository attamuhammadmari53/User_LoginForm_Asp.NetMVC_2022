using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserLoginTask_Asp.Net_MVC_2022.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login", "LoginForm");
        }
    }
}