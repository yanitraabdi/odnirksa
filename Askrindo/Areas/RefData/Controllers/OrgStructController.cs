using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;
using System.Data;
using Askrindo.Areas.RefData.Models.OrgStruct;
using Askrindo.Helpers;

namespace Askrindo.Areas.RefData.Controllers
{
    [Authorize]
    public class OrgStructController : Controller
    {
        private AskrindoEntities db = new AskrindoEntities();
        UserData userData = Utils.LoadUserDataFromSession();

        public ActionResult Index()
        {
            return View();
        }

        #region KantorUnit

        public ActionResult KantorUnit()
        {
            ViewBag.CanModify = userData.IsAdmin;
            var model = from s in db.Branches
                        join ss in db.BranchClasses on s.ClassId equals ss.ClassId
                        join sss in db.Depts on s.DeptId equals sss.DeptId
                        join sssss in db.BizUnits on s.BranchId equals sssss.BranchId
                        orderby ss.ClassName ascending
                        select new JoinOrganisasi
                        {
                            Branch = s,
                            BranchClass = ss,
                            Dept = sss,
                            BizUnit = sssss
                        };
            return View(model.ToList());
        }

        public ActionResult KantorUnitEdit(int id)
        {
            KantorUnitViewModel vm = new KantorUnitViewModel();
            vm.KantorUnit = db.BizUnits.Single(p => p.BizUnitId == id);
            vm.Param = new KantorUnitParam();
            UpdateKantorUnitParam(vm.Param);
            return View(vm);
        }

        [HttpPost]
        public ActionResult KantorUnitEdit(KantorUnitViewModel kntrUnit)
        {
            if (ModelState.IsValid)
            {
                db.BizUnits.Attach(kntrUnit.KantorUnit);
                db.Entry(kntrUnit.KantorUnit).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("KantorUnit");
            }
            return View(kntrUnit);
        }

        private void UpdateKantorUnitParam(KantorUnitParam param)
        {
            Dictionary<int, string> BagianList = new Dictionary<int, string>();
            foreach (var branch in db.Branches.OrderBy(m => m.BranchId).ThenBy(m => m.BranchName))
                BagianList.Add(branch.BranchId, branch.BranchName);
            param.CabangList = new SelectList(BagianList, "Key", "Value", param.CabangId);
        }

        public ActionResult KantorUnitNew()
        {
            KantorUnitViewModel vm = new KantorUnitViewModel();
            vm.Param = new KantorUnitParam();
            UpdateKantorUnitParam(vm.Param);
            return View(vm);
        }

        [HttpPost]
        public ActionResult KantorUnitNew(KantorUnitViewModel kntrUnit)
        {
            if (ModelState.IsValid)
            {
                db.BizUnits.Add(kntrUnit.KantorUnit);
                db.SaveChanges();
                return RedirectToAction("KantorUnit");
            }
            return View(kntrUnit);
        }

        public ActionResult KantorUnitDelete(int id)
        {
            KantorUnitViewModel vm = new KantorUnitViewModel();
            vm.KantorUnit = db.BizUnits.Single(p => p.BizUnitId == id);
            vm.Param = new KantorUnitParam();
            UpdateKantorUnitParam(vm.Param);
            return View(vm);
        }

        [HttpPost, ActionName("KantorUnitDelete")]
        public ActionResult KantorUnitDeleteConfirmed(int id)
        {
            BizUnit kntrUnit = db.BizUnits.Single(p => p.BizUnitId == id);
            db.BizUnits.Remove(kntrUnit);
            db.SaveChanges();
            return RedirectToAction("KantorUnit");
        }

        #endregion

        #region BagianCabang

        public ActionResult BagianCabang()
        {
            ViewBag.CanModify = userData.IsAdmin;
            var model = from s in db.Branches
                        join ss in db.BranchClasses on s.ClassId equals ss.ClassId
                        join sss in db.Depts on s.DeptId equals sss.DeptId
                        join ssss in db.SubBranches on s.BranchId equals ssss.BranchId
                        orderby ss.ClassName ascending
                        select new JoinOrganisasi
                        {
                            Branch = s,
                            BranchClass = ss,
                            Dept = sss,
                            SubBranch = ssss
                        };
            return View(model.ToList());
        }

        public ActionResult BagianCabangEdit(int id)
        {
            BagianCabangViewModel vm = new BagianCabangViewModel();
            vm.BagianCabang = db.SubBranches.Single(p => p.SubBranchId == id);
            vm.Param = new BagianCabangParam();
            UpdateBagianCabangParam(vm.Param);
            return View(vm);
        }

        [HttpPost]
        public ActionResult BagianCabangEdit(BagianCabangViewModel bgnCabang)
        {
            if (ModelState.IsValid)
            {
                db.SubBranches.Attach(bgnCabang.BagianCabang);
                db.Entry(bgnCabang.BagianCabang).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BagianCabang");
            }
            return View(bgnCabang);
        }

        private void UpdateBagianCabangParam(BagianCabangParam param)
        {
            Dictionary<int, string> BagianList = new Dictionary<int, string>();
            foreach (var branch in db.Branches.OrderBy(m => m.BranchId).ThenBy(m => m.BranchName))
                BagianList.Add(branch.BranchId, branch.BranchName);
            param.CabangList = new SelectList(BagianList, "Key", "Value", param.CabangId);
        }

        public ActionResult BagianCabangNew()
        {
            BagianCabangViewModel vm = new BagianCabangViewModel();
            vm.Param = new BagianCabangParam();
            UpdateBagianCabangParam(vm.Param);
            return View(vm);
        }

        [HttpPost]
        public ActionResult BagianCabangNew(BagianCabangViewModel bgnCabang)
        {
            if (ModelState.IsValid)
            {
                db.SubBranches.Add(bgnCabang.BagianCabang);
                db.SaveChanges();
                return RedirectToAction("BagianCabang");
            }
            return View(bgnCabang);
        }

        public ActionResult BagianCabangDelete(int id)
        {
            BagianCabangViewModel vm = new BagianCabangViewModel();
            vm.BagianCabang = db.SubBranches.Single(p => p.SubBranchId == id);
            vm.Param = new BagianCabangParam();
            UpdateBagianCabangParam(vm.Param);
            return View(vm);
        }

        [HttpPost, ActionName("BagianCabangDelete")]
        public ActionResult BagianCabangDeleteConfirmed(int id)
        {
            SubBranch bgncabang = db.SubBranches.Single(p => p.SubBranchId == id);
            db.SubBranches.Remove(bgncabang);
            db.SaveChanges();
            return RedirectToAction("BagianCabang");
        }

        #endregion

        #region KantorCabang

        public ActionResult KantorCabang()
        {
            ViewBag.CanModify = userData.IsAdmin;
            var model = from s in db.Branches
                        join ss in db.BranchClasses on s.ClassId equals ss.ClassId
                        join sss in db.Depts on s.DeptId equals sss.DeptId
                        orderby ss.ClassName ascending
                        select new JoinOrganisasi
                        {
                            Branch = s,
                            BranchClass = ss,
                            Dept = sss
                        };
            return View(model.ToList());
        }

        public ActionResult KantorCabangEdit(int id)
        {
            KantorCabangViewModel vm = new KantorCabangViewModel();
            vm.KantorCabang = db.Branches.Single(p => p.BranchId == id);
            vm.Param = new KantorCabangParam();
            UpdateKantorCabangParam(vm.Param);
            return View(vm);
        }

        [HttpPost]
        public ActionResult KantorCabangEdit(KantorCabangViewModel kntrcabang)
        {
            if (ModelState.IsValid)
            {
                db.Branches.Attach(kntrcabang.KantorCabang);
                db.Entry(kntrcabang.KantorCabang).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("KantorCabang");
            }
            return View(kntrcabang);
        }

        private void UpdateKantorCabangParam(KantorCabangParam param)
        {
            Dictionary<int, string> DirektoratList = new Dictionary<int, string>();
            foreach (var branch in db.Depts.OrderBy(m => m.DeptId).ThenBy(m => m.DeptName))
                DirektoratList.Add(branch.DeptId, branch.DeptName);
            param.DirektoratList = new SelectList(DirektoratList, "Key", "Value", param.DeptId);

            Dictionary<int, string> KelasList = new Dictionary<int, string>();
            foreach (var branch in db.BranchClasses.OrderBy(m => m.ClassId).ThenBy(m => m.ClassName))
                KelasList.Add(branch.ClassId, branch.ClassName);
            param.KelasList = new SelectList(KelasList, "Key", "Value", param.KelasId);

            Dictionary<int, string> KorwilList = new Dictionary<int, string>();
            foreach (var korwil in db.Korwils.OrderBy(m => m.KorwilId))
                KorwilList.Add(korwil.KorwilId, korwil.Korwil1);
            param.KorwilList = new SelectList(KorwilList, "Key", "Value", param.KorwilId);

        }

        public ActionResult KantorCabangNew()
        {
            KantorCabangViewModel vm = new KantorCabangViewModel();
            vm.Param = new KantorCabangParam();
            UpdateKantorCabangParam(vm.Param);
            return View(vm);
        }

        [HttpPost]
        public ActionResult KantorCabangNew(KantorCabangViewModel kntrcabang)
        {
            if (ModelState.IsValid)
            {
                db.Branches.Add(kntrcabang.KantorCabang);
                db.SaveChanges();
                return RedirectToAction("KantorCabang");
            }
            return View(kntrcabang);
        }

        public ActionResult KantorCabangDelete(int id)
        {
            KantorCabangViewModel vm = new KantorCabangViewModel();
            vm.KantorCabang = db.Branches.Single(p => p.BranchId == id);
            vm.Param = new KantorCabangParam();
            UpdateKantorCabangParam(vm.Param);
            return View(vm);
        }

        [HttpPost, ActionName("KantorCabangDelete")]
        public ActionResult KantorCabangDeleteConfirmed(int id)
        {
            Branch kntrcabang = db.Branches.Single(p => p.BranchId == id);
            db.Branches.Remove(kntrcabang);
            db.SaveChanges();
            return RedirectToAction("KantorCabang");
        }

        #endregion

        #region Bagian

        public ActionResult Bagian()
        {
            ViewBag.CanModify = userData.IsAdmin;
            var model = from s in db.Depts
                        join ss in db.Divisions on s.DeptId equals ss.DeptId
                        join sss in db.SubDivs on ss.DivisionId equals sss.DivisionId
                        select new JoinOrganisasi
                        {
                            Dept = s,
                            Division = ss,
                            SubDiv = sss
                        };
            return View(model.ToList());
        }

        public ActionResult BagianEdit(int id)
        {
            BagianViewModel vm = new BagianViewModel();
            vm.Bagian = db.SubDivs.Single(p => p.SubDivId == id);
            vm.Param = new BagianParam();
            UpdateBagianParam(vm.Param);
            return View(vm);
        }

        [HttpPost]
        public ActionResult BagianEdit(BagianViewModel bgn)
        {
            if (ModelState.IsValid)
            {
                db.SubDivs.Attach(bgn.Bagian);
                db.Entry(bgn.Bagian).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Bagian");
            }
            return View(bgn);
        }

        private void UpdateBagianParam(BagianParam param)
        {
            Dictionary<int, string> DirektoratList = new Dictionary<int, string>();
            foreach (var branch in db.Depts.OrderBy(m => m.DeptId).ThenBy(m => m.DeptName))
                DirektoratList.Add(branch.DeptId, branch.DeptName);
            param.DivisiList = new SelectList(DirektoratList, "Key", "Value", param.DeptId);

            Dictionary<int, string> DivisiList = new Dictionary<int, string>();
            foreach (var branch in db.Divisions.OrderBy(m => m.DivisionId).ThenBy(m => m.DivisionName))
                DivisiList.Add(branch.DivisionId, branch.DivisionName);
            param.DivisiList = new SelectList(DivisiList, "Key", "Value", param.DivId);
        }

        public ActionResult BagianNew()
        {
            BagianViewModel vm = new BagianViewModel();
            vm.Param = new BagianParam();
            UpdateBagianParam(vm.Param);
            return View(vm);
        }

        [HttpPost]
        public ActionResult BagianNew(BagianViewModel bgn)
        {
            if (ModelState.IsValid)
            {
                db.SubDivs.Add(bgn.Bagian);
                db.SaveChanges();
                return RedirectToAction("Bagian");
            }
            return View(bgn);

        }

        public ActionResult BagianDelete(int id)
        {
            BagianViewModel vm = new BagianViewModel();
            vm.Bagian = db.SubDivs.Single(p => p.SubDivId == id);
            vm.Param = new BagianParam();
            UpdateBagianParam(vm.Param);
            return View(vm);
        }

        [HttpPost, ActionName("BagianDelete")]
        public ActionResult BagianDeleteConfirmed(int id)
        {
            SubDiv subdiv = db.SubDivs.Single(p => p.SubDivId == id);
            db.SubDivs.Remove(subdiv);
            db.SaveChanges();
            return RedirectToAction("Bagian");
        }

        #endregion

        #region Divisi

        public ActionResult Divisi()
        {
            ViewBag.CanModify = userData.IsAdmin;
            var model = from s in db.Depts
                        join ss in db.Divisions on s.DeptId equals ss.DeptId
                        select new JoinOrganisasi
                        {
                            Dept = s,
                            Division = ss
                        };
            return View(model.ToList());
        }

        public ActionResult DivisiEdit(int id)
        {
            DivisiViewModel vm = new DivisiViewModel();
            vm.Divisi = db.Divisions.Single(p => p.DivisionId == id);
            vm.Param = new DivisiParam();
            UpdateDivisiParam(vm.Param);
            return View(vm);
        }

        [HttpPost]
        public ActionResult DivisiEdit(DivisiViewModel div)
        {
            if (ModelState.IsValid)
            {
                db.Divisions.Attach(div.Divisi);
                db.Entry(div.Divisi).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Divisi");
            }
            return View(div);
        }

        private void UpdateDivisiParam(DivisiParam param)
        {
            Dictionary<int, string> DirektoriList = new Dictionary<int, string>();
            foreach (var branch in db.Depts.OrderBy(m => m.DeptId).ThenBy(m => m.DeptName))
                DirektoriList.Add(branch.DeptId, branch.DeptName);
            param.DivisiList = new SelectList(DirektoriList, "Key", "Value", param.DeptId);
        }

        public ActionResult DivisiNew()
        {
            DivisiViewModel vm = new DivisiViewModel();
            vm.Param = new DivisiParam();
            UpdateDivisiParam(vm.Param);
            return View(vm);
        }

        [HttpPost]
        public ActionResult DivisiNew(DivisiViewModel div)
        {
            if (ModelState.IsValid)
            {
                db.Divisions.Add(div.Divisi);
                db.SaveChanges();
                return RedirectToAction("Divisi");
            }
            return View(div);
        }

        public ActionResult DivisiDelete(int id)
        {
            DivisiViewModel vm = new DivisiViewModel();
            vm.Divisi = db.Divisions.Single(p => p.DivisionId == id);
            vm.Param = new DivisiParam();
            UpdateDivisiParam(vm.Param);
            return View(vm);
        }

        [HttpPost, ActionName("DivisiDelete")]
        public ActionResult DivisiDeleteConfirmed(int id)
        {
            Division div = db.Divisions.Single(p => p.DivisionId == id);
            db.Divisions.Remove(div);
            db.SaveChanges();
            return RedirectToAction("Divisi");
        }

        #endregion

        #region DibawahDirektorat

        public ActionResult DibawahDirektorat()
        {
            ViewBag.CanModify = userData.IsAdmin;
            var model = from s in db.Depts
                        join ss in db.SubDepts on s.DeptId equals ss.DeptId
                        select new JoinOrganisasi
                        {
                            Dept = s,
                            SubDept = ss
                        };
            return View(model.ToList());
        }

        private void UpdateDibawahDirektoratParam(DibawahDirektoratParam param)
        {
            Dictionary<int, string> DirektoriList = new Dictionary<int, string>();
            foreach (var branch in db.Depts.OrderBy(m => m.DeptId).ThenBy(m => m.DeptName))
                DirektoriList.Add(branch.DeptId, branch.DeptName);
            param.Direktorat = new SelectList(DirektoriList, "Key", "Value", param.DeptId);
        }

        public ActionResult DibawahDirektoratEdit(int id)
        {
            DibawahDirektoratViewModal vm = new DibawahDirektoratViewModal();
            vm.DibawahDirektorat = db.SubDepts.Single(p => p.SubDeptId == id);
            vm.Param = new DibawahDirektoratParam();
            UpdateDibawahDirektoratParam(vm.Param);
            return View(vm);
        }

        [HttpPost]
        public ActionResult DibawahDirektoratEdit(DibawahDirektoratViewModal subdept)
        {
            if (ModelState.IsValid)
            {
                db.SubDepts.Attach(subdept.DibawahDirektorat);
                db.Entry(subdept.DibawahDirektorat).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DibawahDirektorat");
            }
            return View(subdept);

        }

        public ActionResult DibawahDirektoratNew()
        {
            DibawahDirektoratViewModal vm = new DibawahDirektoratViewModal();
            vm.Param = new DibawahDirektoratParam();
            UpdateDibawahDirektoratParam(vm.Param);
            return View(vm);
        }

        [HttpPost]
        public ActionResult DibawahDirektoratNew(DibawahDirektoratViewModal vm)
        {
            if (ModelState.IsValid)
            {
                db.SubDepts.Add(vm.DibawahDirektorat);
                db.SaveChanges();
                return RedirectToAction("DibawahDirektorat");
            }
            return View(vm);
        }

        public ActionResult DibawahDirektoratDelete(int id)
        {
            DibawahDirektoratViewModal vm = new DibawahDirektoratViewModal();

            vm.DibawahDirektorat = db.SubDepts.Single(p => p.SubDeptId == id);
            vm.Param = new DibawahDirektoratParam();
            UpdateDibawahDirektoratParam(vm.Param);
            return View(vm);
        }

        [HttpPost, ActionName("DibawahDirektoratDelete")]
        public ActionResult DibawahDirektoratDeleteConfirmed(int id)
        {
            SubDept subdept = db.SubDepts.Single(p => p.SubDeptId == id);
            db.SubDepts.Remove(subdept);
            db.SaveChanges();
            return RedirectToAction("DibawahDirektorat");
        }

        #endregion

        #region Direktorat

        public ActionResult Direktorat()
        {
            ViewBag.CanModify = userData.IsAdmin;
            return View(db.Depts.ToList());
        }

        public ActionResult DirektoratEdit(int id)
        {
            Dept dept = db.Depts.Single(p => p.DeptId == id);
            return View(dept);
        }

        [HttpPost]
        public ActionResult DirektoratEdit(Dept dept)
        {
            if (ModelState.IsValid)
            {
                db.Depts.Attach(dept);
                db.Entry(dept).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Direktorat");
            }
            return View(dept);
        }

        public ActionResult DirektoratNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DirektoratNew(Dept dept)
        {
            if (ModelState.IsValid)
            {
                db.Depts.Add(dept);
                db.SaveChanges();
                return RedirectToAction("Direktorat");
            }
            return View(dept);
        }

        public ActionResult DirektoratDelete(int id)
        {
            Dept dept = db.Depts.Single(p => p.DeptId == id);
            return View(dept);
        }

        [HttpPost, ActionName("DirektoratDelete")]
        public ActionResult DirektoratDeleteConfirmed(int id)
        {
            Dept dept = db.Depts.Single(p => p.DeptId == id);
            db.Depts.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("Direktorat");
        }

        #endregion

        #region Dept

        public ActionResult DeptList()
        {
            ViewBag.CanModify = userData.IsAdmin;
            return View(db.Depts.ToList());
        }

        public ActionResult DeptEdit(int id)
        {
            Dept dept = db.Depts.Single(p => p.DeptId == id);
            return View(dept);
        }

        [HttpPost]
        public ActionResult DeptEdit(Dept dept)
        {
            if (ModelState.IsValid)
            {
                db.Depts.Attach(dept);
                db.Entry(dept).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("StrukturOrganisasi");
            }
            return View(dept);
        }

        public ActionResult DeptNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeptNew(Dept dept)
        {
            if (ModelState.IsValid)
            {
                db.Depts.Add(dept);
                db.SaveChanges();
                return RedirectToAction("StrukturOrganisasi");
            }
            return View(dept);
        }

        public ActionResult DeptDelete(int id)
        {
            Dept dept = db.Depts.Single(p => p.DeptId == id);
            return View(dept);
        }

        [HttpPost, ActionName("DeptDelete")]
        public ActionResult DeptDeleteConfirmed(int id)
        {
            Dept dept = db.Depts.Single(p => p.DeptId == id);
            db.Depts.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("StrukturOrganisasi");
        }

        #endregion

        #region Division

        public ActionResult DivList(int deptId)
        {
            ViewBag.Dept = db.Depts.Single(p => p.DeptId == deptId);
            ViewBag.CanModify = userData.IsAdmin;
            return View(db.Divisions.Where(p => p.DeptId == deptId).ToList());
        }

        public ActionResult DivNew(int deptId)
        {
            ViewBag.Dept = db.Depts.Single(p => p.DeptId == deptId);
            return View();
        }

        [HttpPost]
        public ActionResult DivNew(Division div, int deptId)
        {
            if (ModelState.IsValid)
            {
                div.DeptId = deptId;
                db.Divisions.Add(div);
                db.SaveChanges();
                return RedirectToAction("DivList", new { deptid = deptId });
            }
            return View(new { deptid = deptId });
        }

        public ActionResult DivEdit(int id)
        {
            Division div = db.Divisions.Single(p => p.DivisionId == id);
            return View(div);
        }

        [HttpPost]
        public ActionResult DivEdit(Division div)
        {
            if (ModelState.IsValid)
            {
                db.Divisions.Attach(div);
                db.Entry(div).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                ViewBag.DeptId = div.DeptId;
                Dept dept = db.Depts.Single(p => p.DeptId == div.DeptId);
                ViewBag.DeptName = dept.DeptName;
                return RedirectToAction("DivList", new { deptid = div.DeptId });
            }
            return View(div);
        }

        public ActionResult DivDelete(int id)
        {
            Division div = db.Divisions.Single(p => p.DivisionId == id);
            ViewBag.DeptId = div.DeptId;
            ViewBag.DeptName = div.Dept.DeptName;
            return View(div);
        }

        [HttpPost, ActionName("DivDelete")]
        public ActionResult DivDeleteConfirmed(int id)
        {
            Division div = db.Divisions.Single(p => p.DivisionId == id);
            ViewBag.DeptId = div.DeptId;
            ViewBag.DeptName = div.Dept.DeptName;
            db.Divisions.Remove(div);
            db.SaveChanges();
            return RedirectToAction("DivList", new { deptid = ViewBag.DeptId });
        }

        #endregion

        #region Branch
        
        public ActionResult BranchList(int deptId)
        {
            ViewBag.Dept = db.Depts.Single(p => p.DeptId == deptId);
            ViewBag.CanModify = userData.IsAdmin;
            return View(db.Branches.Include("BranchClass").Where(p => p.DeptId == deptId));
        }

        public ActionResult BranchNew(int deptId)
        {
            ViewBag.Dept = db.Depts.Single(p => p.DeptId == deptId);
            ViewBag.ClassId = new SelectList(db.BranchClasses, "ClassId", "ClassName");
            return View();
        }

        [HttpPost]
        public ActionResult BranchNew(Branch branch, int deptId)
        {
            if (ModelState.IsValid)
            {
                branch.DeptId = deptId;
                db.Branches.Add(branch);
                db.SaveChanges();
                return RedirectToAction("BranchList", new { deptId = deptId });
            }
            //if (branch.ClassId == null)
            //    ModelState.AddModelError("", "Kelas cabang harus diisi");
            
            ViewBag.Dept = db.Depts.Single(p => p.DeptId == deptId);
            ViewBag.ClassId = new SelectList(db.BranchClasses, "ClassId", "ClassName");
            return View(branch);
        }

        public ActionResult BranchEdit(int id)
        {
            Branch branch = db.Branches.Single(p => p.BranchId == id);
            ViewBag.ClassId = new SelectList(db.BranchClasses, "ClassId", "ClassName", branch.ClassId);
            return View(branch);
        }

        [HttpPost]
        public ActionResult BranchEdit(Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Branches.Attach(branch);
                db.Entry(branch).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                ViewBag.Dept = db.Depts.Single(p => p.DeptId == branch.DeptId);
                return RedirectToAction("BranchList", new { deptId = branch.DeptId });
            }
            return View(branch);
        }

        public ActionResult BranchDelete(int id)
        {
            Branch branch = db.Branches.Single(p => p.BranchId == id);
            return View(branch);
        }

        [HttpPost, ActionName("BranchDelete")]
        public ActionResult BranchDeleteConfirmed(int id)
        {
            Branch branch = db.Branches.Single(p => p.BranchId == id);
            db.Branches.Remove(branch);
            db.SaveChanges();
            return RedirectToAction("BranchList", new { deptId = branch.DeptId });
        }

        #endregion

        #region SubDiv
        
        public ActionResult SubDivList(int divId)
        {
            SubDivViewModel vm = new SubDivViewModel();
            vm.Division = db.Divisions.Single(p => p.DivisionId == divId);
            vm.SubDivs = db.SubDivs.Where(p => p.DivisionId == divId).ToList();
            ViewBag.CanModify = userData.IsAdmin;
            return View(vm);
        }

        public ActionResult SubDivNew(int divId)
        {
            SubDivViewModel vm = new SubDivViewModel();
            vm.Division = db.Divisions.Single(p => p.DivisionId == divId);
            return View(vm);
        }

        [HttpPost]
        public ActionResult SubDivNew(SubDivViewModel vm, int divId)
        {
            if (ModelState.IsValid)
            {
                vm.SubDiv.DivisionId = divId;
                db.SubDivs.Add(vm.SubDiv);
                db.SaveChanges();
                return RedirectToAction("SubDivList", new { divId = divId });
            }
            vm.Division = db.Divisions.Single(p => p.DivisionId == divId);
            return View(vm);
        }

        public ActionResult SubDivEdit(int id)
        {
            SubDivViewModel vm = new SubDivViewModel();
            vm.SubDiv = db.SubDivs.Single(p => p.SubDivId == id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult SubDivEdit(SubDiv subDiv)
        {
            if (ModelState.IsValid)
            {
                db.SubDivs.Attach(subDiv);
                db.Entry(subDiv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SubDivList", new { divId = subDiv.DivisionId });
            }
            SubDivViewModel vm = new SubDivViewModel();
            vm.SubDiv = subDiv;
            return View(vm);
        }

        public ActionResult SubDivDelete(int id)
        {
            SubDivViewModel vm = new SubDivViewModel();
            vm.SubDiv = db.SubDivs.Include("Division").Single(p => p.SubDivId == id);
            return View(vm);
        }

        [HttpPost, ActionName("SubDivDelete")]
        public ActionResult SubDivDeleteConfirmed(int id)
        {
            SubDiv subDiv = db.SubDivs.Single(p => p.SubDivId == id);
            int divId = subDiv.DivisionId;
            db.SubDivs.Remove(subDiv);
            db.SaveChanges();
            return RedirectToAction("SubDivList", new { divId = divId });
        }

        #endregion

        #region BizUnit
        
        public ActionResult BizUnitList(int branchId)
        {
            BizUnitViewModel vm = new BizUnitViewModel();
            vm.BizUnits = db.BizUnits.Where(p => p.BranchId == branchId);
            vm.Branch = db.Branches.Single(p => p.BranchId == branchId);
            ViewBag.CanModify = userData.IsAdmin;
            return View(vm);
        }

        public ActionResult BizUnitNew(int branchId)
        {
            BizUnitViewModel vm = new BizUnitViewModel();
            vm.Branch = db.Branches.Single(p => p.BranchId == branchId);
            return View(vm);
        }

        [HttpPost]
        public ActionResult BizUnitNew(BizUnitViewModel vm, int branchId)
        {
            if (ModelState.IsValid)
            {
                vm.BizUnit.BranchId = branchId;
                db.BizUnits.Add(vm.BizUnit);
                db.SaveChanges();
                return RedirectToAction("BizUnitList", new { branchId = branchId });
            }
            vm.Branch = db.Branches.Single(p => p.BranchId == branchId);
            return View(vm);
        }

        public ActionResult BizUnitEdit(int id)
        {
            BizUnitViewModel vm = new BizUnitViewModel();
            vm.BizUnit = db.BizUnits.Include("Branch").Single(p => p.BizUnitId == id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult BizUnitEdit(BizUnit bizUnit)
        {
            if (ModelState.IsValid)
            {
                db.BizUnits.Attach(bizUnit);
                db.Entry(bizUnit).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BizUnitList", new { branchId = bizUnit.BranchId });
            }
            BizUnitViewModel vm = new BizUnitViewModel();
            vm.BizUnit = bizUnit;
            return View(vm);
        }

        public ActionResult BizUnitDelete(int id)
        {
            BizUnitViewModel vm = new BizUnitViewModel();
            vm.BizUnit = db.BizUnits.Include("Branch").Single(p => p.BizUnitId == id);
            return View(vm);
        }

        [HttpPost, ActionName("BizUnitDelete")]
        public ActionResult BizUnitDeleteConfirmed(int id)
        {
            BizUnit bizUnit = db.BizUnits.Single(p => p.BizUnitId == id);
            var branchId = bizUnit.BranchId;
            db.BizUnits.Remove(bizUnit);
            db.SaveChanges();
            return RedirectToAction("BizUnitList", new { branchId = branchId });
        }

        #endregion

        #region SubBranch
        
        public ActionResult SubBranchList(int branchId)
        {
            SubBranchViewModel vm = new SubBranchViewModel();
            vm.Branch = db.Branches.Single(p => p.BranchId == branchId);
            vm.SubBranches = db.SubBranches.Where(p => p.BranchId == branchId);
            ViewBag.CanModify = userData.IsAdmin;
            return View(vm);
        }

        public ActionResult SubBranchNew(int branchId)
        {
            SubBranchViewModel vm = new SubBranchViewModel();
            vm.Branch = db.Branches.Single(p => p.BranchId == branchId);
            return View(vm);
        }

        [HttpPost]
        public ActionResult SubBranchNew(SubBranchViewModel vm, int branchId)
        {
            if (ModelState.IsValid)
            {
                vm.SubBranch.BranchId = branchId;
                db.SubBranches.Add(vm.SubBranch);
                db.SaveChanges();
                return RedirectToAction("SubBranchList", new { branchId = branchId });
            }
            vm.Branch = db.Branches.Single(p => p.BranchId == branchId);
            return View(vm);
        }

        public ActionResult SubBranchEdit(int id)
        {
            SubBranchViewModel vm = new SubBranchViewModel();
            vm.SubBranch = db.SubBranches.Single(p => p.SubBranchId == id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult SubBranchEdit(SubBranch subBranch, int id)
        {
            if (ModelState.IsValid)
            {
                db.SubBranches.Attach(subBranch);
                db.Entry(subBranch).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SubBranchList", new { branchId = subBranch.BranchId });
            }
            SubBranchViewModel vm = new SubBranchViewModel();
            vm.SubBranch = subBranch;
            return View();
        }

        public ActionResult SubBranchDelete(int id)
        {
            SubBranchViewModel vm = new SubBranchViewModel();
            vm.SubBranch = db.SubBranches.Single(p => p.SubBranchId == id);
            return View(vm);
        }

        [HttpPost, ActionName("SubBranchDelete")]
        public ActionResult SubBranchDeleteConfirmed(int id)
        {
            SubBranch subBranch = db.SubBranches.Single(p => p.SubBranchId == id);
            var branchId=subBranch.BranchId;
            db.SubBranches.Remove(subBranch);
            db.SaveChanges();
            return RedirectToAction("SubBranchList", new { branchId = branchId });
        }

        #endregion

        #region SubDept

        public ActionResult SubDeptList(int deptId)
        {
            SubDeptViewModel vm = new SubDeptViewModel();
            vm.Dept = db.Depts.Single(p => p.DeptId == deptId);
            vm.SubDepts = db.SubDepts.Where(p => p.DeptId == deptId);
            ViewBag.CanModify = userData.IsAdmin;
            return View(vm);
        }

        public ActionResult SubDeptNew(int deptId)
        {
            SubDeptViewModel vm = new SubDeptViewModel();
            vm.Dept = db.Depts.Single(p => p.DeptId == deptId);
            return View(vm);
        }

        [HttpPost]
        public ActionResult SubDeptNew(SubDeptViewModel vm, int deptId)
        {
            if (ModelState.IsValid)
            {
                vm.SubDept.DeptId = deptId;
                db.SubDepts.Add(vm.SubDept);
                db.SaveChanges();
                return RedirectToAction("SubDeptList", new { deptId = deptId });
            }
            vm.Dept = db.Depts.Single(p => p.DeptId == deptId);
            return View(vm);
        }

        public ActionResult SubDeptEdit(int id)
        {
            SubDeptViewModel vm = new SubDeptViewModel();
            vm.SubDept = db.SubDepts.Single(p => p.SubDeptId == id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult SubDeptEdit(SubDeptViewModel vm, int id)
        {
            if (ModelState.IsValid)
            {
                db.SubDepts.Attach(vm.SubDept);
                db.Entry(vm.SubDept).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SubDeptList", new { deptId = vm.SubDept.DeptId });
            }
            return View(vm);
        }

        public ActionResult SubDeptDelete(int id)
        {
            SubDeptViewModel vm = new SubDeptViewModel();
            vm.SubDept = db.SubDepts.Single(p => p.SubDeptId == id);
            return View(vm);
        }

        [HttpPost, ActionName("SubDeptDelete")]
        public ActionResult SubDeptDeleteConfirmed(int id)
        {
            SubDept sub = db.SubDepts.Single(p => p.SubDeptId == id);
            var deptId = sub.DeptId;
            db.SubDepts.Remove(sub);
            db.SaveChanges();
            return RedirectToAction("SubDeptList", new { deptId = deptId });
        }

        #endregion

        public ActionResult TreeView()
        {
            var depts = db.Depts;
            return View(depts);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
