using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserLoginTask_Asp.Net_MVC_2022.Models;

namespace UserLoginTask_Asp.Net_MVC_2022.Controllers
{
    public class User_AccountController : Controller
    {
        private UserLogin_ModelContainer db = new UserLogin_ModelContainer();
        // GET: User_Account
        public ActionResult Index()
        {
            return View(db.User_Account.ToList());
        }

        // GET: User_Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_Account/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Password,IsActive")] User_Account user_Account)
        {
            if (ModelState.IsValid)
            {
                db.User_Account.Add(user_Account);
                db.SaveChanges();
                return RedirectToAction("Login", "LoginForm");
            }

            return View(user_Account);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult BackToLogin()
        {
            return RedirectToAction("Login", "LoginForm");
        }
    }
}