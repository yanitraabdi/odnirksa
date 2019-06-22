﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;
using System.Data;
using Askrindo.Areas.RefData.Models.Mitigation;
using Askrindo.Helpers;

namespace Askrindo.Areas.RefData.Controllers
{
    [Authorize]
    public class MitigationController : Controller
    {
        AskrindoEntities db = new AskrindoEntities();
        UserData userData = Utils.LoadUserDataFromSession();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MitigationCatList()
        {
            ViewBag.CanModify = userData.IsAdmin;
            return View(db.MitigationCats);
        }

        public ActionResult MitigationCatNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MitigationCatNew(MitigationCat cat)
        {
            if (ModelState.IsValid)
            {
                db.MitigationCats.Add(cat);
                db.SaveChanges();
                return RedirectToAction("MitigationCatList");
            }
            return View(cat);
        }

        public ActionResult MitigationCatEdit(int id)
        {
            return View(db.MitigationCats.Single(p => p.MitigationCatId == id));
        }

        [HttpPost]
        public ActionResult MitigationCatEdit(MitigationCat cat)
        {
            if (ModelState.IsValid)
            {
                db.MitigationCats.Attach(cat);
                db.Entry(cat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MitigationCatList");
            }
            return View(cat);
        }

        public ActionResult MitigationCatDelete(int id)
        {
            return View(db.MitigationCats.Single(p => p.MitigationCatId == id));
        }

        [HttpPost, ActionName("MitigationCatDelete")]
        public ActionResult MitigationCatDeleteConfirmed(int id)
        {
            MitigationCat cat = db.MitigationCats.Single(p => p.MitigationCatId == id);
            db.MitigationCats.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("MitigationCatList");
        }

        public ActionResult MitigationTypeList(int catId)
        {
            MitigationTypeViewModel vm = new MitigationTypeViewModel();
            vm.MitigationCat = db.MitigationCats.Single(p => p.MitigationCatId == catId);
            vm.MitigationTypes = db.MitigationTypes.Where(p => p.MitigationCatId == catId);
            ViewBag.CanModify = userData.IsAdmin;
            return View(vm);
        }

        public ActionResult MitigationTypeNew(int catId)
        {
            MitigationTypeViewModel vm = new MitigationTypeViewModel();
            vm.MitigationCat = db.MitigationCats.Single(p => p.MitigationCatId == catId);
            return View(vm);
        }

        [HttpPost]
        public ActionResult MitigationTypeNew(MitigationTypeViewModel vm, int catId)
        {
            if (ModelState.IsValid)
            {
                vm.MitigationType.MitigationCatId = catId;
                db.MitigationTypes.Add(vm.MitigationType);
                db.SaveChanges();
                return RedirectToAction("MitigationTypeList", new { catId = catId });
            }
            vm.MitigationCat = db.MitigationCats.Single(p => p.MitigationCatId == catId);
            return View(vm);
        }

        public ActionResult MitigationTypeEdit(int id)
        {
            MitigationTypeViewModel vm = new MitigationTypeViewModel();
            vm.MitigationType = db.MitigationTypes.Single(p => p.MitigationTypeId == id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult MitigationTypeEdit(MitigationTypeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                db.MitigationTypes.Attach(vm.MitigationType);
                db.Entry(vm.MitigationType).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MitigationTypeList", new { catId = vm.MitigationType.MitigationCatId });
            }
            return View(vm);
        }

        public ActionResult MitigationTypeDelete(int id)
        {
            MitigationTypeViewModel vm = new MitigationTypeViewModel();
            vm.MitigationType = db.MitigationTypes.Single(p => p.MitigationTypeId == id);
            return View(vm);
        }

        [HttpPost, ActionName("MitigationTypeDelete")]
        public ActionResult MitigationTypeDeleteConfirmed(int id)
        {
            MitigationType type = db.MitigationTypes.Single(p => p.MitigationTypeId == id);
            var catId = type.MitigationCatId;
            db.MitigationTypes.Remove(type);
            db.SaveChanges();
            return RedirectToAction("MitigationTypeList", new { catId = catId });
        }

        public ActionResult TreeView()
        {
            return View(db.MitigationCats);
        }

        public ActionResult TableView()
        {
            return View(db.MitigationTypes);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
