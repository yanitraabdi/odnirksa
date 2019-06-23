using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Areas.LossEvent.Models;
using Askrindo.Models;
using Askrindo.Helpers;

namespace Askrindo.Areas.LossEvent.Controllers
{
    public class LossEventController : Controller
    {
        //
        // GET: /LossEvent/LossEvent/

        AskrindoEntities db = new AskrindoEntities();
        UserData data = Utils.LoadUserDataFromSession();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LossEventNew()
        {
            string riskOwner=db.SubDivs.Where(x => x.SubDivId == data.SubDivId).FirstOrDefault().SubDivName;
            
            LossEventModel le = new LossEventModel();
            le.inputDate = DateTime.Now;
            le.lossDate = DateTime.Now;
            le.code = "L"+Utils.GetFormattedSerialNumberLossEvent(data);
            le.lossEvent = new Askrindo.Models.LossEvent();
            le.lossEvent.LossOwner = riskOwner;
            Dictionary<string, string> catList = new Dictionary<string, string>();
            foreach (var Klasifikasi in db.KlasifikasiKerugians.OrderBy(m => m.KlasifikasiId))
                catList.Add(Klasifikasi.KlasifikasiId, Klasifikasi.Klasifikasi);
            le.klasifikasi = new SelectList(catList, "Key", "Value", 1);

            Dictionary<string, string> coverageList = new Dictionary<string, string> {
                { "Nasional", "Nasional" },
                { "Kantor Pusat", "Kantor Pusat" },
                { "Kantor Cabang", "Kantor Cabang" },
                { "Korwil", "Korwil" },
                { "Kelas KC", "Kelas KC" },
            };
            le.cakupan = new SelectList(coverageList, "Key", "Value", 1);

            if (data.IsAdmin)
            {
                ViewBag.Message = "Tidak Bisa Melakukan Input Loss Event";
                return View("Error");
            } else
                return View(le);
        }

        [HttpPost]
        public ActionResult LossEventNew(LossEventModel le)
        {
            //Askrindo.Models.LossEvent loss = new Askrindo.Models.LossEvent();

            //var id = db.LossEvents.OrderByDescending(p => p.LossEventId).FirstOrDefault();

            /*loss.Action = le.lossEvent.Action;
            loss.Assets = le.lossEvent.Assets;
            loss.BizUnitId = data.BizUnitId;
            loss.BranchId = data.BranchId;
            loss.DeptId = data.DeptId;
            loss.DivisionId = data.DivisionId;
            loss.ImpactFinancial = le.lossEvent.ImpactFinancial;
            loss.ImpactNonFinancial = le.lossEvent.ImpactNonFinancial;
            loss.InputDate = DateTime.Now;
            loss.JobTitle = data.JobTitle;
            loss.Keterangan = le.lossEvent.Keterangan;
            loss.KlasifikasiId = le.lossEvent.KlasifikasiId;
            loss.Location = le.lossEvent.Location;
            loss.LossCause = le.lossEvent.LossCause;
            loss.LossDate = le.lossDate;
            loss.LossEventCode = le.code;
            loss.LossEventName = le.lossEvent.LossEventName;
            loss.PihakTerlibat = le.lossEvent.PihakTerlibat;
            loss.SubBranchIs = data.SubBranchId;
            loss.SubDeptId = data.SubDeptId;
            loss.SubDivId = data.SubDivId;
            loss.UserId = data.UserId;*/
            le.lossEvent.LossEventCode = le.code;
            le.lossEvent.JobTitle = data.JobTitle;
            le.lossEvent.SubDeptId = data.SubDeptId;
            le.lossEvent.SubDivId = data.SubDivId;
            le.lossEvent.UserId = data.UserId;
            le.lossEvent.BizUnitId = data.BizUnitId;
            le.lossEvent.BranchId = data.BranchId;
            le.lossEvent.DeptId = data.DeptId;
            le.lossEvent.DivisionId = data.DivisionId;
            le.lossEvent.InputDate = DateTime.Now;
            le.lossEvent.LossDate = le.lossDate;
            db.LossEvents.Add(le.lossEvent);
            db.SaveChanges();   
            Utils.IncrementSerialNumberLossEvent(db);
            return RedirectToAction("LossEventList");
        }


        [HttpGet]
        public JsonResult LoadUnitKerja(string id)
        {
            if (id == "Kantor Pusat")
            {
                var list = db.SubDivs.ToList();
                var selectItems = list.Select(m => new SelectListItem()
                {
                    Text = m.SubDivName,
                    Value = m.SubDivId.ToString()
                });
                return Json(selectItems, JsonRequestBehavior.AllowGet);
            }
            else if (id == "Kantor Cabang")
            {
                var list = db.Branches.ToList();
                var selectItems = list.Select(m => new SelectListItem()
                {
                    Text = m.BranchName,
                    Value = m.BranchId.ToString()
                });
                return Json(selectItems, JsonRequestBehavior.AllowGet);
            }
            else if (id == "Korwil")
            {
                var list = db.Korwils.ToList();
                var selectItems = list.Select(m => new SelectListItem()
                {
                    Text = m.Korwil1,
                    Value = m.KorwilId.ToString()
                });
                return Json(selectItems, JsonRequestBehavior.AllowGet);
            }
            else if (id == "Kelas KC")
            {
                var list = db.BranchClasses.ToList();
                var selectItems = list.Select(m => new SelectListItem()
                {
                    Text = m.ClassName,
                    Value = m.ClassId.ToString()
                });
                return Json(selectItems, JsonRequestBehavior.AllowGet);
            }
            return Json(new List<string>(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LossEventList()
        {
            
            var query = from l in db.LossEvents
                       join k in db.KlasifikasiKerugians on l.KlasifikasiId equals k.KlasifikasiId
                       join s in db.SubDivs on l.SubDivId equals s.SubDivId
                       where l.SubDivId == data.SubDivId
                       select new joinLossEvent { lossEvent = l, klas = k, subdiv = s, pos = 1 };

            if(data.SubDivId == null)
            {
                query = from l in db.LossEvents
                            join k in db.KlasifikasiKerugians on l.KlasifikasiId equals k.KlasifikasiId
                            join b in db.Branches on l.BranchId equals b.BranchId
                            where l.BranchId == data.BranchId
                            select new joinLossEvent { lossEvent = l, klas = k, branch = b, pos = 2};
            }

           
            if (data.IsAdmin)
            {
                ViewBag.Message = "Tidak Bisa Melakukan Input Loss Event";
                return View("Error");
            }
            return View(query.ToList());
        }

        public ActionResult LossEventApprove()
        {
            if (!data.IsAdmin && !data.IsRiskOwner)
            {
                LossEventModel le = new LossEventModel();
                le.tglAwal = DateTime.Now;
                le.tglAkhir = DateTime.Now;

                var query = from l in db.LossEvents
                            join k in db.KlasifikasiKerugians on l.KlasifikasiId equals k.KlasifikasiId
                            join s in db.SubDivs on l.SubDivId equals s.SubDivId
                            where l.SubDivId == data.SubDivId
                            where l.ApproveDate == null
                            select new joinLossEvent { lossEvent = l, klas = k, subdiv = s, pos = 1 };

                if (data.BranchId != null)
                {
                    query = from l in db.LossEvents
                            join k in db.KlasifikasiKerugians on l.KlasifikasiId equals k.KlasifikasiId
                            join b in db.Branches on l.BranchId equals b.BranchId
                            where l.BranchId == data.BranchId
                            where l.ApproveDate == null
                            select new joinLossEvent { lossEvent = l, klas = k, branch = b, pos = 2 };
                }

                le.joinLossEvent = query;//.Where(m => m.lossEvent.ApproveDate == null).ToList();
                
                Dictionary<string, string> catList = new Dictionary<string, string>();
                foreach (var Klasifikasi in db.KlasifikasiKerugians.OrderBy(m => m.KlasifikasiId))
                    catList.Add(Klasifikasi.KlasifikasiId, Klasifikasi.Klasifikasi);
                le.klasifikasi = new SelectList(catList, "Key", "Value", 1);

                return View(le);
            }
            else
            {
                ViewBag.Message = "Tidak bisa melakukan approve loss event ";
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult LossEventApprove(LossEventModel le)
        {
            var query = from l in db.LossEvents
                        join k in db.KlasifikasiKerugians on l.KlasifikasiId equals k.KlasifikasiId
                        join s in db.SubDivs on l.SubDivId equals s.SubDivId
                        where l.SubDivId == data.SubDivId
                        where l.ApproveDate == null
                        where l.KlasifikasiId == le.lossEvent.KlasifikasiId
                        where l.LossDate >= le.tglAwal
                        where l.LossDate <= le.tglAkhir
                        select new joinLossEvent { lossEvent = l, klas = k, subdiv = s, pos = 1 };
            if (data.BranchId != null)
            {
                query = from l in db.LossEvents
                        join k in db.KlasifikasiKerugians on l.KlasifikasiId equals k.KlasifikasiId
                        join b in db.Branches on l.BranchId equals b.BranchId
                        where l.BranchId == data.BranchId
                        where l.ApproveDate == null
                        where l.KlasifikasiId == le.lossEvent.KlasifikasiId
                        where l.LossDate >= le.tglAwal
                        where l.LossDate <= le.tglAkhir
                        select new joinLossEvent { lossEvent = l, klas = k, branch = b, pos = 2 };
            }

            le.joinLossEvent = query.ToList();

            Dictionary<string, string> catList = new Dictionary<string, string>();
            foreach (var Klasifikasi in db.KlasifikasiKerugians.OrderBy(m => m.KlasifikasiId))
                catList.Add(Klasifikasi.KlasifikasiId, Klasifikasi.Klasifikasi);
            le.klasifikasi = new SelectList(catList, "Key", "Value", 1);

            return View(le);
        }

        public ActionResult Edit(int i)
        {
            LossEventModel le = new LossEventModel();
            le.lossEvent = db.LossEvents.Single(p => p.LossEventId == i);

            Dictionary<string, string> catList = new Dictionary<string, string>();
            foreach (var Klasifikasi in db.KlasifikasiKerugians.OrderBy(m => m.KlasifikasiId))
                catList.Add(Klasifikasi.KlasifikasiId, Klasifikasi.Klasifikasi);
            le.klasifikasi = new SelectList(catList, "Key", "Value", 1);

            Dictionary<string, string> coverageList = new Dictionary<string, string> {
                { "Nasional", "Nasional" },
                { "Kantor Pusat", "Kantor Pusat" },
                { "Kantor Cabang", "Kantor Cabang" },
                { "Korwil", "Korwil" },
                { "Kelas KC", "Kelas KC" },
            };
            le.cakupan = new SelectList(coverageList, "Key", "Value", 1);

            return View(le);
        }

        [HttpPost]
        public ActionResult Edit(LossEventModel le)
        {
            Askrindo.Models.LossEvent loss = db.LossEvents.Single(p => p.LossEventId == le.lossEvent.LossEventId);

            loss.Action = le.lossEvent.Action;
            loss.Assets = le.lossEvent.Assets;
            loss.ImpactFinancial = le.lossEvent.ImpactFinancial;
            loss.ImpactNonFinancial = le.lossEvent.ImpactNonFinancial;
            loss.Keterangan = le.lossEvent.Keterangan;
            loss.KlasifikasiId = le.lossEvent.KlasifikasiId;
            loss.Location = le.lossEvent.Location;
            loss.LossCause = le.lossEvent.LossCause;
            loss.LossDate = le.lossEvent.LossDate;
            loss.LossEventName = le.lossEvent.LossEventName;
            loss.PihakTerlibat = le.lossEvent.PihakTerlibat;

            loss.LossOwner = le.lossEvent.LossOwner;
            loss.ProductType = le.lossEvent.ProductType;
            loss.Tertanggung = le.lossEvent.Tertanggung;
            loss.DebiturTertanggung = le.lossEvent.DebiturTertanggung;
            loss.Obligee = le.lossEvent.Obligee;
            loss.Principal = le.lossEvent.Principal;
            loss.NilaiJaminan = le.lossEvent.NilaiJaminan;
            loss.Collateral = le.lossEvent.Collateral;
            loss.Project = le.lossEvent.Project;
            loss.CasePosition = le.lossEvent.CasePosition;
            loss.Affiliate = le.lossEvent.Affiliate;
            loss.CaseType = le.lossEvent.CaseType;
            loss.Coverage = le.lossEvent.Coverage;
            loss.Units = le.lossEvent.Units;
            loss.LossType = le.lossEvent.LossType;

            db.SaveChanges();

            return RedirectToAction("LossEventList");
        }

        public ActionResult delete(int i)
        {
            LossEventModel le = new LossEventModel();
            le.lossEvent = db.LossEvents.Single(p => p.LossEventId == i);

            Dictionary<string, string> catList = new Dictionary<string, string>();
            foreach (var Klasifikasi in db.KlasifikasiKerugians.OrderBy(m => m.KlasifikasiId))
                catList.Add(Klasifikasi.KlasifikasiId, Klasifikasi.Klasifikasi);
            le.klasifikasi = new SelectList(catList, "Key", "Value", 1);

            return View(le);
        }

        [HttpPost]
        public ActionResult delete(LossEventModel le)
        {
            db.LossEvents.Remove(db.LossEvents.Single(m => m.LossEventId == le.lossEvent.LossEventId));
            db.SaveChanges();
            return RedirectToAction("LossEventList");
        }

        public ActionResult Approve(int i)
        {
            LossEventModel le = new LossEventModel();
            le.lossEvent = db.LossEvents.Single(p => p.LossEventId == i);

            Dictionary<string, string> catList = new Dictionary<string, string>();
            foreach (var Klasifikasi in db.KlasifikasiKerugians.OrderBy(m => m.KlasifikasiId))
                catList.Add(Klasifikasi.KlasifikasiId, Klasifikasi.Klasifikasi);
            le.klasifikasi = new SelectList(catList, "Key", "Value", 1);

            return View(le);
        }

        [HttpPost]
        public ActionResult Approve(LossEventModel le)
        {
            Askrindo.Models.LossEvent loss = db.LossEvents.Single(p => p.LossEventId == le.lossEvent.LossEventId);
            loss.ApproveDate = DateTime.Now;
            loss.ApproveId = data.UserId;
            loss.Status = "1";
            //db.LossEvents.Attach(loss);
            db.SaveChanges();

            return RedirectToAction("lossEventApprove");
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult ShowApproved()
        {
            if (!data.IsAdmin || !data.IsRiskOwner)
            {
                LossEventModel le = new LossEventModel();

                var query = from l in db.LossEvents
                            join k in db.KlasifikasiKerugians on l.KlasifikasiId equals k.KlasifikasiId
                            join s in db.SubDivs on l.SubDivId equals s.SubDivId
                            where l.SubDivId == data.SubDivId
                            where l.ApproveDate != null
                            select new joinLossEvent { lossEvent = l, klas = k, subdiv = s, pos = 1 };

                if (data.BranchId != null)
                {
                    query = from l in db.LossEvents
                            join k in db.KlasifikasiKerugians on l.KlasifikasiId equals k.KlasifikasiId
                            join b in db.Branches on l.BranchId equals b.BranchId
                            where l.BranchId == data.BranchId
                            where l.ApproveDate != null
                            select new joinLossEvent { lossEvent = l, klas = k, branch = b, pos = 2 };
                    query.Where(m => m.lossEvent.BranchId == data.BranchId);
                }

                le.joinLossEvent = query;//.Where(m => m.lossEvent.ApproveDate != null).ToList();
                
                return View(le);
            }
            else
            {
                ViewBag.Message = "Tidak bisa melakukan approve loss event ";
                return View("Error");
            }
        }

        public ActionResult Detail(int? id)
        {
            LossEventModel le = new LossEventModel();
            le.lossEvent = db.LossEvents.Single(p => p.LossEventId == id);

            Dictionary<string, string> catList = new Dictionary<string, string>();
            foreach (var Klasifikasi in db.KlasifikasiKerugians.OrderBy(m => m.KlasifikasiId))
                catList.Add(Klasifikasi.KlasifikasiId, Klasifikasi.Klasifikasi);
            le.klasifikasi = new SelectList(catList, "Key", "Value", 1);

            return View(le);
        }
        
    }
}
