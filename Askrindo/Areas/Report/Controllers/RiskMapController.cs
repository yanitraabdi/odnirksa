using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;
using Askrindo.Areas.Report.Models.RiskMap;
using System.IO;
using Askrindo.Helpers;

namespace Askrindo.Areas.Report.Controllers
{
    [Authorize]
    public class RiskMapController : Controller
    {
        private AskrindoEntities db = new AskrindoEntities();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            RiskMapViewModel vm = new RiskMapViewModel();
            vm.Param = new RiskMapParam();
            vm.Param.PosId = 1;
            vm.Param.MapDate = DateTime.Now;
            vm.Param.MapDate2 = DateTime.Now;
            UpdateRiskMapParam(vm.Param);
            CalcRiskMap(vm);

            ViewBag.Title = "Peta Resiko";

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(RiskMapViewModel vm)
        {
            UpdateRiskMapParam(vm.Param);
            CalcRiskMap(vm);
            return View(vm);
        }

        public ActionResult ShowRisks(int prob, int impact, int? posId, int? branchId, DateTime mapDate, DateTime mapDate2, bool isApproved)
        {
            var risks = db.Risks.Where(p => p.ProbLevelId != null && p.ImpactLevelId != null);

            /*if (posId == 1)
                risks = risks.Where(p => p.DeptId != null);
            else if (posId == 2)
            {
                risks = risks.Where(p => p.BranchId != null);
                if (branchId != null)
                    risks = risks.Where(p => p.BranchId == branchId);
            }*/


            if (posId == 1)
                risks = risks.Where(p => p.DeptId != null || p.BranchId != null);
            else if (posId == 2)
            {
                risks = risks.Where(p => p.DeptId != null && p.SubDivId == branchId);
            }
            else if (posId == 3)
            {
                risks = risks.Where(p => p.BranchId != null);
                if (branchId != null)
                    risks = risks.Where(p => p.BranchId == branchId);
            }
            else if (posId == 4)
            {
                risks = risks.Where(p => p.BranchId != null);
                if (branchId != null)
                    risks = risks.Where(p => p.Branch.KorwilId == branchId);
            }
            else if (posId == 5)
            {
                risks = risks.Where(p => p.BranchId != null);
                if (branchId != null)
                    risks = risks.Where(p => p.Branch.ClassId == branchId);
            }


            if (isApproved)
            {
                risks = risks.Where(p => p.CloseDate == null || (p.CloseDate >= mapDate && p.CloseDate <= mapDate2));
                risks = risks.Where(p => p.ApprovalDate != null && (p.ApprovalDate <= mapDate2 && p.ApprovalDate > mapDate));
            }
            else
            {
                risks = risks.Where(p => p.ApprovalDate == null && (p.RiskDate <= mapDate2 && p.RiskDate >= mapDate));
                risks = risks.Where(p => p.ProbLevelId == prob && p.ImpactLevelId == impact);
            }

            List<Risk> riskList = new List<Risk>();
            foreach (var r in risks)
            {
                if (isApproved)
                {
                    var rm = db.RiskMitigations
                        .Where(p => p.RiskId == r.RiskId && p.ApprovalDate != null && (p.ApprovalDate <= mapDate2 && p.ApprovalDate >= mapDate) && p.ProbLevelId == prob && p.ImpactLevelId == impact)
                        .OrderByDescending(p => p.ApprovalDate);
                    if (rm.Count() > 0)
                        riskList.Add(r);
                    else
                    {
                        if (r.ProbLevelId == prob && r.ImpactLevelId == impact)
                            riskList.Add(r);
                    }
                }
                else
                    riskList.Add(r);
            }
            return View(riskList);
        }

        public void ExportToWord(int? posId, int? branchId, DateTime mapDate, DateTime mapDate2, bool isApproved)
        {
            RiskMapViewModel vm = new RiskMapViewModel();
            vm.Param = new RiskMapParam();
            vm.Param.PosId = posId;
            vm.Param.BranchId = branchId;
            vm.Param.MapDate = mapDate;
            vm.Param.MapDate2 = mapDate2;
            vm.Param.IsApproved = isApproved;
            CalcRiskMap(vm);

            var cnt = 0;
            var backColor = string.Empty;
            var foreColor = string.Empty;
            int prob = 0;
            int impact = 0;
            StringWriter sw = new StringWriter();

            sw.WriteLine("<table style='font-family: Tahoma, verdana; font-size: 1em'>");
            for (var i = 7; i >= 1; i--)
            {
                sw.WriteLine("<tr>");
                for (var j = 1; j <= 7; j++)
                {
                    prob = i - 2;
                    impact = j - 2;
                    if (i == 7 && j == 1)
                    {
                        sw.WriteLine("<td rowspan='7' style='width: 20px; text-align: center; font-weight: bold; font-size: 1em'>");
                        sw.WriteLine("P<br />R<br />O<br />B<br />A<br />B<br />I<br />L<br />I<br />T<br />A<br />S");
                        sw.WriteLine("</td>");
                    }
                    else if (i == 1 && j == 1)
                    {
                        sw.WriteLine("<td colspan='6' style='padding-top: 4px; text-align: center; font-weight: bold; font-size: 1em'>");
                        sw.WriteLine("D A M P A K");
                        sw.WriteLine("</td>");
                    }
                    else if (i == 1 && j > 1)
                    {
                    }
                    else if (j>1)
                    {
                        if (impact == 0 && prob != 0)
                        {
                            sw.WriteLine("<td style='padding-right: 8px; text-align: right; width: 80px; height: 46px; font-size: .85em'>");
                            sw.WriteLine(Utils.GetProbLevelText(prob));
                            sw.WriteLine("</td>");
                        }
                        else if (impact != 0 && prob == 0)
                        {
                            sw.WriteLine("<td style='padding-top: 4px; text-align: center; vertical-align: top; width: 80px; font-size: .85em'>");
                            sw.WriteLine(Utils.GetImpactLevelText(impact));
                            sw.WriteLine("</td>");
                        }
                        else if (impact == 0 && prob == 0)
                        {
                            sw.WriteLine("<td></td>");
                        }
                        else
                        {
                            Utils.GetRiskLevelColors(prob * impact, out backColor, out foreColor);
                            cnt = RiskMapViewModel.GetCount(prob, impact, vm.RiskList);
                            sw.WriteLine("<td style='text-align: center; background-color: " + backColor + "; color: " + foreColor + "'>");
                            if (cnt > 0)
                            {
                                sw.WriteLine("<div style='font-size: " + (8 + (decimal)cnt / (decimal)vm.MaxCount * 20M).ToString() + "pt; font-weight: bold'>");
                                sw.WriteLine(cnt);
                                sw.WriteLine("</div>");
                            }
                            sw.WriteLine("</td>");
                        }
                    }
                }
                sw.WriteLine("</tr>");
            }
            sw.WriteLine("</table>");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=risk_map.doc");
            Response.ContentType = "application/vnd.ms-word";
            Response.Write(sw.ToString());
            Response.End();
        }

        private void CalcRiskMap(RiskMapViewModel vm)
        {
            vm.RiskList = new List<Models.RiskMap.RiskMapData>();
            for (var i = 1; i <= 5; i++)
                for (var j = 1; j <= 5; j++)
                    vm.RiskList.Add(new RiskMapData { ProbLevelId = i, ImpactLevelId = j, Count = 0, RiskLevel = i * j });

            var risks = db.Risks.Where(p => p.ProbLevelId != null && p.ImpactLevelId != null);

            /*if (vm.Param.PosId == 1)
                risks = risks.Where(p => p.DeptId != null);
            else if (vm.Param.PosId == 2)
            {
                risks = risks.Where(p => p.BranchId != null);
                if (vm.Param.BranchId != null)
                    risks = risks.Where(p => p.BranchId == vm.Param.BranchId);
            }
             */

            if (vm.Param.PosId == 1)
                risks = risks.Where(p => p.DeptId != null || p.BranchId != null);
            else if (vm.Param.PosId == 2)
            {
                risks = risks.Where(p => p.DeptId != null && p.SubDivId == vm.Param.BranchId);
            }
            else if (vm.Param.PosId == 3)
            {
                risks = risks.Where(p => p.BranchId != null);
                if (vm.Param.BranchId != null)
                    risks = risks.Where(p => p.BranchId == vm.Param.BranchId);
            }
            else if (vm.Param.PosId == 4)
            {
                risks = risks.Where(p => p.BranchId != null);
                if (vm.Param.BranchId != null)
                    risks = risks.Where(p => p.Branch.KorwilId == vm.Param.BranchId);
            }
            else if (vm.Param.PosId == 5)
            {
                risks = risks.Where(p => p.BranchId != null);
                if (vm.Param.BranchId != null)
                    risks = risks.Where(p => p.Branch.ClassId == vm.Param.BranchId);
            }

            if (vm.Param.IsApproved)
            {
                risks = risks.Where(p => p.CloseDate == null || (p.CloseDate > vm.Param.MapDate && p.CloseDate < vm.Param.MapDate));
                risks = risks.Where(p => p.ApprovalDate != null && (p.ApprovalDate >= vm.Param.MapDate && p.ApprovalDate <= vm.Param.MapDate2));
            }
            else
            {
                risks = risks.Where(p => p.ApprovalDate == null && (p.RiskDate >= vm.Param.MapDate && p.RiskDate <= vm.Param.MapDate2));
            }

            foreach (var r in risks)
            {
                if (vm.Param.IsApproved)
                {
                    var rm = db.RiskMitigations
                        .Where(p => p.RiskId == r.RiskId && p.ApprovalDate != null && p.ApprovalDate >= vm.Param.MapDate && p.ApprovalDate <= vm.Param.MapDate2)
                        .OrderByDescending(p => p.ApprovalDate)
                        .First();
                    if (rm != null)
                        AddProbImpactToList((int)rm.ProbLevelId, (int)rm.ImpactLevelId, vm.RiskList);
                    else
                        AddProbImpactToList((int)r.ProbLevelId, (int)r.ImpactLevelId, vm.RiskList);
                }
                else
                    AddProbImpactToList((int)r.ProbLevelId, (int)r.ImpactLevelId, vm.RiskList);
            }
            vm.CalcMinMaxCount();
        }

        private void UpdateRiskMapParam(RiskMapParam param)
        {
            /*Dictionary<int, string> posList = new Dictionary<int, string>();
            posList.Add(1, "Nasional");
            posList.Add(2, "Kantor Pusat");
            posList.Add(3, "Kantor Cabang");
            posList.Add(4, "Korwil");
            posList.Add(5, "Kelas KC");
            param.PosList = new SelectList(posList, "Key", "Value", param.PosId);

            Dictionary<int, string> branchList = new Dictionary<int, string>();
            foreach (var branch in db.Branches.OrderBy(m => m.ClassId).ThenBy(m => m.BranchName))
                branchList.Add(branch.BranchId, branch.BranchName + " (Kelas " + branch.BranchClass.ClassName + ")");
            param.Branches = new SelectList(branchList, "Key", "Value", param.BranchId);
            */

            Dictionary<int, string> posList = new Dictionary<int, string>();
            posList.Add(1, "Nasional");
            posList.Add(2, "Kantor Pusat");
            posList.Add(3, "Kantor Cabang");
            posList.Add(4, "Korwil");
            posList.Add(5, "Kelas KC");
            param.PosList = new SelectList(posList, "Key", "Value", param.PosId);

            if (param.PosId == 2)
            {
                Dictionary<int, string> divList = new Dictionary<int, string>();
                foreach (var div in db.SubDivs.OrderBy(m => m.SubDivId).ThenBy(m => m.SubDivId))
                    divList.Add(div.SubDivId, div.SubDivName);
                param.Unit = new SelectList(divList, "Key", "Value", param.SubDivId);
            }
            else if (param.PosId == 3)
            {
                Dictionary<int, string> branchList2 = new Dictionary<int, string>();
                foreach (var branch in db.Branches.OrderBy(m => m.ClassId).ThenBy(m => m.BranchName))
                    branchList2.Add(branch.BranchId, branch.BranchName + " (Kelas " + branch.BranchClass.ClassName + ")");
                param.Unit = new SelectList(branchList2, "Key", "Value", param.BranchId);
            }
            else if (param.PosId == 4)
            {
                Dictionary<int, string> korwilList = new Dictionary<int, string>();
                foreach (var korwil in db.Korwils.OrderBy(m => m.KorwilId).ThenBy(m => m.Korwil1))
                    korwilList.Add(korwil.KorwilId, korwil.Korwil1);
                param.Unit = new SelectList(korwilList, "Key", "Value", param.BranchId);
            }
            else if (param.PosId == 5)
            {
                Dictionary<int, string> kelasList = new Dictionary<int, string>();
                foreach (var kelas in db.BranchClasses.OrderBy(m => m.ClassId).ThenBy(m => m.ClassName))
                    kelasList.Add(kelas.ClassId, kelas.ClassName);
                param.Unit = new SelectList(kelasList, "Key", "Value", param.BranchId);
            }
            else
            {
                param.Unit = new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }

        private void AddRiskToList(Risk r, List<RiskMapData> list)
        {
            foreach(var item in list)
                if (r.ProbLevelId == item.ProbLevelId && r.ImpactLevelId == item.ImpactLevelId)
                {
                    item.Count++;
                    return;
                }
        }

        private void AddProbImpactToList(int probLevel, int impactLevel, List<RiskMapData> list)
        {
            foreach (var item in list)
                if (item.ProbLevelId == probLevel && item.ImpactLevelId == impactLevel)
                {
                    item.Count++;
                    return;
                }
        }

        [HttpGet]
        public JsonResult LoadUnitKerja(string Id)
        {
            int id = string.IsNullOrEmpty(Id) ? 0 : Convert.ToInt32(Id);

            if (id == 2)
            {
                var list = db.SubDivs.ToList();
                var selectItems = list.Select(m => new SelectListItem()
                {
                    Text = m.SubDivName,
                    Value = m.SubDivId.ToString()
                });
                return Json(selectItems, JsonRequestBehavior.AllowGet);
            }
            else if (id == 3)
            {
                var list = db.Branches.ToList();
                var selectItems = list.Select(m => new SelectListItem()
                {
                    Text = m.BranchName,
                    Value = m.BranchId.ToString()
                });
                return Json(selectItems, JsonRequestBehavior.AllowGet);
            }
            else if (id == 4)
            {
                var list = db.Korwils.ToList();
                var selectItems = list.Select(m => new SelectListItem()
                {
                    Text = m.Korwil1,
                    Value = m.KorwilId.ToString()
                });
                return Json(selectItems, JsonRequestBehavior.AllowGet);
            }
            else if (id == 5)
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
    }
}
