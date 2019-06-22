using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;
using Askrindo.Helpers;
using Askrindo.Areas.RefData.Models.Aktivitas;

namespace Askrindo.Areas.RefData.Controllers
{
    public class RiskBizController : Controller
    {
        //
        // GET: /RefData/RiskEvent/
        AskrindoEntities db = new AskrindoEntities();

        public ActionResult Index()
        {
            var risks = db.bisnis.ToList();
            return View(risks);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(bisni m)
        {
            if (ModelState.IsValid)
            {
                db.bisnis.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m);
            
        }

        public ActionResult Edit(int id)
        {
            bisni r = db.bisnis.Single(p => p.bisnisid == id);
            return View(r);
        }

        [HttpPost]
        public ActionResult Edit(bisni r, int id)
        {
            if (ModelState.IsValid)
            {
                db.bisnis.Attach(r);
                db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(r);
        }

        public ActionResult Delete(int id)
        {
            return View(db.bisnis.Single(p => p.bisnisid == id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var r = db.bisnis.Single(p => p.bisnisid == id);
            db.bisnis.Remove(r);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AktivitasIndex(int id)
        {
            AktivitasModel am = new AktivitasModel();
            am.listAktivitas = db.bisnis_aktifitas.Where(m => m.bisnisid == id).ToList();
            am.bisnisid = id;

            return View(am);
        }

        [HttpGet]
        public ActionResult AktivitasInsert(int id)
        {
            AktivitasModel am = new AktivitasModel();
            am.aktivitas = new bisnis_aktifitas();
            am.aktivitas.bisnisid = id;
            am.bisnisid = id;
            return View(am);
        }

        [HttpPost]
        public ActionResult AktivitasInsert(AktivitasModel m)
        {
            if (ModelState.IsValid)
            {
                db.bisnis_aktifitas.Add(m.aktivitas);
                db.SaveChanges();
                return RedirectToAction("AktivitasIndex", new { id = m.aktivitas.bisnisid });
            }
            return View(m);
        }

        public ActionResult AktivitasEdit(int id)
        {
            bisnis_aktifitas r = db.bisnis_aktifitas.Single(p => p.aktifitasid == id);
            return View(r);
        }

        [HttpPost]
        public ActionResult AktivitasEdit(bisnis_aktifitas r, int id)
        {
            if (ModelState.IsValid)
            {
                r.bisnisid = id;
                db.bisnis_aktifitas.Attach(r);
                db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AktivitasIndex", new { id = id });
            }
            return View(r);
        }

        public ActionResult AktivitasDelete(int id)
        {
            return View(db.bisnis_aktifitas.Single(p => p.aktifitasid == id));
        }

        [HttpPost, ActionName("AktivitasDelete")]
        public ActionResult AktivitasDeleteConfirmed(int id)
        {
            var r = db.bisnis_aktifitas.Single(p => p.aktifitasid == id);
            int? bisnisid = r.bisnisid;
            db.bisnis_aktifitas.Remove(r);
            db.SaveChanges();
            return RedirectToAction("AktivitasIndex", new { id = bisnisid });
        }
    }

}
