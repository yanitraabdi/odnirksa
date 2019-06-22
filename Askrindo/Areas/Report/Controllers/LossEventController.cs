using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Areas.Report.Models.LossEvent;
using Askrindo.Models;
using System.IO;
using Askrindo.Helpers;

namespace Askrindo.Areas.Report.Controllers
{
    public class LossEventController : Controller
    {
        //
        // GET: /Report/LossEvent/
        AskrindoEntities db = new AskrindoEntities();

        public ActionResult Index()
        { 
            LossEventViewModel vm = new LossEventViewModel();

            vm.Param = new Param();
            vm.Param.IsApproved = true;
            vm.Param.ReportDate = DateTime.Now;
            vm.Param.ReportDate2 = DateTime.Now;
            UpdateParam(vm.Param);
            CalcLossEvent(vm);
            
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(LossEventViewModel vm)
        {
            UpdateParam(vm.Param);
            CalcLossEvent(vm);
            return View(vm);
        }

        public ActionResult IndexPemilik()
        {
            LossEventViewModel vm = new LossEventViewModel();

            vm.Param = new Param();
            vm.Param.IsApproved = true;
            vm.Param.ReportDate = DateTime.Now;
            vm.Param.ReportDate2 = DateTime.Now;
            UpdateParam(vm.Param);
            CalcLossEvent(vm);

            return View(vm);
        }

        [HttpPost]
        public ActionResult IndexPemilik(LossEventViewModel vm)
        {
            UpdateParam(vm.Param);
            CalcPemilik(vm);

            return View(vm);
        }

        public ActionResult IndexTahun()
        {
            LossEventViewModel vm = new LossEventViewModel();

            vm.Param = new Param();
            vm.Param.IsApproved = true;
            vm.Param.ReportDate = DateTime.Now;
            vm.Param.ReportDate2 = DateTime.Now;
            UpdateParam(vm.Param);
            CalcLossEvent(vm);

            return View(vm);
        }

        [HttpPost]
        public ActionResult IndexTahun(LossEventViewModel vm)
        {
            UpdateParam(vm.Param);

            if (vm.Param.PeriodeId == 1)
            {
                CalcLossEventTahun(vm);
            }
            else
            {
                CalcLossEventBulan(vm);
            }

            return View(vm);
        }

        public ActionResult IndexKantor()
        {
            LossEventViewModel vm = new LossEventViewModel();

            vm.Param = new Param();
            vm.Param.IsApproved = true;
            vm.Param.ReportDate = DateTime.Now;
            vm.Param.ReportDate2 = DateTime.Now;
            UpdateParam(vm.Param);
            CalcLossEvent(vm);

            return View(vm);
        }

        [HttpPost]
        public ActionResult IndexKantor(LossEventViewModel vm)
        {
            UpdateParam(vm.Param);
            CalcLossEventKantor(vm);

            return View(vm);
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

            Dictionary<int, string> periodeList = new Dictionary<int, string>();
            periodeList.Add(1, "Tahun");
            periodeList.Add(2, "Bulan");
            param.Periode = new SelectList(periodeList, "Key", "Value", param.PeriodeId);
            
            Dictionary<string, string> klasList = new Dictionary<string, string>();
            foreach (var klas in db.KlasifikasiKerugians.OrderBy(m => m.KlasifikasiId).ThenBy(m => m.Klasifikasi))
                klasList.Add( klas.KlasifikasiId, klas.Klasifikasi);
            param.klasList = new SelectList(klasList, "Key", "Value", param.KlasId);

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

        private IQueryable<Askrindo.Models.LossEvent> lossvm(LossEventViewModel vm)
        {
            var loss = db.LossEvents.Where(p => p.InputDate != null);
            if (vm.Param.PosId == 1)
                loss = loss.Where(p => p.DeptId != null || p.BranchId != null);
            else if (vm.Param.PosId == 2)
            {
                loss = loss.Where(p => p.DeptId != null && p.SubDivId == vm.Param.BranchId);
            }
            else if (vm.Param.PosId == 3)
            {
                loss = loss.Where(p => p.BranchId != null);
                if (vm.Param.BranchId != null)
                    loss = loss.Where(p => p.BranchId == vm.Param.BranchId);
            }
            else if (vm.Param.PosId == 4)
            {
                var query = from b in db.Branches
                            join l in db.LossEvents on b.BranchId equals l.BranchId
                            where b.KorwilId == vm.Param.BranchId
                            select l;
                loss = query;
            }

            if (vm.Param.KlasId != null)
            {
                var i = vm.Param.KlasId.ToString();
                loss = loss.Where(k => k.KlasifikasiId == i);
            }

            if (vm.Param.IsApproved)
            {
                loss = loss.Where(p => p.LossDate == null || (p.LossDate >= vm.Param.ReportDate && p.LossDate <= vm.Param.ReportDate2));
                loss = loss.Where(p => p.ApproveDate != null && (p.ApproveDate >= vm.Param.ReportDate && p.ApproveDate <= vm.Param.ReportDate2));
            }
            else
            {
                loss = loss.Where(p => p.ApproveDate == null && (p.LossDate >= vm.Param.ReportDate && p.LossDate <= vm.Param.ReportDate2));
            }

            loss = loss.OrderBy(p => p.LossDate);

            return loss;

        }

        private void CalcLossEvent(LossEventViewModel vm)
        {
            var loss = lossvm(vm);

            vm.LossList = new List<LossRecord>();
            foreach (var r in loss)
            {
                LossRecord lr = new LossRecord();
                lr.lossEvent = r;
                lr.klas = db.KlasifikasiKerugians.Where(p => p.KlasifikasiId == r.KlasifikasiId).SingleOrDefault();
                if (r.BranchId == null)
                {
                    var pemilik = db.SubDivs.Where(p => p.SubDivId == r.SubDivId).FirstOrDefault();
                    lr.pemilik = pemilik.SubDivName;
                }
                else
                {
                    var pemilik = db.Branches.Where(p => p.BranchId == r.BranchId).FirstOrDefault();
                    lr.pemilik = pemilik.BranchName;
                }
                vm.LossList.Add(lr);
            }
        }

        private void CalcPemilik(LossEventViewModel vm)
        {
            var lossP = db.LossEventPemilikViews.Where(m => m.tahun <= vm.Param.ReportDate2.Year && m.tahun >= vm.Param.ReportDate.Year);

            if (vm.Param.BranchId != null)
            {
                lossP = lossP.Where(m => m.id_pemilik == vm.Param.BranchId);
            }

            if (vm.Param.KlasId != null)
            {
                var i = vm.Param.KlasId.ToString();
                lossP = lossP.Where(k => k.id_klasifikasi == i);
            }

            vm.LossList = new List<LossRecord>();
            foreach (var r in lossP)
            {
                LossRecord lr = new LossRecord();
                lr.lossEventPemilik = r;
                
                vm.LossList.Add(lr);
            }
        }

        private void CalcLossEventTahun(LossEventViewModel vm)
        {
            var LossT = db.LossEventTahunViews.Where(m => m.tahun <= vm.Param.ReportDate2.Year && m.tahun >= vm.Param.ReportDate.Year);

            //var LossP = db.LossEventBulanViews.Where(m => m.tahun <= vm.Param.ReportDate2.Year && m.bulan <= vm.Param.ReportDate2.Month);
            //LossP = db.LossEventBulanViews.Where(m => m.tahun >= vm.Param.ReportDate.Year && m.bulan >= vm.Param.ReportDate.Month);

            if (vm.Param.BranchId != null)
            {
                LossT = LossT.Where(m => m.id_pemilik == vm.Param.BranchId);
            }

            vm.LossList = new List<LossRecord>();
            foreach (var r in LossT)
            {
                LossRecord lr = new LossRecord();
                lr.lossEventTahun = r;

                vm.LossList.Add(lr);
            }
        }

        private void CalcLossEventBulan(LossEventViewModel vm)
        {
            //var LossT = db.LossEventTahunViews.Where(m => m.tahun <= vm.Param.ReportDate2.Year && m.tahun >= vm.Param.ReportDate.Year);

            var LossT = db.LossEventBulanViews.Where(m => m.tahun <= vm.Param.ReportDate2.Year && m.bulan <= vm.Param.ReportDate2.Month);
            LossT = LossT.Where(m => m.tahun >= vm.Param.ReportDate.Year && m.bulan >= vm.Param.ReportDate.Month);

            if (vm.Param.BranchId != null)
            {
                LossT = LossT.Where(m => m.id_pemilik == vm.Param.BranchId);
            }

            vm.LossList = new List<LossRecord>();
            foreach (var r in LossT)
            {
                LossRecord lr = new LossRecord();
                lr.lossEventBulan = r;

                vm.LossList.Add(lr);
            }
        }

        private void CalcLossEventKantor(LossEventViewModel vm)
        {
            var LossK = db.LossEventKantorViews.Where(m => m.tanggal <= vm.Param.ReportDate2 && m.tanggal >= vm.Param.ReportDate);

            if (vm.Param.BranchId != null)
            {
                LossK = LossK.Where(m => m.id_pemilik == vm.Param.BranchId);
            }

            vm.LossList = new List<LossRecord>();
            foreach (var r in LossK)
            {
                LossRecord lr = new LossRecord();
                lr.lossEventKantor = r;

                vm.LossList.Add(lr);
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
            return Json(new List<string>(), JsonRequestBehavior.AllowGet);
        }

        public void ExportToExcel(int? posId, int? branchId, DateTime reportDate, DateTime reportDate2,
            bool isApproved, bool showOrg, bool showAssets, bool showKeterangan, 
            bool showLocation, bool showLossAction, bool showLossCat,
            bool showLossCause, bool showLossCode, bool showLossDate,
            bool showLossEffectFinancial, bool showLossEffectNonFinancial, bool showLossEvent,
            bool showPihakTerlibat)
        {
            LossEventViewModel vm = new LossEventViewModel();
            vm.LossList = new List<LossRecord>();
            vm.Param = new Param();
            vm.Param.PosId = posId;
            vm.Param.BranchId = branchId;
            vm.Param.ReportDate = reportDate;
            vm.Param.ReportDate2 = reportDate2;
            vm.Param.IsApproved = isApproved;
            vm.Param.ShowOrg = showOrg;
            vm.Param.ShowAssets = showAssets;
            vm.Param.ShowKeterangan = showKeterangan;
            vm.Param.ShowLocation = showLocation;
            vm.Param.ShowLossAction = showLossAction;
            vm.Param.ShowLossCat = showLossCat;
            vm.Param.ShowLossCause = showLossCode;
            vm.Param.ShowLossCode = showLossCode;
            vm.Param.ShowLossDate = showLossDate;
            vm.Param.ShowLossEffectFinancial = showLossEffectFinancial;
            vm.Param.ShowLossEffectNonFinancial = showLossEffectNonFinancial;
            vm.Param.ShowLossEvent = showLossEvent;
            vm.Param.ShowPihakTerlibat = showPihakTerlibat;
            CalcLossEvent(vm);

            StringWriter sw = new StringWriter();

            sw.WriteLine("<table rules='all' border='1' style='border-collapse:collapse;'>");
            sw.WriteLine("<tr>");
            if (vm.Param.ShowLossCode)
            {
                sw.WriteLine("<th style='background-color: #eee'>Kode Loss Event</th>");
            }
            sw.WriteLine("<th style='background-color: #eee'>Peristiwa Kerugian</th>");
            if (vm.Param.ShowLossDate)
            {
                sw.WriteLine("<th style='background-color: #eee'>Tanggal</th>");
            }
            if (vm.Param.ShowOrg)
            { 
                sw.WriteLine("<th style='background-color: #eee'>Unit Kerja</th>");
            }
            if (vm.Param.ShowLossCat)
            {
                sw.WriteLine("<th style='background-color: #eee'>Klasifikasi Kerugian</th>");
            }
            if (vm.Param.ShowLossCause)
            {
                sw.WriteLine("<th style='background-color: #eee'>Sebab Kerugian</th>");
            }
            if (vm.Param.ShowLossEffectFinancial)
            {
                sw.WriteLine("<th style='background-color: #eee'>Dampak Kerugian Keuangan</th>");
            }
            if (vm.Param.ShowLossEffectNonFinancial)
            {
                sw.WriteLine("<th style='background-color: #eee'>Dampak Kerugian Non Keuangan</th>");
            }
            if (vm.Param.ShowPihakTerlibat)
            {
                sw.WriteLine("<th style='background-color: #eee'>Pihak Terlibat</th>");
            }
           
            sw.WriteLine("</tr>");
            foreach (var item in vm.LossList)
            {
                sw.WriteLine("<tr>");
                if (vm.Param.ShowLossCode)
                {
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEvent.LossEventCode));
                }
                sw.WriteLine(string.Format("<td>{0}</td>", item.lossEvent.LossEventName));
                if (vm.Param.ShowLossDate)
                {
                    sw.WriteLine(string.Format("<td>{0:dd-MM-yyyy}</td>", item.lossEvent.LossDate));
                }
                if (vm.Param.ShowOrg)
                { 
                    sw.WriteLine(string.Format("<td>{0}</td>", Utils.GetRiskOrgNameLoss(item.lossEvent)));
                }
                /*if (vm.Param.ShowRiskCat)
                {
                    sw.WriteLine("<td>");
                    if (item.Risk.RiskCat != null)
                    {
                        sw.WriteLine(item.Risk.RiskCat.RiskCatName);
                    }
                    sw.WriteLine("</td>");
                }*/
                if (vm.Param.ShowLossCause)
                {
                    sw.WriteLine("<td>");
                    if (item.lossEvent.LossCause != null)
                    {
                        sw.WriteLine(item.lossEvent.LossCause);
                    }
                    sw.WriteLine("</td>");
                }
                if (vm.Param.ShowLossEffectFinancial)
                {
                    sw.WriteLine("<td>");

                        sw.WriteLine(item.lossEvent.ImpactFinancial);
                    
                    sw.WriteLine("</td>");
                }
                if (vm.Param.ShowLossEffectNonFinancial)
                {
                    sw.WriteLine("<td>");

                        sw.WriteLine(item.lossEvent.ImpactNonFinancial);
                    
                    sw.WriteLine("</td>");
                }

                if (vm.Param.ShowPihakTerlibat)
                {
                    sw.WriteLine("<td>{0}</td>", item.lossEvent.PihakTerlibat);
                }
                sw.WriteLine("</tr>");
            }
            sw.WriteLine("</table>");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=LossEvent.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(sw.ToString());
            Response.End();
        }

        public void ExportToExcelKantor(int? posId, int? branchId, DateTime reportDate, DateTime reportDate2)
        {
            LossEventViewModel vm = new LossEventViewModel();
            vm.LossList = new List<LossRecord>();
            vm.Param = new Param();
            vm.Param.PosId = posId;
            vm.Param.BranchId = branchId;
            vm.Param.ReportDate = reportDate;
            vm.Param.ReportDate2 = reportDate2;
            CalcLossEventKantor(vm);

            StringWriter sw = new StringWriter();

            sw.WriteLine("<table rules='all' border='1' style='border-collapse:collapse;'>");
            sw.WriteLine("<tr>");
                sw.WriteLine("<th style='background-color: #eee'>Unit Kerja(Pemilik Kerugian)</th>");
                sw.WriteLine("<th style='background-color: #eee'>Peristiwa Kerugian</th>");
                sw.WriteLine("<th style='background-color: #eee'>Jumlah Kasus</th>");
            sw.WriteLine("</tr>");

            foreach (var item in vm.LossList)
            {
                sw.WriteLine("<tr>");
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventKantor.pemilik));
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventKantor.LossEvent));
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventKantor.jml_kasus));
                sw.WriteLine("</tr>");
            }
            sw.WriteLine("</table>");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=LossEventKantor.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(sw.ToString());
            Response.End();
        }

        public void ExportToExcelPemilik(int? posId, int? branchId, int? klasId, DateTime reportDate, DateTime reportDate2)
        {
            LossEventViewModel vm = new LossEventViewModel();
            vm.LossList = new List<LossRecord>();
            vm.Param = new Param();
            vm.Param.PosId = posId;
            vm.Param.BranchId = branchId;
            vm.Param.KlasId = klasId;
            vm.Param.ReportDate = reportDate;
            vm.Param.ReportDate2 = reportDate2;
            CalcPemilik(vm);

            StringWriter sw = new StringWriter();

            sw.WriteLine("<table rules='all' border='1' style='border-collapse:collapse;'>");
            sw.WriteLine("<tr>");
            sw.WriteLine("<th style='background-color: #eee'>Tahun</th>");
            sw.WriteLine("<th style='background-color: #eee'>Unit Kerja(Pemilik Kerugian)</th>");
            sw.WriteLine("<th style='background-color: #eee'>Klasifikasi Kerugian</th>");
            sw.WriteLine("<th style='background-color: #eee'>Jumlah Kasus</th>");
            sw.WriteLine("<th style='background-color: #eee'>Dampak Keuangan</th>");
            sw.WriteLine("<th style='background-color: #eee'>Dampak Non Keuangan</th>");
            sw.WriteLine("</tr>");

            foreach (var item in vm.LossList)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventPemilik.tahun));
                sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventPemilik.pemilik));
                sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventPemilik.Klasifikasi));
                sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventPemilik.jml_kasus));
                sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventPemilik.ImpactFinancial));
                //sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventPemilik.ImpactFinancial));
                sw.WriteLine("</tr>");
            }
            sw.WriteLine("</table>");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=LossEventPemilik.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(sw.ToString());
            Response.End();
        }

        public void ExportToExcelPeriode(int? posId, int? branchId, int? periodeId, DateTime reportDate, DateTime reportDate2)
        {
            LossEventViewModel vm = new LossEventViewModel();
            vm.LossList = new List<LossRecord>();
            vm.Param = new Param();
            vm.Param.PosId = posId;
            vm.Param.BranchId = branchId;
            vm.Param.PeriodeId = periodeId;
            vm.Param.ReportDate = reportDate;
            vm.Param.ReportDate2 = reportDate2;

            if (periodeId == 1)
            {
                CalcLossEventTahun(vm);
            }
            else
            {
                CalcLossEventBulan(vm);
            }
            
            StringWriter sw = new StringWriter();

            sw.WriteLine("<table rules='all' border='1' style='border-collapse:collapse;'>");
            sw.WriteLine("<tr>");
            sw.WriteLine("<th style='background-color: #eee'>Tahun</th>");
            if (periodeId != 1)
            {
                sw.WriteLine("<th style='background-color: #eee'>Bulan</th>");
            }
            sw.WriteLine("<th style='background-color: #eee'>Unit Kerja(Pemilik Kerugian)</th>");
            sw.WriteLine("<th style='background-color: #eee'>Klasifikasi Kerugian</th>");
            sw.WriteLine("<th style='background-color: #eee'>Peristiwa Kerugian</th>");
            sw.WriteLine("<th style='background-color: #eee'>Jumlah Kasus</th>");
            sw.WriteLine("<th style='background-color: #eee'>Nilai Kerugian</th>");
            sw.WriteLine("</tr>");

            foreach (var item in vm.LossList)
            {
                sw.WriteLine("<tr>");

                if (periodeId == 1)
                {
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventTahun.tahun));
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventTahun.pemilik));
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventTahun.LossEvent));
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventTahun.jml_kasus));
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventTahun.ImpactFinancial));
                }
                else
                {
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventBulan.tahun));
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventBulan.bulan));
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventBulan.pemilik));
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventBulan.LossEvents));
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventBulan.jml_kasus));
                    sw.WriteLine(string.Format("<td>{0}</td>", item.lossEventBulan.ImpactFinancial));
                }
                
                sw.WriteLine("</tr>");
            }
            sw.WriteLine("</table>");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=LossEventPeriode.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}
