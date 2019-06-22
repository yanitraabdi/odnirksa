using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;
using Askrindo.Helpers;
using Askrindo.Areas.RefData.Models;

namespace Askrindo.Areas.RefData.Controllers
{
    public class LossCatController : Controller
    {
        //
        // GET: /RefData/RiskEvent/
        AskrindoEntities db = new AskrindoEntities();

        public ActionResult Index()
        {
            LossCatModel lc = new LossCatModel();
            lc.lossCatList = db.KlasifikasiKerugians.ToList();
            return View(lc);
        }

        public ActionResult Insert()
        {
            LossCatModel lc = new LossCatModel();
            return View(lc);
        }

        [HttpPost]
        public ActionResult Insert(LossCatModel lc)
        {
            if (ModelState.IsValid)
            {
                KlasifikasiKerugian kk = new KlasifikasiKerugian();
                kk.KlasifikasiId = lc.lossCat.KlasifikasiId;
                kk.Klasifikasi = lc.lossCat.Klasifikasi;
                db.KlasifikasiKerugians.Add(kk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lc);
        }

        public ActionResult Edit(String id)
        {
            LossCatModel lc = new LossCatModel();
            lc.lossCat = db.KlasifikasiKerugians.Single(p => p.KlasifikasiId == id);
            return View(lc);
        }

        [HttpPost]
        public ActionResult Edit(LossCatModel lc)
        {
            if (ModelState.IsValid)
            {
                db.KlasifikasiKerugians.Attach(lc.lossCat);
                db.Entry(lc.lossCat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lc);
        }

        public ActionResult Delete(String id)
        {
            LossCatModel lc = new LossCatModel();
            lc.lossCat = db.KlasifikasiKerugians.Single(p => p.KlasifikasiId == id);
            return View(lc);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(String id)
        {
            var r = db.KlasifikasiKerugians.Single(p => p.KlasifikasiId == id);
            db.KlasifikasiKerugians.Remove(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
