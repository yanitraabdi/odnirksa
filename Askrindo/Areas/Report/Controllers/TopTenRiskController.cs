﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;
using Askrindo.Areas.Report.Models.TopTenRisk;
using Askrindo.Helpers;
using System.IO;

namespace Askrindo.Areas.Report.Controllers
{
    [Authorize]
    public class TopTenRiskController : Controller
    {
        private AskrindoEntities db = new AskrindoEntities();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index(bool? showMap)
        {
            TopTenViewModel vm = new TopTenViewModel();
            vm.RiskList = new List<Risk>();
            vm.TopTenList = new List<TopTenData>();
            vm.MapList = new List<TopTenMap>();
            vm.Param = new TopTenParam();
            vm.Param.PosId = 1;
            vm.Param.ReportDate = DateTime.Now;
            vm.Param.ReportDate2 = DateTime.Now;
            UpdateTopTenParam(vm.Param);
            CalcTopTenRisk(vm);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(TopTenViewModel vm, bool? showMap)
        {
            vm.RiskList = new List<Risk>();
            vm.TopTenList = new List<TopTenData>();
            vm.MapList = new List<TopTenMap>();
            UpdateTopTenParam(vm.Param);
            CalcTopTenRisk(vm);
            return View(vm);
        }

        public void ExportToExcel(int? posId, int? branchId, DateTime reportDate, DateTime reportDate2,
            bool isApproved, bool showOrg, bool showRiskCode, bool showRiskDate, 
            bool showRiskCat, bool showRiskCause, bool showRiskEffect,
            bool showRiskOwner, bool showProbLevel, bool showImpactLevel,
            bool showApprovedMitigations, bool showPlannedMitigations)
        {
            TopTenViewModel vm = new TopTenViewModel();
            vm.RiskList = new List<Risk>();
            vm.TopTenList = new List<TopTenData>();
            vm.MapList = new List<TopTenMap>();
            vm.Param = new TopTenParam();
            vm.Param.PosId = posId;
            vm.Param.BranchId = branchId;
            vm.Param.ReportDate = reportDate;
            vm.Param.ReportDate2 = reportDate2;
            vm.Param.IsApproved = isApproved;
            vm.Param.ShowOrg = showOrg;
            vm.Param.ShowRiskCode = showRiskCode;
            vm.Param.ShowRiskDate = showRiskDate;
            vm.Param.ShowRiskCat = showRiskCat;
            vm.Param.ShowRiskCause = showRiskCause;
            vm.Param.ShowRiskEffect = showRiskEffect;
            vm.Param.ShowRiskOwner = showRiskOwner;
            vm.Param.ShowProbLevel = showProbLevel;
            vm.Param.ShowImpactLevel = showImpactLevel;
            vm.Param.ShowApprovedMitigations = showApprovedMitigations;
            vm.Param.ShowPlannedMitigations = showPlannedMitigations;
            CalcTopTenRisk(vm);

            StringWriter sw = new StringWriter();

            sw.WriteLine("<table rules='all' border='1' style='border-collapse:collapse;'>");
            sw.WriteLine("<tr>");

            if (vm.Param.ShowRiskCode)
            {
                sw.WriteLine("<th style='background-color: #eee'>Kode Risiko</th>");
            }
            sw.WriteLine("<th style='background-color: #eee'>Peristiwa Risiko</th>");
            if (vm.Param.ShowRiskDate)
            {
                sw.WriteLine("<th style='background-color: #eee'>Tanggal</th>");
            }
            if (vm.Param.ShowOrg)
            {
                sw.WriteLine("<th style='background-color: #eee'>Unit Kerja</th>");
            }
            if (vm.Param.ShowRiskCat)
            {
                sw.WriteLine("<th style='background-color: #eee'>Klasifikasi Risiko</th>");
            }
            if (vm.Param.ShowRiskCause)
            {
                sw.WriteLine("<th style='background-color: #eee'>Sebab Risiko</th>");
            }
            if (vm.Param.ShowRiskEffect)
            {
                sw.WriteLine("<th style='background-color: #eee'>Akibat Risiko</th>");
            }
            if (vm.Param.ShowRiskOwner)
            {
                sw.WriteLine("<th style='background-color: #eee'>RCP</th>");
            }
            if (vm.Param.ShowProbLevel)
            {
                sw.WriteLine("<th style='background-color: #eee'>Tk. Prob</th>");
            }
            if (vm.Param.ShowImpactLevel)
            {
                sw.WriteLine("<th style='background-color: #eee'>Tk. Dampak</th>");
            }
            sw.WriteLine("<th style='background-color: #eee'>Tk. Risiko</th>");
            if (vm.Param.ShowApprovedMitigations)
            {
                sw.WriteLine("<th style='background-color: #eee'>Mitigasi yg telah Di-approve</th>");
            }
            if (vm.Param.ShowPlannedMitigations)
            {
                sw.WriteLine("<th style='background-color: #eee'>Rencana Mitigasi</th>");
            }
            if (vm.Param.ShowRiskOwner)
            {
                sw.WriteLine("<th style='background-color: #eee'>tes</th>");
            }
            sw.WriteLine("</tr>");
            foreach (var item in vm.TopTenList)
            {
                sw.WriteLine("<tr>");
                if (vm.Param.ShowRiskCode)
                {
                    sw.WriteLine(string.Format("<td>{0}</td>", item.Risk.RiskCode));
                }
                sw.WriteLine(string.Format("<td>{0}</td>", item.Risk.RiskName));
                if (vm.Param.ShowRiskDate)
                {
                    sw.WriteLine(string.Format("<td>{0:dd-MM-yyyy}</td>", item.Risk.RiskDate));
                }
                if (vm.Param.ShowOrg)
                { 
                    sw.WriteLine(string.Format("<td>{0}</td>", Utils.GetRiskOrgName(item.Risk)));
                }
                if (vm.Param.ShowRiskCat)
                {
                    sw.WriteLine("<td>");
                    if (item.Risk.RiskCat != null)
                    {
                        sw.WriteLine(item.Risk.RiskCat.RiskCatName);
                    }
                    sw.WriteLine("</td>");
                }
                if (vm.Param.ShowRiskCause)
                {
                    sw.WriteLine("<td>");
                    if (item.Risk.Caus != null)
                    {
                        sw.WriteLine(item.Risk.Caus.CauseName);
                    }
                    sw.WriteLine("</td>");
                }
                if (vm.Param.ShowRiskEffect)
                {
                    sw.WriteLine("<td>");
                    if (item.Risk.Effect != null)
                    {
                        sw.WriteLine(item.Risk.Effect.EffectName);
                    }
                    sw.WriteLine("</td>");
                }
                if (vm.Param.ShowRiskOwner)
                {
                    sw.WriteLine("<td>{0}</td>", item.Risk.UserInfo.FullName);
                }
                if (vm.Param.ShowProbLevel)
                {
                    sw.WriteLine("<td align='center'>{0}</td>", item.Risk.ProbLevelId);
                }
                if (vm.Param.ShowImpactLevel)
                {
                    sw.WriteLine("<td align='center'>{0}</td>", item.Risk.ImpactLevelId);
                }
                sw.WriteLine("<td align='center'>{0}</td>", item.Risk.RiskLevel);

                if (vm.Param.ShowApprovedMitigations)
                {
                    sw.WriteLine("<td valign='top' style='padding: 0'>");
                            if (item.ApprovedMitigations.Count() > 0)
                            {
                                sw.WriteLine("<table rules='all' border='1' style='border-collapse:collapse;'>");
                                    sw.WriteLine("<tr>");
                                        if (vm.Param.ShowRiskCode)
                                        {
                                        sw.WriteLine("<th style='background-color: #eee'>Kode Mitigasi</th>");
                                        }
                                        sw.WriteLine("<th style='background-color: #eee'>Uraian</th>");
                                        if (vm.Param.ShowRiskDate)
                                        {
                                            sw.WriteLine("<th style='background-color: #eee'>Tanggal</th>");
                                        }
                                        if (vm.Param.ShowProbLevel)
                                        {
                                            sw.WriteLine("<th style='background-color: #eee'>Tk. Prob</th>");
                                        }
                                        if (vm.Param.ShowImpactLevel)
                                        {
                                            sw.WriteLine("<th style='background-color: #eee'>Tk. Dampak</th>");
                                        }
                                        sw.WriteLine("<th style='background-color: #eee'>Tk. Risiko</th>");
                                    sw.WriteLine("</tr>");
                                foreach (var m in item.ApprovedMitigations)
                                { 
                                    sw.WriteLine("<tr>");
                                        if (vm.Param.ShowRiskCode)
                                        {
                                        sw.WriteLine(string.Format("<td>{0}</td>", m.MitigationCode));
                                        }
                                        sw.WriteLine(string.Format("<td>{0}</td>", m.MitigationName));
                                        if (vm.Param.ShowRiskDate)
                                        {
                                            sw.WriteLine(string.Format("<td>{0:dd-MM-yyyy}</td>", m.MitigationDate));
                                        }
                                        if (vm.Param.ShowProbLevel)
                                        {
                                        sw.WriteLine(string.Format("<td align='center'>{0}</td>", m.ProbLevelId));
                                        }
                                        if (vm.Param.ShowImpactLevel)
                                        {
                                        sw.WriteLine(string.Format("<td align='center'>{0}</td>", m.ImpactLevelId));
                                        }
                                        sw.WriteLine(string.Format("<td align='center'>{0}</td>", m.RiskLevel));
                                    sw.WriteLine("</tr>");
                                }
                                sw.WriteLine("</table>");
                            }
                            sw.WriteLine("</td>");
                            }

                            if (vm.Param.ShowPlannedMitigations)
                            {
                            sw.WriteLine("<td valign='top' style='padding: 0'>");
                            if (item.PlannedMitigations.Count() > 0)
                            {
                                sw.WriteLine("<table rules='all' border='1' style='border-collapse:collapse;'>");
                                    sw.WriteLine("<tr>");
                                        if (vm.Param.ShowRiskCode)
                                        {
                                        sw.WriteLine("<th style='background-color: #eee'>Kode Mitigasi</th>");
                                        }
                                        sw.WriteLine("<th style='background-color: #eee'>Uraian</th>");
                                        if (vm.Param.ShowRiskDate)
                                        {
                                            sw.WriteLine("<th style='background-color: #eee'>Tanggal</th>");
                                        }
                                        if (vm.Param.ShowProbLevel)
                                        {
                                            sw.WriteLine("<th style='background-color: #eee'>Tk. Prob</th>");
                                        }
                                        if (vm.Param.ShowImpactLevel)
                                        {
                                            sw.WriteLine("<th style='background-color: #eee'>Tk. Dampak</th>");
                                        }
                                        sw.WriteLine("<th style='background-color: #eee'>Tk. Risiko</th>");
                                    sw.WriteLine("</tr>");
                                foreach (var m in item.PlannedMitigations)
                                { 
                                    sw.WriteLine("<tr>");
                                        if (vm.Param.ShowRiskCode)
                                        {
                                        sw.WriteLine(string.Format("<td>{0}</td>", m.MitigationCode));
                                        }
                                        sw.WriteLine(string.Format("<td>{0}</td>", m.MitigationName));
                                        if (vm.Param.ShowRiskDate)
                                        {
                                            sw.WriteLine(string.Format("<td>{0:dd-MM-yyyy}</td>", m.MitigationDate));
                                        }
                                        if (vm.Param.ShowProbLevel)
                                        {
                                        sw.WriteLine(string.Format("<td align='center'>{0}</td>", m.ProbLevelId));
                                        }
                                        if (vm.Param.ShowImpactLevel)
                                        {
                                        sw.WriteLine(string.Format("<td align='center'>{0}</td>", m.ImpactLevelId));
                                        }
                                        sw.WriteLine(string.Format("<td align='center'>{0}</td>", m.RiskLevel));
                                    sw.WriteLine("</tr>");
                                }
                                sw.WriteLine("</table>");
                            }
                            sw.WriteLine("</td>");
                            }
                            if (vm.Param.ShowRiskOwner)
                            {
                                sw.WriteLine("<td>{0}</td>", item.Risk.UserInfo.FullName);
                            }
                        sw.WriteLine("</tr>");
                    }
            sw.WriteLine("</table>");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=top_ten_risks.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(sw.ToString());
            Response.End();
        }

        private void CalcTopTenRisk(TopTenViewModel vm)
        {
            /*var risks = db.Risks.Where(p => p.ProbLevelId != null && p.ImpactLevelId != null);
            if (vm.Param.PosId == 1)
                risks = risks.Where(p => p.DeptId != null);
            else if (vm.Param.PosId == 2)
            {
                risks = risks.Where(p => p.BranchId != null);
                if (vm.Param.BranchId != null)
                    risks = risks.Where(p => p.BranchId == vm.Param.BranchId);
            }
             */

            var risks = db.Risks.Where(p => p.ProbLevelId != null && p.ImpactLevelId != null);
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
                risks.Where(p => p.Branch.KorwilId == vm.Param.BranchId);
            }
            else if (vm.Param.PosId == 5)
            {
                risks = risks.Where(p => p.BranchId != null);
                if (vm.Param.BranchId != null)
                    risks = risks.Where(p => p.Branch.ClassId == vm.Param.BranchId);
            }

            if (vm.Param.IsApproved)
            {
                risks = risks.Where(p => p.CloseDate == null || (p.CloseDate > vm.Param.ReportDate && p.CloseDate < vm.Param.ReportDate2));
                risks = risks.Where(p => p.ApprovalDate != null && (p.ApprovalDate >= vm.Param.ReportDate && p.ApprovalDate <= vm.Param.ReportDate2));
            }
            else
            {
                risks = risks.Where(p => p.ApprovalDate == null && (p.RiskDate >= vm.Param.ReportDate && p.RiskDate <= vm.Param.ReportDate2));
            }

            foreach (var r in risks)
            {
                //if (vm.Param.IsApproved)
                //{
                //    var rm = db.RiskMitigations.Where(p => p.RiskId == r.RiskId && p.ApprovalDate != null && p.ApprovalDate <= vm.Param.ReportDate);
                //    if (rm.Count() > 0)
                //    {
                //        var m = rm.OrderByDescending(p => p.ApprovalDate).First();
                //        AddRiskToList(r, (int)m.ProbLevelId, (int)m.ImpactLevelId, vm.RiskList);
                //    }
                //    else
                //        vm.RiskList.Add(r);
                //}
                //else
                //    vm.RiskList.Add(r);
                vm.RiskList.Add(r);
            }
            vm.RiskList = vm.RiskList.OrderByDescending(p => p.RiskLevel).ThenByDescending(p => p.ImpactLevelId).ThenByDescending(p => p.ProbLevelId).Take(10).ToList();
            foreach (var r in vm.RiskList)
            {
                TopTenData data = new TopTenData();
                data.Risk = r;
                data.ApprovedMitigations = db.RiskMitigations.Where(p => p.RiskId == r.RiskId && p.ApprovalDate != null).ToList();
                data.PlannedMitigations = db.RiskMitigations.Where(p => p.RiskId == r.RiskId && p.ApprovalDate == null).ToList();
                vm.TopTenList.Add(data);
            }

            // map processing here...

            for (var i = 1; i <= 5; i++)
                for (var j = 1; j <= 5; j++)
                    vm.MapList.Add(new TopTenMap() { ProbLevelId = i, ImpactLevelId = j, Count = 0, RiskLevel = i * j });

            foreach (var r in vm.RiskList)
                foreach(var m in vm.MapList)
                    if (r.ProbLevelId == m.ProbLevelId && r.ImpactLevelId == m.ImpactLevelId)
                    {
                        m.Count++;
                        break;
                    }

            vm.MaxCount = 0;
            var maxCount = int.MinValue;
            foreach (var m in vm.MapList)
                if (maxCount < m.Count)
                    maxCount = m.Count;
            vm.MaxCount = maxCount;
        }

        private void AddRiskToList(Risk r, int newProb, int newImpact, List<Risk> list)
        {
            r.ProbLevelId = newProb;
            r.ImpactLevelId = newImpact;
            r.RiskLevel = newProb * newImpact;
            list.Add(r);
        }

        private void UpdateTopTenParam(TopTenParam param)
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
