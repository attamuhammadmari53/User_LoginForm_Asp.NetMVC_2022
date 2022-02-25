using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserLoginTask_Asp.Net_MVC_2022.Models;

namespace UserLoginTask_Asp.Net_MVC_2022.Controllers
{
    public class LoginFormController : Controller
    {
        private UserLogin_ModelContainer db = new UserLogin_ModelContainer();  
        // GET: LoginForm
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(User_Account log)
        {
            if (ModelState.IsValid)
            {
           
                var check = db.User_Account.Where(x => x.Email == log.Email);
                if (check !=null)
                {
                    var passcheck = db.User_Account.Where(y => y.Password == log.Password);

                    if (passcheck !=null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password is incorrect");
                        return View();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Email is incorrect");
                    //  ViewBag.mes = "User is Inactive";
                    return View();
                }
            }
            return View();
        }

        public ActionResult BackToRegistration()
        {
            return RedirectToAction("Create", "User_Account");
        }
    }
}