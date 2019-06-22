using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;
using Askrindo.Helpers;

namespace Askrindo.Areas.RefData.Controllers
{
    public class AktivitasController : Controller
    {
        //
        AskrindoEntities db = new AskrindoEntities();

        public ActionResult Index()
        {
            var risks = db.bisnis_aktifitas.ToList();
            return View(risks);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(bisnis_aktifitas m)
        {
            if (ModelState.IsValid)
            {
                db.bisnis_aktifitas.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m);
            
        }

        public ActionResult Edit(int id)
        {
            bisnis_aktifitas r = db.bisnis_aktifitas.Single(p => p.aktifitasid == id);
            return View(r);
        }

        [HttpPost]
        public ActionResult Edit(bisnis_aktifitas r, int id)
        {
            if (ModelState.IsValid)
            {
                db.bisnis_aktifitas.Attach(r);
                db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(r);
        }

        public ActionResult Delete(int id)
        {
            return View(db.bisnis_aktifitas.Single(p => p.aktifitasid == id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var r = db.bisnis_aktifitas.Single(p => p.aktifitasid == id);
            db.bisnis_aktifitas.Remove(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
