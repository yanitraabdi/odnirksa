using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;
using System.Data;
using Askrindo.Helpers;

namespace Askrindo.Areas.RefData.Controllers
{
    [Authorize]
    public class ProbLevelController : Controller
    {
        AskrindoEntities db = new AskrindoEntities();
        UserData userData = Utils.LoadUserDataFromSession();

        public ActionResult Index()
        {
            ViewBag.CanModify = userData.IsAdmin;
            return View(db.ProbLevels);
        }

        public ActionResult Edit(int id)
        {
            return View(db.ProbLevels.Single(p => p.ProbLevelId == id));
        }

        [HttpPost]
        public ActionResult Edit(ProbLevel level)
        {
            if (ModelState.IsValid)
            {
                db.ProbLevels.Attach(level);
                db.Entry(level).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(level);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
