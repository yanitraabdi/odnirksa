using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Areas.Report.Models.RisikoBerulang;
using Askrindo.Models;
using System.IO;
using Askrindo.Helpers;

namespace Askrindo.Areas.Report.Controllers
{
    public class RisikoBerulangController : Controller
    {
        //
        // GET: /Report/LossEvent/
        AskrindoEntities db = new AskrindoEntities();

        public ActionResult Index()
        { 
            RisikoBerulangViewModel vm = new RisikoBerulangViewModel();

            vm.Param = new Param();
            vm.Param.IsApproved = true;
            vm.Param.ReportDate1 = DateTime.Now;
            vm.Param.ReportDate2 = DateTime.Now;
            vm.Param.ReportDate3 = DateTime.Now;
            vm.Param.ReportDate4 = DateTime.Now;
            UpdateParam(vm.Param);
            vm.risikoBerulangList = new List<RisikoBerulangRecord>();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(RisikoBerulangViewModel vm)
        {
            UpdateParam(vm.Param);
            if (vm.Param.ReportId == 1)
            {
                getByRisikoUtama(vm);
            }
            else if (vm.Param.ReportId == 2) 
            {
                getByKantorCabang(vm);
            }
            else if (vm.Param.ReportId == 3)
            {
                getByKantorPusat(vm);
            }
            else if (vm.Param.ReportId == 4)
            {
                getByTingkatRisiko(vm);
            }
            else if (vm.Param.ReportId == 5)
            {
                getBySebabUtama(vm);
            }

            return View(vm);
        }

        private void getBySebabUtama(RisikoBerulangViewModel vm)
        {
            var date1 = vm.Param.ReportDate1;
            var date2 = vm.Param.ReportDate2;
            var date3 = vm.Param.ReportDate3;
            var date4 = vm.Param.ReportDate4;

            vm.risikoBerulangList = new List<RisikoBerulangRecord>();

            foreach (var a in db.RisikoBerulangSebabUtama(date1, date2, date3, date4).ToList())
            {
                RisikoBerulangRecord br = new RisikoBerulangRecord();
                br.risikoBerulangSebabUtamaList = a;
                vm.risikoBerulangList.Add(br);
            }
        }

        private void getByTingkatRisiko(RisikoBerulangViewModel vm)
        {
            var date1 = vm.Param.ReportDate1;
            var date2 = vm.Param.ReportDate2;
            var date3 = vm.Param.ReportDate3;
            var date4 = vm.Param.ReportDate4;

            vm.risikoBerulangList = new List<RisikoBerulangRecord>();

            foreach (var a in db.RisikoBerulangTingkatRisiko(date1, date2, date3, date4).ToList())
            {
                RisikoBerulangRecord br = new RisikoBerulangRecord();
                br.risikoBerulangTingkatRisikoList = a;
                vm.risikoBerulangList.Add(br);
            }
        }

        private void getByKantorPusat(RisikoBerulangViewModel vm)
        {
            var date1 = vm.Param.ReportDate1;
            var date2 = vm.Param.ReportDate2;
            var date3 = vm.Param.ReportDate3;
            var date4 = vm.Param.ReportDate4;

            vm.risikoBerulangList = new List<RisikoBerulangRecord>();

            foreach (var a in db.RisikoBerulangKantorPusat(date1, date2, date3, date4).ToList())
            {
                RisikoBerulangRecord br = new RisikoBerulangRecord();
                br.risikoBerulangKantorPusatList = a;
                vm.risikoBerulangList.Add(br);
            }
        }

        private void getByKantorCabang(RisikoBerulangViewModel vm)
        {
            var date1 = vm.Param.ReportDate1;
            var date2 = vm.Param.ReportDate2;
            var date3 = vm.Param.ReportDate3;
            var date4 = vm.Param.ReportDate4;

            vm.risikoBerulangList = new List<RisikoBerulangRecord>();

            foreach (var a in db.RisikoBerulangKantorCabang(date1, date2, date3, date4).ToList())
            {
                RisikoBerulangRecord br = new RisikoBerulangRecord();
                br.risikoBerulangKantorCabangList = a;
                vm.risikoBerulangList.Add(br);
            }
        }

        private void getByRisikoUtama(RisikoBerulangViewModel vm)
        {
            var date1 = vm.Param.ReportDate1;
            var date2 = vm.Param.ReportDate2;
            var date3 = vm.Param.ReportDate3;
            var date4 = vm.Param.ReportDate4;

            vm.risikoBerulangList = new List<RisikoBerulangRecord>();

            foreach(var a in db.RisikoBerulangRisikoUtama(date1, date2, date3, date4).ToList())
            {
                RisikoBerulangRecord br = new RisikoBerulangRecord();
                br.risikoBerulangRisikoUtamaList = a;
                vm.risikoBerulangList.Add(br);
            }
        }

        public ActionResult ShowRisks(int id, String type, DateTime date1, DateTime date2, DateTime date3, DateTime date4, int posId)
        {
            //var risk = new List<RisikoBerulangRecord>();

            //if (posId == 1)
            //{
            //    if (type == "baru")
            //    {
            //        risk = db.RisikoBerulangRisikoUtama(date1, date2, date3, date4).Where(m => m.RiskCatId == id && m.baru.HasValue).ToList();
            //    }
            //    else if (type == "berulang")
            //    {
            //        risk = db.RisikoBerulangRisikoUtama(date1, date2, date3, date4).Where(m => m.RiskCatId == id && m.berulang.HasValue).ToList();
            //    }
            //    else if (type == "t_berulang")
            //    {
            //        risk = db.RisikoBerulangRisikoUtama(date1, date2, date3, date4).Where(m => m.RiskCatId == id && m.t_berulang.HasValue).ToList();
            //    }
            //}
            //else if (posId == 2)
            //{
            //    if (type == "baru")
            //    {
            //        risk = db.RisikoBerulangKantorPusat(date1, date2, date3, date4).Where(m => m.SubDivId == id && m.baru.HasValue).ToList();
            //    }
            //    else if (type == "berulang")
            //    {
            //        risk = db.RisikoBerulangKantorPusat(date1, date2, date3, date4).Where(m => m.SubDivId == id && m.berulang.HasValue).ToList();
            //    }
            //    else if (type == "t_berulang")
            //    {
            //        risk = db.RisikoBerulangKantorPusat(date1, date2, date3, date4).Where(m => m.SubDivId == id && m.t_berulang.HasValue).ToList();
            //    }
            //}
            //else if (posId == 3)
            //{
            //    if (type == "baru")
            //    {
            //        risk = db.RisikoBerulangKantorCabang(date1, date2, date3, date4).Where(m => m.BranchId == id && m.baru.HasValue).ToList();
            //    }
            //    else if (type == "berulang")
            //    {
            //        risk = db.RisikoBerulangKantorCabang(date1, date2, date3, date4).Where(m => m.BranchId == id && m.berulang.HasValue).ToList();
            //    }
            //    else if (type == "t_berulang")
            //    {
            //        risk = db.RisikoBerulangKantorCabang(date1, date2, date3, date4).Where(m => m.BranchId == id && m.t_berulang.HasValue).ToList();
            //    }
            //}
            //else if (posId == 4)
            //{
            //    if (type == "baru")
            //    {
            //        risk = db.RisikoBerulangSebabUtama(date1, date2, date3, date4).Where(m => m.CauseGroupId == id && m.baru.HasValue).ToList();
            //    }
            //    else if (type == "berulang")
            //    {
            //        risk = db.RisikoBerulangSebabUtama(date1, date2, date3, date4).Where(m => m.CauseGroupId == id && m.berulang.HasValue).ToList();
            //    }
            //    else if (type == "t_berulang")
            //    {
            //        risk = db.RisikoBerulangSebabUtama(date1, date2, date3, date4).Where(m => m.CauseGroupId == id && m.t_berulang.HasValue).ToList();
            //    }
            //}
            //else if (posId == 5)
            //{
            //    if (type == "baru")
            //    {
            //        risk = db.RisikoBerulangTingkatRisiko(date1, date2, date3, date4).Where(m => m.LevelId == id && m.baru.HasValue).ToList();
            //    }
            //    else if (type == "berulang")
            //    {
            //        risk = db.RisikoBerulangTingkatRisiko(date1, date2, date3, date4).Where(m => m.LevelId == id && m.berulang.HasValue).ToList();
            //    }
            //    else if (type == "t_berulang")
            //    {
            //        risk = db.RisikoBerulangTingkatRisiko(date1, date2, date3, date4).Where(m => m.LevelId == id && m.t_berulang.HasValue).ToList();
            //    }
            //}

            return View(/*risk*/);
        }

        private void UpdateParam(Param param)
        {
            Dictionary<int, string> reportList = new Dictionary<int, string>();
            reportList.Add(1, "Risiko Berulang Menurut 7 Kelompok Risiko Utama");
            reportList.Add(2, "Risiko Berulang Menurut Kantor Cabang");
            reportList.Add(3, "Risiko Berulang Menurut Unit Kerja di Kantor Pusat");
            reportList.Add(4, "Risiko Berulang Menurut Tingkat Risiko");
            reportList.Add(5, "Risiko Berulang Menurut Faktor Sebab Utama");

            param.ReportType = new SelectList(reportList, "Key", "Value", param.ReportId);

            Dictionary<int, string> posList = new Dictionary<int, string>();
            posList.Add(1, "Nasional");
            posList.Add(2, "Kantor Pusat");
            posList.Add(3, "Kantor Cabang");
            posList.Add(4, "Korwil");
            posList.Add(5, "Kelas KC");
            param.PosList = new SelectList(posList, "Key", "Value", param.PosId);

            Dictionary<int, string> periodeList = new Dictionary<int, string>();
            periodeList.Add(1, "2015");
            param.PeriodeList = new SelectList(periodeList, "Key", "Value", param.PeriodeId);
            
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
    }
}
