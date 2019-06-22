using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Areas.Report.Models.RiskRegister;
using Askrindo.Models;
using Askrindo.Helpers;
using System.IO;

namespace Askrindo.Areas.Report.Controllers
{
    [Authorize]
    public class RiskRegisterController : Controller
    {
        AskrindoEntities db = new AskrindoEntities();

        public ActionResult Index()
        {
            RiskRegisterViewModel vm = new RiskRegisterViewModel();
            
            vm.Param = new Param();
            vm.Param.IsApproved = true;
            vm.Param.ReportDate = DateTime.Now;
            vm.Param.ReportDate2 = DateTime.Now;
            UpdateParam(vm.Param);
            CalcRiskRegister(vm);
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(RiskRegisterViewModel vm)
        {
            UpdateParam(vm.Param);
            CalcRiskRegister(vm);
            return View(vm);
        }

        public void ExportToExcel(int? posId, int? branchId, int? klasId, int? riskLevelId, int? riskLevelId2, DateTime reportDate, DateTime reportDate2,
            bool isApproved, bool showOrg, bool showRiskCode, bool showRiskDate, bool showRiskType,
            bool showRiskCat, bool showRiskCause, bool showRiskEffect,
            bool showRiskOwner, bool showProbLevel, bool showImpactLevel,
            bool showApprovedMitigations, bool showPlannedMitigations, bool showUraianProgress,
            bool showPIC, bool showUnitKerja, bool showResource,
            bool showEstimasi, bool showRKAP, bool showProgress)
        {
            RiskRegisterViewModel vm = new RiskRegisterViewModel();
            vm.RiskList = new List<RiskRecord>();
            vm.Param = new Param();
            vm.Param.PosId = posId;
            vm.Param.BranchId = branchId;
            vm.Param.KlasId = klasId;
            vm.Param.RiskLevelId = riskLevelId;
            vm.Param.RiskLevelId2 = riskLevelId2;
            vm.Param.ReportDate = reportDate;
            vm.Param.ReportDate2 = reportDate2;
            vm.Param.IsApproved = isApproved;
            vm.Param.ShowOrg = showOrg;
            vm.Param.ShowRiskCode = showRiskCode;
            vm.Param.ShowRiskDate = showRiskDate;
            vm.Param.ShowRiskCat = showRiskCat;
            vm.Param.ShowRiskType = showRiskType;
            vm.Param.ShowRiskCause = showRiskCause;
            vm.Param.ShowRiskEffect = showRiskEffect;
            vm.Param.ShowRiskOwner = showRiskOwner;
            vm.Param.ShowProbLevel = showProbLevel;
            vm.Param.ShowImpactLevel = showImpactLevel;
            vm.Param.ShowApprovedMitigations = showApprovedMitigations;
            vm.Param.ShowPlannedMitigations = showPlannedMitigations;
            vm.Param.ShowUraianProgress = showUraianProgress;
            vm.Param.ShowPIC = showPIC;
            vm.Param.ShowUnitKerja = showUnitKerja;
            vm.Param.ShowResource = showResource;
            vm.Param.ShowEstimasi = showEstimasi;
            vm.Param.ShowRKAP = showRKAP;
            vm.Param.ShowProgress = showProgress;
            CalcRiskRegister(vm);

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
                sw.WriteLine("<th style='background-color: #eee'>Kelompok Risiko</th>");
            }
            if (vm.Param.ShowRiskType)
            {
                sw.WriteLine("<th style='background-color: #eee'>Jenis Risiko</th>");
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
            sw.WriteLine("</tr>");
            foreach (var item in vm.RiskList)
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
                    sw.WriteLine("<td>");
                    if (item.Risk.RiskGroup != null)
                    {
                        sw.WriteLine(item.Risk.RiskGroup.RiskGroupName);
                    }
                    sw.WriteLine("</td>");
                }
                if (vm.Param.ShowRiskType)
                {
                    sw.WriteLine("<td>");
                    if (item.Risk.RiskType != null)
                    {
                        sw.WriteLine(item.Risk.RiskType.RiskTypeName);
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

                            sw.WriteLine("<td style='padding: 0'>");
                            if (item.MitigationActionApprove.Count() > 0)
                            {
                                sw.WriteLine("<table rules='all' border='1' style='border-collapse:collapse;'>");
                                sw.WriteLine("<tr>");
                                if (vm.Param.ShowUraianProgress)             
                                {
                                    sw.WriteLine("<th rowspan= '2'>Uraian Progress</th>");     
                                }
                                if (vm.Param.ShowPIC)
                                {
                                    sw.WriteLine("<th rowspan= '2'>PIC</th>");     
                                }
                                if (vm.Param.ShowUnitKerja)
                                {
                                    sw.WriteLine("<th rowspan= '2'>Unit Kerja Terkait</th>");     
                                }
                                if (vm.Param.ShowResource)
                                {
                                sw.WriteLine("<th rowspan= '2'>Resource Requirement</th>");     
                                }
                                if (vm.Param.ShowEstimasi)
                                {
                                sw.WriteLine("<th rowspan= '2'>Estimasi Biaya</th>");     
                                }
                                if (vm.Param.ShowRKAP)
                                {
                                sw.WriteLine("<th rowspan= '2'>RKAP/RTL?</th>");     
                                }
                                if (vm.Param.ShowProgress)
                                {
                                sw.WriteLine("<th colspan = '3'>Progress Mitigasi</th>");
                                }
                                sw.WriteLine("</tr>");
                            sw.WriteLine("<tr>");
                                sw.WriteLine("<th>Belum Berjalan</th>");
                                sw.WriteLine("<th>Sedang Berjalan</th>");
                                sw.WriteLine("<th>Sudah Selesai</th>");
                            sw.WriteLine("</tr>");
                        foreach (var c in item.MitigationActionApprove)
                        {
                            sw.WriteLine("<tr>");
                            if (vm.Param.ShowUraianProgress)
                            {
                            sw.WriteLine(string.Format("<td align='center'>{0}</td>", c.RiskMitigation.MitigationName));    
                            }
                            if (vm.Param.ShowPIC)
                            {
                            sw.WriteLine(string.Format("<td align='center'>{0}</td>", c.PIC2));  
                            }
                            if (vm.Param.ShowUnitKerja)
                            {
                            sw.WriteLine(string.Format("<td align='center'>{0}</td>", Utils.GetRiskOrgName(item.Risk)));  
                            }
                            if (vm.Param.ShowResource)
                            {
                            sw.WriteLine(string.Format("<td align='center'>{0}</td>", c.Require));    
                            }
                            if (vm.Param.ShowEstimasi)
                            {
                            sw.WriteLine(string.Format("<td align='center'>{0}</td>", c.Biaya));
                            }
                            if (vm.Param.ShowRKAP)
                            {
                            sw.WriteLine(string.Format("<td align='center'>{0}</td>", c.RKAPF));
                            }
                            if (vm.Param.ShowProgress)
                            {
                                if (c.TotalProgress <= 0)
                                {
                                    sw.WriteLine("<td align='center'>&#9745</td>");
                                    sw.WriteLine("<td></td>");
                                    sw.WriteLine("<td></td>");
                                }
                                if (c.TotalProgress > 0 && c.TotalProgress < 100)
                                {
                                    sw.WriteLine("<td></td>");
                                    sw.WriteLine("<td align='center'>&#9745</td>");
                                    sw.WriteLine("<td></td>");
                                }
                                if (c.TotalProgress >= 100)
                                {
                                    sw.WriteLine("<td></td>");
                                    sw.WriteLine("<td></td>");
                                    sw.WriteLine("<td align='center'>&#9745</td>");
                                }
                            }
                            sw.WriteLine("</tr>");
                        }
                        sw.WriteLine("</table>");
                    }
                    sw.WriteLine("</td>");
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
                sw.WriteLine("</tr>");
            }
            sw.WriteLine("</table>");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=risk_registers.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(sw.ToString());
            Response.End();
        }

        private void UpdateParam(Param param)
        {
            Dictionary<int, string> posList = new Dictionary<int, string>();
            posList.Add(1, "Nasional");
            posList.Add(2, "Kantor Pusat");
            posList.Add(3, "Kantor Cabang");
            posList.Add(4, "Korwil");
            posList.Add(5, "Kelas KC");
            param.PosList = new SelectList(posList, "Key", "Value", param.PosId);

            Dictionary<int, string> KlasList = new Dictionary<int, string>();
            KlasList.Add(1, "Risiko Utama");
            KlasList.Add(2, "Proses Bisnis");
            param.KlasList = new SelectList(KlasList, "Key", "Value", param.KlasId);

            if (param.KlasId == 2)
            {
                Dictionary<int, string> BisnisList = new Dictionary<int, string>();
                foreach (var bisnis in db.RiskGroups.Where(m => m.RiskCatId == 13).OrderBy(m => m.RiskGroupId).ThenBy(m => m.RiskGroupName))
                    BisnisList.Add(bisnis.RiskGroupId, bisnis.RiskGroupName);
                param.BisnisList = new SelectList(BisnisList, "Key", "Value", param.BisnisId);
            }
            else
            {
                param.BisnisList = new SelectList(Enumerable.Empty<SelectListItem>());
            }
            
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


            
            Dictionary<int, string> levelList = new Dictionary<int, string>();
            levelList.Add(1, "x <= 5");
            levelList.Add(2, "5 < x <= 8");
            levelList.Add(3, "8 < x <= 12");
            levelList.Add(4, "12 < x <= 25");
            param.RiskLevels = new SelectList(levelList, "Key", "Value", param.RiskLevelId);
             

        }

        private void CalcRiskRegister(RiskRegisterViewModel vm)
        {   
            var risks = db.Risks.Where(p => p.ProbLevelId != null && p.ImpactLevelId != null);
            if (vm.Param.PosId == 1)
                risks = risks.Where(p => p.DeptId != null || p.BranchId != null);
            else if (vm.Param.PosId == 2)
            {
                risks = risks.Where(p => p.SubDivId != null && p.DeptId != null);
                if (vm.Param.BranchId != null)
                {
                    risks = risks.Where(p => p.DeptId != null && p.SubDivId == vm.Param.BranchId);
                }  
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
                risks = risks.Where(p => p.CloseDate == null || (p.CloseDate >= vm.Param.ReportDate && p.CloseDate <= vm.Param.ReportDate2));
                risks = risks.Where(p => p.ApprovalDate != null && (p.ApprovalDate >= vm.Param.ReportDate && p.ApprovalDate <= vm.Param.ReportDate2));
            }
            else
            {
                risks = risks.Where(p => p.ApprovalDate == null && (p.RiskDate >= vm.Param.ReportDate && p.RiskDate <= vm.Param.ReportDate2));
            }
            risks = risks.OrderBy(p => p.RiskDate);

            /*switch(vm.Param.RiskLevelId)
            {
                case 1: // x <= 5
                    risks = risks.Where(p => p.RiskLevel <= 5);
                    break;
                case 2: // 5 < x <= 8
                    risks = risks.Where(p => p.RiskLevel > 5 && p.RiskLevel <= 8);
                    break;
                case 3: // 8 < x <= 12
                    risks = risks.Where(p => p.RiskLevel > 8 && p.RiskLevel <= 12);
                    break;
                case 4: // 12 < x <= 25
                    risks = risks.Where(p => p.RiskLevel > 12 && p.RiskLevel <= 25);
                    break;
            }*/
            risks = risks.Where(p => p.RiskLevel >= vm.Param.RiskLevelId && p.RiskLevel <= vm.Param.RiskLevelId2);

            if (vm.Param.KlasId == 2)
            {
                if (vm.Param.BisnisId != null)
                {
                    risks = risks.Where(p => p.RiskCatId == 13 && p.RiskGroupId == vm.Param.BisnisId).OrderBy(p => p.RiskEventId);
                }
                else
                {
                    risks = risks.Where(p => p.RiskCatId == 13);
                }
            }
            else
            {
                risks = risks.Where(p => p.RiskCatId != 13);
            }

            vm.RiskList = new List<RiskRecord>();
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
                RiskRecord rc = new RiskRecord();
                rc.Risk = r;
                rc.ApprovedMitigations = db.RiskMitigations.Where(p => p.RiskId == r.RiskId && p.ApprovalDate != null).ToList();
                rc.PlannedMitigations = db.RiskMitigations.Where(p => p.RiskId == r.RiskId && p.ApprovalDate == null).ToList();

                foreach(var a in rc.ApprovedMitigations)
                {
                    rc.MitigationActionApprove = db.MitigationsActions.Where(p => p.MitigationId == a.MitigationId).ToList();
                    rc.MitigationUnit = db.MitigationUnits.Where(p => p.MitigationId == a.MitigationId).ToList();
                }

                vm.RiskList.Add(rc);
            }
            //vm.RiskList = vm.RiskList.OrderByDescending(p => p.RiskLevel).ThenByDescending(p => p.ImpactLevelId).ThenByDescending(p => p.ProbLevelId).Take(10).ToList();
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

        [HttpGet]
        public JsonResult LoadProsesBisnis(string Id)
        {
            int id = string.IsNullOrEmpty(Id) ? 0 : Convert.ToInt32(Id);

            if (id == 2)
            {
                var list = db.RiskGroups.Where(m => m.RiskCatId == 13).ToList();
                var selectItems = list.Select(m => new SelectListItem()
                {
                    Text = m.RiskGroupName,
                    Value = m.RiskGroupId.ToString()
                });
                return Json(selectItems, JsonRequestBehavior.AllowGet);
            }
            return Json(new List<string>(), JsonRequestBehavior.AllowGet);
        }
    }
}
