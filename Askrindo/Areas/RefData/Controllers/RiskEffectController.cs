using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;
using System.Data;
using Askrindo.Areas.RefData.Models.RiskEffect;
using Askrindo.Helpers;

namespace Askrindo.Areas.RefData.Controllers
{
    [Authorize]
    public class RiskEffectController : Controller
    {
        AskrindoEntities db = new AskrindoEntities();
        UserData userData = Utils.LoadUserDataFromSession();

        public ActionResult Index()
        {
            return View();
        }

        #region EffectGroup
        
        public ActionResult EffectGroupList()
        {
            ViewBag.CanModify = userData.IsAdmin;
            return View(db.EffectGroups);
        }

        public ActionResult EffectGroupNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EffectGroupNew(EffectGroup group)
        {
            if (ModelState.IsValid)
            {
                db.EffectGroups.Add(group);
                db.SaveChanges();
                return RedirectToAction("EffectGroupList");
            }
            return View(group);
        }

        public ActionResult EffectGroupEdit(int id)
        {
            return View(db.EffectGroups.Single(p => p.EffectGroupId == id));
        }

        [HttpPost]
        public ActionResult EffectGroupEdit(EffectGroup group)
        {
            if (ModelState.IsValid)
            {
                db.EffectGroups.Attach(group);
                db.Entry(group).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EffectGroupList");
            }
            return View(group);
        }

        public ActionResult EffectGroupDelete(int id)
        {
            return View(db.EffectGroups.Single(p => p.EffectGroupId == id));
        }

        [HttpPost, ActionName("EffectGroupDelete")]
        public ActionResult EffectGroupDeleteConfirmed(int id)
        {
            EffectGroup group = db.EffectGroups.Single(p => p.EffectGroupId == id);
            db.EffectGroups.Remove(group);
            db.SaveChanges();
            return RedirectToAction("EffectGroupList");
        }

        #endregion

        #region EffectType

        public ActionResult EffectTypeList(int groupId)
        {
            EffectTypeViewModel vm = new EffectTypeViewModel();
            vm.EffectGroup = db.EffectGroups.Single(p => p.EffectGroupId == groupId);
            vm.EffectTypes = db.EffectTypes.Where(p => p.EffectGroupId == groupId);
            ViewBag.CanModify = userData.IsAdmin;
            return View(vm);
        }

        public ActionResult EffectTypeNew(int groupId)
        {
            EffectTypeViewModel vm = new EffectTypeViewModel();
            vm.EffectGroup = db.EffectGroups.Single(p => p.EffectGroupId == groupId);
            return View(vm);
        }

        [HttpPost]
        public ActionResult EffectTypeNew(EffectTypeViewModel vm, int groupId)
        {
            if (ModelState.IsValid)
            {
                vm.EffectType.EffectGroupId = groupId;
                db.EffectTypes.Add(vm.EffectType);
                db.SaveChanges();
                return RedirectToAction("EffectTypeList", new { groupId = groupId });
            }
            vm.EffectGroup = db.EffectGroups.Single(p => p.EffectGroupId == groupId);
            return View(vm);
        }

        public ActionResult EffectTypeEdit(int id)
        {
            EffectTypeViewModel vm = new EffectTypeViewModel();
            vm.EffectType = db.EffectTypes.Single(p => p.EffectTypeId == id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult EffectTypeEdit(EffectTypeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                db.EffectTypes.Attach(vm.EffectType);
                db.Entry(vm.EffectType).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EffectTypeList", new { groupId = vm.EffectType.EffectGroupId });
            }
            return View(vm);
        }

        public ActionResult EffectTypeDelete(int id)
        {
            EffectTypeViewModel vm = new EffectTypeViewModel();
            vm.EffectType = db.EffectTypes.Single(p => p.EffectTypeId == id);
            return View(vm);
        }

        [HttpPost, ActionName("EffectTypeDelete")]
        public ActionResult EffectTypeDeleteConfirmed(int id)
        {
            EffectType type = db.EffectTypes.Single(p => p.EffectTypeId == id);
            var groupId = type.EffectGroupId;
            db.EffectTypes.Remove(type);
            db.SaveChanges();
            return RedirectToAction("EffectTypeList", new { groupId = groupId });
        }

        #endregion

        public ActionResult EffectList(int typeId)
        {
            EffectViewModel vm = new EffectViewModel();
            vm.EffectType = db.EffectTypes.Single(p => p.EffectTypeId == typeId);
            vm.Effects = db.Effects.Where(p => p.EffectTypeId == typeId);
            ViewBag.CanModify = userData.IsAdmin;
            return View(vm);
        }

        public ActionResult EffectNew(int typeId)
        {
            EffectViewModel vm = new EffectViewModel();
            vm.EffectType = db.EffectTypes.Single(p => p.EffectTypeId == typeId);
            return View(vm);
        }

        [HttpPost]
        public ActionResult EffectNew(EffectViewModel vm, int typeId)
        {
            if (ModelState.IsValid)
            {
                vm.Effect.EffectTypeId = typeId;
                db.Effects.Add(vm.Effect);
                db.SaveChanges();
                return RedirectToAction("EffectList", new { typeId = typeId });
            }
            vm.EffectType = db.EffectTypes.Single(p => p.EffectTypeId == typeId);
            return View(vm);
        }

        public ActionResult EffectEdit(int id)
        {
            EffectViewModel vm = new EffectViewModel();
            vm.Effect = db.Effects.Single(p => p.EffectId == id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult EffectEdit(EffectViewModel vm)
        {
            if (ModelState.IsValid)
            {
                db.Effects.Attach(vm.Effect);
                db.Entry(vm.Effect).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EffectList", new { typeId = vm.Effect.EffectTypeId });
            }
            return View(vm);
        }

        public ActionResult EffectDelete(int id)
        {
            EffectViewModel vm = new EffectViewModel();
            vm.Effect = db.Effects.Single(p => p.EffectId == id);
            return View(vm);
        }

        [HttpPost, ActionName("EffectDelete")]
        public ActionResult EffectDeleteConfirmed(int id)
        {
            Effect effect = db.Effects.Single(p => p.EffectId == id);
            var typeId = effect.EffectTypeId;
            db.Effects.Remove(effect);
            db.SaveChanges();
            return RedirectToAction("EffectList", new { typeId = typeId });
        }

        public ActionResult TreeView()
        {
            return View(db.EffectGroups);
        }

        public ActionResult TableView()
        {
            return View(db.Effects);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
