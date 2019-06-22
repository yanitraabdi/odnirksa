using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Areas.RCSA.Models;
using Askrindo.Helpers;
using Askrindo.Models;
using PagedList;

namespace Askrindo.Areas.RCSA.Controllers
{
    public class MitigationController : Controller
    {
        private Askrindo.Models.AskrindoEntities db = new Askrindo.Models.AskrindoEntities();

        // GET: RCSA/Mitigation
        public ActionResult Index(string currentFilter, string searchString, string statusFilter, int? page, int? pageSize)
        {
            ViewBag.currentPage = "Daftar Mitigasi";
            ViewBag.title = "Daftar Mitigasi";
            ViewBag.CurrentPageSize = (pageSize ?? 10);

            var riskMitigationData = from s in db.RiskMitigations where db.Risks.Any(r => r.RiskId == s.RiskId) select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();

                if (searchString.Contains(" "))
                {
                    string[] keywords = searchString.Split(' ');
                    riskMitigationData = riskMitigationData.Where(r => r.MitigationCode.Contains(searchString) || keywords.All(k => r.Risk.RiskName.Contains(k)));
                }
                else
                {
                    riskMitigationData = riskMitigationData.Where(r => r.MitigationCode.Contains(searchString) || r.Risk.RiskName.Contains(searchString));
                }
            }

            if (!String.IsNullOrEmpty(statusFilter))
            {
                statusFilter = statusFilter.Trim().ToLower();

                switch (statusFilter)
                {
                    case "process":
                        riskMitigationData = riskMitigationData.Where(p => p.IsReadOnly && p.ApprovalDate == null);
                        break;
                    case "approved":
                        riskMitigationData = riskMitigationData.Where(p => p.ApprovalDate != null);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                riskMitigationData = riskMitigationData.Where(p => !p.IsReadOnly && p.ApprovalDate == null);
            }

            int selectedPageSize = (pageSize ?? 10);
            int pageNumber = (page ?? 1);
            var risks = riskMitigationData.OrderByDescending(r => r.MitigationDate).ToPagedList(pageNumber, selectedPageSize);

            return View(risks);
        }

        public ActionResult List(int id)
        {
            var risk = db.Risks.Where(r => r.RiskId == id).FirstOrDefault();

            return View(risk);
        }

        public ActionResult New(int id) {

            var vm = new MitigationViewModel {
                Risk = db.Risks.Where(r => r.RiskId == id).FirstOrDefault()
            };

            vm.MitigationCats = new SelectList(db.MitigationCats, "MitigationCatId", "MitigationCatName");
            vm.MitigationTypes = new SelectList(Enumerable.Empty<SelectListItem>(), "MitigationTypeId", "MitigationTypeName");

            Dictionary<int, string> probList = new Dictionary<int, string>();
            foreach (var item in db.ProbLevels)
                probList.Add(item.ProbLevelId, item.ProbLevelId + " - " + item.ProbLevelName);
            vm.ProbLevels = new SelectList(probList, "Key", "Value");

            Dictionary<int, string> impactList = new Dictionary<int, string>();
            foreach (var item in db.ImpactLevels)
                impactList.Add(item.ImpactLevelId, item.ImpactLevelId + " - " + item.ImpactLevelName);
            vm.ImpactLevels = new SelectList(impactList, "Key", "Value");

            vm.RiskMitigation = new RiskMitigation();
            vm.RiskMitigation.RiskId = id;
            vm.RiskMitigation.MitigationCode = Utils.CreateNewMitigationCode(id);
            vm.RiskMitigation.InputDate = DateTime.Now;
            vm.RiskMitigation.MitigationDate = DateTime.Now;
            vm.RiskMitigation.OrgPos = vm.Risk.OrgPos;

            return View(vm);
        }

        [HttpPost]
        public ActionResult New(MitigationViewModel vm)
        {
            if (ModelState.IsValid)
            {

                vm.Risk = db.Risks.Where(p => p.RiskId == vm.RiskMitigation.RiskId).FirstOrDefault();
                vm.RiskMitigation.RiskLevel = vm.RiskMitigation.ProbLevelId * vm.RiskMitigation.ImpactLevelId;
                vm.RiskMitigation.DeptId = vm.Risk.DeptId;
                vm.RiskMitigation.SubDeptId = vm.Risk.SubDeptId;
                vm.RiskMitigation.DivisionId = vm.Risk.DivisionId;
                vm.RiskMitigation.SubDivId = vm.Risk.SubDivId;
                vm.RiskMitigation.BranchId = vm.Risk.BranchId;
                vm.RiskMitigation.SubBranchId = vm.Risk.SubBranchId;
                vm.RiskMitigation.BizUnitId = vm.Risk.BizUnitId;
                db.RiskMitigations.Add(vm.RiskMitigation);
                db.SaveChanges();

                Utils.CreateFirstMitigationApprovalSchedule(vm.RiskMitigation);
                db.SaveChanges();

                return RedirectToAction("List", new { id = vm.RiskMitigation.RiskId });
            }
            return View(vm);
        }

        [HttpGet]
        public JsonResult LoadMitigationTypes(string catId)
        {
            var id = string.IsNullOrEmpty(catId) ? 0 : Convert.ToInt32(catId);
            var types = db.MitigationTypes.Where(p => p.MitigationCatId == id).ToList();
            var selectItems = types.Select(p => new SelectListItem()
            {
                Text = p.MitigationTypeName,
                Value = p.MitigationTypeId.ToString()
            });
            return Json(selectItems, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            MitigationViewModel vm = new MitigationViewModel();
            vm.RiskMitigation = db.RiskMitigations.Where(p => p.MitigationId == id).FirstOrDefault();

            vm.MitigationCats = new SelectList(db.MitigationCats, "MitigationCatId", "MitigationCatName", vm.RiskMitigation.MitigationCatId);
            vm.MitigationTypes = new SelectList(db.MitigationTypes.Where(p => p.MitigationCatId == vm.RiskMitigation.MitigationCatId), "MitigationTypeId", "MitigationTypeName", vm.RiskMitigation.MitigationTypeId);

            Dictionary<int, string> probList = new Dictionary<int, string>();
            foreach (var item in db.ProbLevels)
                probList.Add(item.ProbLevelId, item.ProbLevelId + " - " + item.ProbLevelName);
            vm.ProbLevels = new SelectList(probList, "Key", "Value", vm.RiskMitigation.ProbLevelId);

            Dictionary<int, string> impactList = new Dictionary<int, string>();
            foreach (var item in db.ImpactLevels)
                impactList.Add(item.ImpactLevelId, item.ImpactLevelId + " - " + item.ImpactLevelName);
            vm.ImpactLevels = new SelectList(impactList, "Key", "Value", vm.RiskMitigation.ImpactLevelId);

            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(MitigationViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var lastMitigation = vm.RiskMitigation;

                var mitigation = db.RiskMitigations.Single(r => r.MitigationId == vm.RiskMitigation.MitigationId);

                mitigation.MitigationDate = lastMitigation.MitigationDate;
                mitigation.MitigationCatId = lastMitigation.MitigationCatId;
                mitigation.MitigationTypeId = lastMitigation.MitigationTypeId;
                mitigation.ProbLevelId = lastMitigation.ProbLevelId;
                mitigation.ImpactLevelId = lastMitigation.ImpactLevelId;
                mitigation.MitigationName = lastMitigation.MitigationName;

                db.SaveChanges();
            }

            return RedirectToAction("List", new { id = vm.RiskMitigation.RiskId });
        }

        public ActionResult Detail(int id)
        {
            RiskMitigation mitigation = db.RiskMitigations.Where(p => p.MitigationId == id).FirstOrDefault();
            return View(mitigation);
        }

        public ActionResult Approve(int id)
        {
            RiskMitigation mitigation = db.RiskMitigations.Where(p => p.MitigationId == id).FirstOrDefault();
            return View(mitigation);
        }

        [HttpPost]
        public ActionResult Approve(RiskMitigation riskMitigation)
        {
            var apr = db.MitigationApprovals.Where(m => m.MitigationId == riskMitigation.MitigationId).OrderByDescending(m => m.LastApproval).FirstOrDefault();

            try
            {
                Utils.ApproveMitigation(apr.ApprovalId, db);
            }
            catch (Exception e)
            {
                ViewBag.Message = "Tidak bisa meng-approve data mitigasi risiko : " + e.Message;
                return View("Error");
            }

            return RedirectToAction("Detail", new { id = riskMitigation.MitigationId });
        }

        public ActionResult MitigationAction()
        {
            var userData = Utils.LoadUserDataFromSession();
            MitigationActionModel ma = new MitigationActionModel();
            ma.tglAwal = DateTime.Now;
            ma.tglAkhir = DateTime.Now;
            ma.RiskMitigations = db.RiskMitigations.Where(m => (m.SubDivId == userData.SubDivId) && (m.ApprovalDate != null) && (m.InputDate >= ma.tglAwal && m.InputDate <= ma.tglAkhir));

            if (userData.IsRiskOwner)
            {
                return View(ma);
            }
            else if (userData.IsAdmin)
            {
                ViewBag.Message = "Tidak bisa melakukan input progress tindakan mitigasi ";
                return View("Error");
            }
            else
                return View(ma);
        }

        [HttpPost]
        public ActionResult MitigationAction(MitigationActionModel ma)
        {
            var userData = Utils.LoadUserDataFromSession();

            if (ma.mitigationcode == null)
            {
                ma.RiskMitigations = db.RiskMitigations.Where(m => (m.ApprovalDate != null) && (m.InputDate >= ma.tglAwal && m.InputDate <= ma.tglAkhir)).OrderByDescending(m => m.ApprovalDate);
            }
            else
            {
                ma.RiskMitigations = db.RiskMitigations.Where(m => (m.ApprovalDate != null) && (m.InputDate >= ma.tglAwal && m.InputDate <= ma.tglAkhir) && (m.MitigationCode == ma.mitigationcode)).OrderByDescending(m => m.ApprovalDate);
            }

            if (userData.BranchId == null)
            {
                ma.RiskMitigations = ma.RiskMitigations.Where(m => m.SubDivId == userData.SubDivId);
            }
            else
            {
                ma.RiskMitigations = ma.RiskMitigations.Where(m => m.BranchId == userData.BranchId);
            }

            return View(ma);
        }

        public ActionResult MitigationActionList(int id)
        {
            MitigationActionModel ma = new MitigationActionModel();
            ma.actionList = db.MitigationsActions.Where(m => m.MitigationId == id).ToList();
            ma.mitigationid = id;
            return View(ma);
        }


        public ActionResult MitigationActionNew(int id)
        {
            MitigationActionModel ma = new MitigationActionModel();
            var no = db.MitigationsActions.Count(m => m.MitigationId == id);

            ma.mitigationid = id;
            ma.riskMitigation = db.RiskMitigations.Single(m => m.MitigationId == id);
            ma.mitigationcode = ma.riskMitigation.MitigationCode;
            ma.mitigationactioncode = ma.mitigationcode + "." + (no + 1);
            ma.prob = new SelectList(db.ProbLevels, "ProbLevelId", "ProbLevelName");
            ma.impact = new SelectList(db.ImpactLevels, "ImpactLevelId", "ImpactLevelName");

            return View(ma);
        }

        [HttpPost]
        public ActionResult MitigationActionNew(MitigationActionModel ma)
        {
            var userData = Utils.LoadUserDataFromSession();
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        using (TransactionScope trans = new TransactionScope())
            //        {
            MitigationsAction ac = new MitigationsAction();

            ac.ActionCode = ma.mitigationactioncode;
            ac.MitigationId = ma.mitigationid;

            var rm = new RiskMitigation();
            rm = db.RiskMitigations.SingleOrDefault(p => p.MitigationId == ma.mitigationid);

            ac.ActionDate = DateTime.Now;
            ac.ActionName = ma.actionName;
            ac.BizUnitId = userData.BizUnitId;
            ac.BranchId = userData.BranchId;
            ac.DeptId = userData.DeptId;
            ac.DivisionId = userData.DivisionId;
            ac.LimitDate = ma.limitDate;
            ac.PIC2 = ma.pic;
            ac.Require = ma.require;
            ac.RKAPF = ma.isRKAP1;
            ac.SubBranchId = userData.SubBranchId;
            ac.SubDeptId = userData.SubDeptId;
            ac.SubDivId = userData.SubDivId;
            ac.UserId = userData.UserId;
            ac.ImpactLevelId = rm.ImpactLevelId;
            ac.ImpactLevel = rm.ImpactLevel;
            ac.ProbLevel = rm.ProbLevel;
            ac.ProbLevelId = rm.ProbLevelId;
            db.MitigationsActions.Add(ac);
            db.SaveChanges();

            ActionApproval ap = new ActionApproval();
            MitigationsAction id = new MitigationsAction();
            id = db.MitigationsActions.Single(p => p.ActionCode == ma.mitigationactioncode);
            ap.ActionID = id.ActionID;
            ap.BizUnitId = userData.BizUnitId;
            ap.BranchId = userData.BranchId;
            ap.DeptId = userData.DeptId;
            ap.DivisionId = userData.DivisionId;
            ap.SubBranchId = userData.SubBranchId;
            ap.SubDeptId = userData.SubDeptId;
            ap.SubDivId = userData.SubDivId;
            db.ActionApprovals.Add(ap);
            db.SaveChanges();
            //            trans.Complete();
            return RedirectToAction("MitigationActionEdit", new { id = id.ActionID });
            //        }
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}
            //return RedirectToAction("MitigationActionEdit");
        }



        public ActionResult MitigationActionEdit(int id)
        {
            MitigationsAction ma = new MitigationsAction();
            MitigationActionModel mm = new MitigationActionModel();
            ma = db.MitigationsActions.Single(p => p.ActionID == id);
            mm.mitigationactioncode = ma.ActionCode;
            var mid = db.RiskMitigations.Single(p => p.MitigationId == ma.MitigationId);
            mm.mitigationcode = mid.MitigationCode;
            mm.pic = ma.PIC2;
            mm.require = ma.Require;
            mm.limitDate = ma.LimitDate;
            mm.isRKAP1 = (bool)ma.RKAPF;
            mm.actionId = ma.ActionID;
            mm.actionName = ma.ActionName;
            mm.mitigationid = ma.MitigationId;
            mm.biaya = ma.Biaya;
            if (ma.TotalProgress == null)
            {
                mm.totalProgress = 0;
            }
            else
            {
                mm.totalProgress = (decimal)ma.TotalProgress;
            }

            return View(mm);
        }

        [HttpPost]
        public ActionResult MitigationActionEdit(MitigationActionModel ma)
        {
            MitigationsAction ac = new MitigationsAction();
            ac = db.MitigationsActions.Single(m => m.ActionCode == ma.mitigationactioncode);

            ac.ActionName = ma.actionName;
            ac.LimitDate = ma.limitDate;
            ac.PIC2 = ma.pic;
            ac.Require = ma.require;
            ac.Biaya = ma.biaya;
            ac.RKAPF = ma.isRKAP1;
            db.SaveChanges();

            return RedirectToAction("MitigationActionList", new { id = ac.MitigationId });

        }


        public ActionResult ProgressIndex(int id)
        {
            MitigationActionModel ma = new MitigationActionModel();
            ma.progressList = db.ActionProgresses.Where(m => m.ActionID == id).ToList();
            ma.actionId = id;
            return View(ma);
        }

        public ActionResult ProgressNew(int id)
        {
            MitigationActionModel ma = new MitigationActionModel();
            ma.actionId = id;
            ma.action = db.MitigationsActions.Single(m => m.ActionID == id);
            return View(ma);
        }

        [HttpPost]
        public ActionResult ProgressNew(MitigationActionModel ma)
        {
            ActionProgress ap = new ActionProgress();
            MitigationsAction mc = new MitigationsAction();

            if (db.ActionProgresses.Count() == 0)
            {
                ap.ActionProgressID = 1;
            }
            else
            {
                var id = db.ActionProgresses.OrderByDescending(p => p.ActionProgressID).First();
                ap.ActionProgressID = id.ActionProgressID + 1;
            }

            ap.ActionID = ma.actionId;
            ap.RecordDate = DateTime.Now;
            ap.ActionProgress1 = ma.ActionProgress;
            db.ActionProgresses.Add(ap);
            db.SaveChanges();

            mc = db.MitigationsActions.Single(p => p.ActionID == ma.actionId);
            mc.TotalProgress = ma.ActionProgress;
            db.SaveChanges();

            return RedirectToAction("ProgressIndex", new { id = ma.actionId });
        }

        public ActionResult MitigationActionApp()
        {
            var userData = Utils.LoadUserDataFromSession();
            if (!userData.IsAdmin && !userData.IsRiskOwner)
            {
                MitigationActionAppModel ma = new MitigationActionAppModel();

                var action = from act in db.MitigationsActions
                             join app in db.ActionApprovals
                                 on act.ActionID equals app.ActionID
                             where ((act.DivisionId == null)
                             && (act.SubDivId == null)
                             && (app.ApprovelDate == null))
                             select act;

                ma.actionList = action;
                ma.tglAwal = DateTime.Now;
                ma.tglAkhir = DateTime.Now;
                return View(ma);
            }
            else
            {
                ViewBag.Message = "Tidak bisa melakukan approve tindakan mitigasi ";
                return View("Error");
            }
        }


        [HttpPost]
        public ActionResult MitigationActionApp(MitigationActionAppModel ma)
        {
            var userData = Utils.LoadUserDataFromSession();
            if (ma.isApproved)
            {
                if (ma.mitigationcode == null)
                {
                    var action = from act in db.MitigationsActions
                                 join app in db.ActionApprovals
                                     on act.ActionID equals app.ActionID
                                 where ((act.DivisionId == userData.DivisionId)
                                 //    && (act.SubDivId == userData.SubDivId)
                                 && (app.ApprovelDate != null)
                                 && ((act.ActionDate >= ma.tglAwal)
                                 && (act.ActionDate <= ma.tglAkhir)))

                                 select act;

                    ma.actionList = action;
                }
                else
                {
                    var action = from act in db.MitigationsActions
                                 join app in db.ActionApprovals
                                     on act.ActionID equals app.ActionID
                                 where ((act.DivisionId == userData.DivisionId)
                                //   && (act.SubDivId == userData.SubDivId)
                                && (app.ApprovelDate != null)
                                 && ((act.ActionDate >= ma.tglAwal)
                                 && (act.ActionDate <= ma.tglAkhir))
                                 && (act.RiskMitigation.MitigationCode == ma.mitigationcode))
                                 select act;
                    ma.actionList = action;
                }
            }
            else
            {
                if (ma.mitigationcode == null)
                {
                    var action = from act in db.MitigationsActions
                                 join app in db.ActionApprovals
                                     on act.ActionID equals app.ActionID
                                 where ((act.DivisionId == userData.DivisionId)
                                 // && (act.SubDivId == userData.SubDivId)
                                 && (act.ActionDate >= ma.tglAwal)
                                 && (act.ActionDate <= ma.tglAkhir)
                                 && (act.ActionApproval.ApprovelDate == null))
                                 select act;

                    ma.actionList = action;
                }
                else
                {
                    var action = from act in db.MitigationsActions
                                 join app in db.ActionApprovals
                                     on act.ActionID equals app.ActionID
                                 where ((act.DivisionId == userData.DivisionId)
                                 //&& (act.SubDivId == userData.SubDivId)
                                 && (act.ActionDate >= ma.tglAwal)
                                 && (act.ActionDate <= ma.tglAkhir)
                                 && (act.ActionApproval.ApprovelDate == null)
                                 && (act.RiskMitigation.MitigationCode == ma.mitigationcode))
                                 select act;
                    ma.actionList = action;
                }
            }

            return View(ma);
        }

        [HttpPost]
        public ActionResult MitigationActionAppView(MitigationActionAppModel ma)
        {
            var data = Utils.LoadUserDataFromSession();

            ma.actionApp = db.ActionApprovals.SingleOrDefault(m => m.ActionID == ma.actionId);
            ma.actionApp.UserId = data.UserId;
            if (ma.actionApp.status == null)
            {
                ma.actionApp.ApprovelDate = DateTime.Now;
                ma.actionApp.status = 1;
            }
            //db.ActionApprovals.Attach(ma.actionApp);
            db.SaveChanges();

            return RedirectToAction("MitigationActionApp");
        }

        public ActionResult MitigationActionAppView(int id)
        {
            //if (userData.IsRiskOwner)
            //{
            MitigationActionAppModel ma = new MitigationActionAppModel();
            ma.actionId = id;
            ma.action = db.MitigationsActions.Single(m => m.ActionID == id);
            ma.mitigation = db.RiskMitigations.Single(m => m.MitigationId == ma.action.MitigationId);

            return View(ma);
            //}
        }
    }
}