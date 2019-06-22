using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Askrindo.Areas.RCSA.Models;
using Askrindo.Helpers;
using Askrindo.Models;

namespace Askrindo.Areas.RCSA.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        private Askrindo.Models.AskrindoEntities db = new Askrindo.Models.AskrindoEntities();

        // GET: RCSA/Default
        public ActionResult Index(string currentFilter, string searchString, string statusFilter, int? page, int? pageSize)
        {
            ViewBag.currentPage = "Daftar Risiko";
            ViewBag.title = "Daftar Risiko";
            ViewBag.CurrentPageSize = (pageSize ?? 10);

            var riskData = from s in db.Risks where s.RiskGroupId != null select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim();

                if (searchString.Contains(" "))
                {
                    string[] keywords = searchString.Split(' ');
                    riskData = riskData.Where(r => r.RiskCode.Contains(searchString) || keywords.All(k => r.RiskName.Contains(k)));
                }
                else
                {
                    riskData = riskData.Where(r => r.RiskCode.Contains(searchString) || r.RiskName.Contains(searchString));
                }
            }

            if (!String.IsNullOrEmpty(currentFilter))
            {
                currentFilter = currentFilter.Trim();

                switch (currentFilter)
                {
                    case "7":
                        riskData = riskData.Where(s => s.RiskGroup.RiskCat.RiskCatName != "Proses Bisnis" && s.RiskGroup.RiskGroupName != "Fraud");
                        break;
                    case "bp":
                        riskData = riskData.Where(s => s.RiskGroup.RiskCat.RiskCatName == "Proses Bisnis");
                        break;
                    case "f":
                        riskData = riskData.Where(s => s.RiskGroup.RiskGroupName == "Fraud");
                        break;
                }
            }

            if (!String.IsNullOrEmpty(statusFilter))
            {
                statusFilter = statusFilter.Trim().ToLower();

                switch (statusFilter)
                {
                    case "process":
                        riskData = riskData.Where(p => p.IsReadOnly && p.ApprovalDate == null && p.CloseDate == null);
                        break;
                    case "approved":
                        riskData = riskData.Where(p => p.ApprovalDate != null && p.CloseDate == null);
                        break;
                    case "closed":
                        riskData = riskData.Where(p => p.CloseDate != null);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                riskData = riskData.Where(p => !p.IsReadOnly && p.ApprovalDate == null && p.CloseDate == null);
            }

            int selectedPageSize = (pageSize ?? 10);
            int pageNumber = (page ?? 1);
            var risks = riskData.OrderByDescending(r => r.RiskDate).ToPagedList(pageNumber, selectedPageSize);

            return View(risks);
        }

        // GET: RCSA/Default/Detail/id
        public ActionResult Detail(int id)
        {
            ViewBag.currentPage = "Detail Risiko";

            var riskData = db.Risks
                .Include("RiskEvent")
                .Include("RiskEvent.RiskType")
                .Include("RiskEvent.RiskType.RiskGroup")
                .Include("RiskEvent.RiskType.RiskGroup.RiskCat")
                .FirstOrDefault(d => d.RiskId == id);

            if (riskData == null) {
                return RedirectToAction("Index");
            }

            ViewBag.title = "Daftar Risiko";

            var riskDataVM = new RiskViewModel {
                RiskData = riskData,
                AttachmentList = db.RiskAttachments.Where(s => s.RiskId == riskData.RiskId).ToList(),
                ImpactCats = db.ImpactCats.ToList(),
                RiskImpact = db.RiskImpacts.Where(ri => ri.RiskId == id).FirstOrDefault(),
                RiskNonMoneyImpact = db.RiskNonMoneyImpacts.Where(ri => ri.RiskId == id).FirstOrDefault(),
                Freqs = db.Freqs.ToList(),
                RiskProb = db.RiskProbs.Where(rp => rp.RiskId == id).FirstOrDefault()
            };
            return View(riskDataVM);
        }

        public ActionResult ApproveRisk(int id)
        {
            var apr = db.RiskApprovals.Where(p => p.RiskId == id).OrderByDescending(p => p.ApprovalId).FirstOrDefault();
            return View(apr);
        }

        [HttpPost, ActionName("ApproveRisk")]
        public ActionResult ApproveRiskConfirmed(int id)
        {
            UserData data = Utils.LoadUserDataFromSession();
            var apr = db.RiskApprovals.Where(p => p.ApprovalId == id).FirstOrDefault();

            using (var trans = db.Database.BeginTransaction())
            {
                try
                {
                    apr.ApprovalDate = DateTime.Now;
                    apr.UserId = data.UserId;
                    apr.JobTitle = data.JobTitle;
                    db.SaveChanges();

                    apr.Risk.IsReadOnly = true;
                    db.SaveChanges();

                    if (apr.LastApproval)
                    {
                        // risk approval completed
                        apr.Risk.ApprovalDate = apr.ApprovalDate;
                        db.SaveChanges();

                        var prevApr = db.RiskApprovals
                            .Where(p => p.RiskId == apr.RiskId && p.ApprovalId != apr.ApprovalId && p.ApprovalDate != null)
                            .FirstOrDefault();
                        if (prevApr != null)
                        {
                            prevApr.IsReadOnly = true;
                            db.SaveChanges();
                        }

                        var rs = new RiskState();
                        rs.RiskId = apr.RiskId;
                        rs.StateDate = (DateTime)apr.ApprovalDate;
                        rs.ProbLevelId = (int)apr.Risk.ProbLevelId;
                        rs.ImpactLevelId = (int)apr.Risk.ImpactLevelId;
                        rs.RiskLevel = (int)apr.Risk.RiskLevel;
                        db.RiskStates.Add(rs);
                        db.SaveChanges();
                    }
                    else
                    {
                        // next approval schedule
                        RiskApproval nextApr = new RiskApproval();
                        nextApr.RiskId = apr.RiskId;
                        nextApr.LimitDate = DateTime.Now.AddDays(Utils.MAX_LIMIT_APPROVAL_DAYS);
                        nextApr.LastApproval = true;

                        switch (apr.OrgPos)
                        {
                            case Utils.ORGPOS_SUBDIV:
                                SubDiv subDiv = db.SubDivs.Single(p => p.SubDivId == apr.SubDivId);
                                nextApr.OrgPos = Utils.ORGPOS_DIVISION;
                                nextApr.DivisionId = subDiv.DivisionId;
                                nextApr.OrgName = subDiv.Division.DivisionName;
                                break;
                            case Utils.ORGPOS_SUBBRANCH:
                                SubBranch subBranch = db.SubBranches.Single(p => p.SubBranchId == apr.SubBranchId);
                                nextApr.OrgPos = Utils.ORGPOS_BRANCH;
                                nextApr.BranchId = subBranch.BranchId;
                                nextApr.OrgName = subBranch.Branch.BranchName;
                                break;
                            case Utils.ORGPOS_BIZUNIT:
                                BizUnit biz = db.BizUnits.Single(p => p.BizUnitId == apr.BizUnitId);
                                nextApr.OrgPos = Utils.ORGPOS_BRANCH;
                                nextApr.BranchId = biz.BranchId;
                                nextApr.OrgName = biz.Branch.BranchName;
                                break;
                        }
                        db.RiskApprovals.Add(nextApr);
                        db.SaveChanges();
                    }
                    trans.Commit();
                }
                catch (Exception e)
                {
                    trans.Rollback();

                    ViewBag.Message = "Tidak bisa meng-approve data peristiwa risiko : " + e.Message;

                    return View("Error");
                }
            }
            return RedirectToAction("Detail", new { id = apr.RiskId });
        }

        public ActionResult Test() {
            return View("Error");
        }

        [HttpPost]
        public ActionResult SubmitProbability(RCSAInputProbabilityModel rCSAInputProbabilityModel) {
            var formData = Request.Form;

            var probType = rCSAInputProbabilityModel.prob_type; ///formData["prob-type"];
            var riskId = 123;//int.Parse(formData["riskId"]);

            var risk = db.Risks.Where(r => r.RiskId == riskId).FirstOrDefault();

            var prob = db.RiskProbs.Where(rp => rp.RiskId == riskId).FirstOrDefault();

            double? value = null;
            int probLevelId;

            switch (probType)
            {
                case "avail":
                    var tbAvail = double.Parse(formData["tb-avail"], System.Globalization.CultureInfo.InvariantCulture);

                    prob.ProbValue = (decimal)tbAvail;
                    prob.ProbOption = 1;

                    value = tbAvail;
                    break;
                case "appr":
                    var tbAp1 = double.Parse(formData["tb-ap1"], System.Globalization.CultureInfo.InvariantCulture);
                    var tbAp2 = double.Parse(formData["tb-ap2"], System.Globalization.CultureInfo.InvariantCulture);
                    var tbAp3 = double.Parse(formData["tb-ap3"], System.Globalization.CultureInfo.InvariantCulture);

                    prob.Approx1 = (decimal)tbAp1;
                    prob.Approx2 = (decimal)tbAp2;
                    prob.Approx3 = (decimal)tbAp3;

                    value = ((double)prob.Approx1 + 4 * (double)prob.Approx2 + (double)prob.Approx3) / 6;
                    prob.Poisson1 = null;
                    prob.Poisson2 = null;
                    prob.Binom1 = null;
                    prob.Binom2 = null;
                    prob.Compare = null;
                    prob.FreqId = null;

                    prob.ProbOption = 3;
                    break;
                case "diff":
                    var tbDiff = double.Parse(formData["tb-diff"], System.Globalization.CultureInfo.InvariantCulture);

                    prob.Compare = (decimal)tbDiff;

                    value = tbDiff;
                    prob.Poisson1 = null;
                    prob.Poisson2 = null;
                    prob.Binom1 = null;
                    prob.Binom2 = null;
                    prob.Approx1 = null;
                    prob.Approx2 = null;
                    prob.Approx3 = null;
                    prob.FreqId = null;

                    prob.ProbOption = 4;
                    break;
                case "freq":
                    var sbFreq = int.Parse(formData["sb-freq"]);
                    prob.FreqId = sbFreq;

                    prob.ProbOption = 5;

                    break;
                default:
                    break;
            }


            decimal? probValue = null;
            if (value != null)
            {
                probValue = Convert.ToDecimal(value);
                probLevelId = Utils.GetProbLevelFromValue((decimal)probValue);
            }
            else
                probLevelId = (int)prob.FreqId;

            prob.ProbValue = probValue;
            prob.ProbLevelId = probLevelId;
            
            risk.ProbValue = prob.ProbValue;
            risk.ProbLevelId = prob.ProbLevelId;
            Utils.CalcRiskLevel(risk);

            risk.IsProbSet = true;

            db.SaveChanges();

            return RedirectToAction("Detail", new { id = riskId });
        }

        public JsonResult GetImpactDetail(int id)
        {
            var data = db.ImpactDetails.Where(d => d.ImpactTypeId == id);
            return Json(data.Select(d => new {
                Id = d.ImpactDetailId,
                LevelId = d.ImpactLevelId,
                LevelName = d.ImpactLevel.ImpactLevelName,
                TypeName = d.ImpactType.ImpactTypeName,
                Detail = d.ImpactDetailName
            }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRiskImpact(RiskViewModel riskVM) {
            var impactSubmit = riskVM.RiskImpact;
            var impact = db.RiskImpacts.Where(d => d.RiskId == impactSubmit.RiskId).First();
            var data = Utils.LoadUserDataFromSession();

            impact.MoneyDirect = impactSubmit.MoneyDirect;
            impact.MoneyIndirect = impactSubmit.MoneyIndirect;

            decimal moneyValue = 0M;
            if (impact.MoneyDirect != null)
                moneyValue += (decimal)impact.MoneyDirect;
            if (impact.MoneyIndirect != null)
                moneyValue += (decimal)impact.MoneyIndirect;

            var impactPos = Utils.GetImpactPos(data);
            var level = Utils.GetImpactLevelFromMoney(moneyValue, impactPos);

            impact.ImpactLevelId = level;
            impact.IsMoneyImpact = true;

            var risk = db.Risks.Single(p => p.RiskId == impact.RiskId);
            risk.ImpactMoney = moneyValue;
            risk.ImpactLevelId = level;
            Utils.CalcRiskLevel(risk);

            SetImpactFlag(risk);

            return RedirectToAction("Detail", new { id = impactSubmit.RiskId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRiskImpactNonMoney(RiskViewModel riskVM)
        {
            var riskNM = riskVM.RiskNonMoneyImpact;
            var riskImpactData = db.RiskNonMoneyImpacts.Where(r => r.RiskId == riskNM.RiskId).FirstOrDefault();
            var risk = db.Risks.Where(d => d.RiskId == riskNM.RiskId).First();

            riskNM.ImpactDetailId = db.ImpactDetails.Where(d => d.ImpactTypeId == riskNM.ImpactTypeId && d.ImpactLevelId == riskNM.ImpactLevelId).First().ImpactDetailId;

            if (riskImpactData == null)
            {
                db.RiskNonMoneyImpacts.Add(riskNM);
            }
            else
            {
                riskImpactData.ImpactTypeId = riskNM.ImpactTypeId;
                riskImpactData.ImpactLevelId = riskNM.ImpactLevelId;
                riskImpactData.ImpactDetailId = riskNM.ImpactDetailId;
            }

            SetImpactFlag(risk);

            return RedirectToAction("Detail", new { id = riskVM.RiskNonMoneyImpact.RiskId });
        }

        private void SetImpactFlag(Risk risk)
        {
            risk.IsImpactSet = true;
            db.SaveChanges();
        }
    }
}