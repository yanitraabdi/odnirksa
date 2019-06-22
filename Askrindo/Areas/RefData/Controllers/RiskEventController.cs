using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;
using Askrindo.Helpers;
using Askrindo.Areas.RefData.Models;
using System.Data;

namespace Askrindo.Areas.RefData.Controllers
{
    [Authorize]
    public class RiskEventController : Controller
    {
        AskrindoEntities db = new AskrindoEntities();
        UserData userData = Utils.LoadUserDataFromSession();

        public ActionResult Index(int id)
        {
            RiskEventModel re = new RiskEventModel();
            re.riskEventList = db.RiskEvents.Where(p => p.RiskTypeId == id).ToList();
            re.riskEvent = db.RiskEvents.Where(p => p.RiskTypeId == id).FirstOrDefault();
            var gr = db.RiskTypes.Where(p => p.RiskTypeId == id).FirstOrDefault();
            re.groupId = gr.RiskGroupId;
            re.typeId = id;
            re.canmodify = userData.IsAdmin;
            return View(re);
        }

        public ActionResult Insert(int id)
        {
            RiskEventModel re = new RiskEventModel();
            re.typeId = id;
            var length = id.ToString().Length;
            var getId = db.RiskEvents.Where(r => r.RiskTypeId == id && r.input_date != null).OrderByDescending(p => p.RiskEventID).FirstOrDefault();      
            if (getId == null)
            {
                var reId = id.ToString() + "001";
                re.reId = Convert.ToInt32(reId);
            }
            else
            {
                var getcounter = getId.RiskEventID.ToString().Substring(length);
                var getTypeId = getId.RiskEventID.ToString().Substring(0, length);
                var counter = Convert.ToInt32(getcounter) + 1;
                if (counter.ToString().Length == 1)
                {
                    var zero = "00";
                    var setId = getTypeId + zero + counter.ToString();
                    re.reId = Convert.ToInt32(setId);
                }
                else if (counter.ToString().Length == 2)
                {
                    var zero = "0";
                    var setId = getTypeId + zero + counter.ToString();
                    re.reId = Convert.ToInt32(setId);
                }
                else if (counter.ToString().Length == 3)
                {
                    var zero = "";
                    var setId = getTypeId + zero + counter.ToString();
                    re.reId = Convert.ToInt32(setId);
                }
                else
                {
                    
                }
                
            }
            
            return View(re);
        }

        [HttpPost]
        public ActionResult Insert(RiskEventModel m)
        {
            if (ModelState.IsValid)
            {
                m.riskEvent.RiskEventID = (int)m.reId;
                m.riskEvent.RiskTypeId = m.typeId;
                m.riskEvent.input_date = DateTime.Now;
                db.RiskEvents.Add(m.riskEvent);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = m.typeId });
            }
            return View(m);
        }

        public ActionResult Edit(int id)
        {
            RiskEventModel r = new RiskEventModel();
            r.riskEvent = db.RiskEvents.Single(p => p.RiskEventID == id);
            return View(r);
        }

        [HttpPost]
        public ActionResult Edit(RiskEventModel r)
        {
            if (ModelState.IsValid)
            {
                db.RiskEvents.Attach(r.riskEvent);
                db.Entry(r.riskEvent).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = r.riskEvent.RiskTypeId });
            }
            return View(r);
        }

        public ActionResult Delete(int id)
        {
            return View(db.RiskEvents.Single(p => p.RiskEventID == id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var r = db.RiskEvents.Single(p => p.RiskEventID == id);
            var t = r.RiskTypeId;
            db.RiskEvents.Remove(r);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = t });
        }

    }
}
