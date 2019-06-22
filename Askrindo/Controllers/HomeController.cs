using Askrindo.Helpers;
using Askrindo.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Askrindo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("AskrindoLogin", "Account");
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var db = ApplicationDbContext.Create();

            var user = db.Users.Where(a => a.Email == "danial@yahoo.com").First();

            user.PasswordHash = (new PasswordHasher()).HashPassword("askrindo1234");

            db.SaveChanges();

            var user2 = db.Users.Where(a => a.Email == "indrazainal79@gmail.com").First();

            user2.PasswordHash = (new PasswordHasher()).HashPassword("askrindo1234");

            db.SaveChanges();

            var user3 = db.Users.Where(a => a.Email == "admin@mail.com").First();

            user3.PasswordHash = (new PasswordHasher()).HashPassword("askrindo1234");

            var user4 = db.Users.Where(a => a.UserName == "apppw1").First();

            user4.PasswordHash = (new PasswordHasher()).HashPassword("pass123");
            var user5 = db.Users.Where(a => a.UserName == "rcp123").First();

            user5.PasswordHash = (new PasswordHasher()).HashPassword("pass123");

            db.SaveChanges();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            Utils.GenerateKRIDummy();

            return View();
        }
    }
}