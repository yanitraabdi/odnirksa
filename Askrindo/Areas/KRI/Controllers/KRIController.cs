﻿using Askrindo.Areas.KRI.Models;
using Askrindo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Askrindo.Helpers;

namespace Askrindo.Areas.KRI.Controllers
{
    public class KRIController : Controller
    {
        AskrindoEntities db = new AskrindoEntities();

        // GET: KRI/KRI
        public ActionResult Index()
        {
            ViewBag.Title = "NonInvest";

            ViewBag.currentPage = "KRI Non Investasi";
            ViewBag.breadCrumb = "KRI / Non Investasi";
            ViewBag.breadCrumbProperty = "style='background-color: orange;'";

            var vm = new NonInvestViewModel {
                KRINonInvests = db.KRINonInvests.ToList()
            };

            return View(vm);
        }

        public ActionResult ManageNonInvest(int Id)
        {
            ViewBag.Title = "NonInvest";

            var kri = db.KRINonInvests.Single(d => d.Id == Id);
            var vm = new NonInvestViewModel
            {
                KRINonInvest = kri,
                User = Utils.LoadUserDataFromSession()
            };

            ViewBag.currentPage = "Strategic Response";
            ViewBag.breadCrumb = "KRI / Non Investasi / " + kri.Name;
            ViewBag.breadCrumbProperty = "style='background-color: orange;'";

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageNonInvest(int Id, NonInvestViewModel vm) {
            var user = Utils.LoadUserDataFromSession();
            var kri = db.KRINonInvests.Single(d => d.Id == Id);
            var kriParam = kri.KRINonInvestParameters.Last();
            var indicatorCode = "K" + Utils.GetSerialNumberTemplate() + ".N" + Id;
            var value = vm.KRINonInvestData.Value;

            var nonInvest = new KRINonInvestData
            {
                Value = value,
                UserId = user.UserId,
                CreatedAt = DateTime.Now,
                TransactionDate = vm.KRINonInvestData.TransactionDate,
                Code = "",
                KRINonInvestId = Id,
                Grade = Utils.GenerateKRIGrade(kriParam, value),
                Target = kriParam.Target ?? 0
            };

            db.KRINonInvestDatas.Add(nonInvest);
            db.SaveChanges();

            nonInvest.Code = indicatorCode + "." + nonInvest.Id;
            db.SaveChanges();

            vm.KRINonInvest = db.KRINonInvests.Include("KRINonInvestDatas.UserInfo").Single(d => d.Id == Id);
            vm.User = Utils.LoadUserDataFromSession();

            return View(vm);
        }

        public ActionResult NonInvestStrategicResponseList(int Id)
        {
            ViewBag.Title = "NonInvest";

            var kriIndicator = db.KRINonInvestDatas.Include("KRINonInvest").Include("SRNonInvests").Single(r => r.Id == Id);
            var vm = new StrategicResponseViewModel
            {
                KRINonInvestData = kriIndicator,
                SRNonInvests = db.SRNonInvests.Where(r => r.KRIDataId == Id).ToList()
            };


            ViewBag.currentPage = "Strategic Response";
            ViewBag.breadCrumb = "KRI / Non Investasi / " + kriIndicator.KRINonInvest.Name + " / Strategic Response";
            ViewBag.breadCrumbProperty = "style='background-color: orange;'";

            return View(vm);
        }

        public ActionResult NonInvestStrategicResponseNew(int Id)
        {
            ViewBag.Title = "NonInvest";

            var user = Utils.LoadUserDataFromSession();

            var kriIndicator = db.KRINonInvestDatas.Include("KRINonInvest").Include("UserInfo").Single(r => r.Id == Id);
            var vm = new StrategicResponseViewModel {
                KRINonInvestData = kriIndicator,
                User = Utils.GetUserDataFromUserInfo(kriIndicator.UserInfo)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NonInvestStrategicResponseNew(StrategicResponseViewModel svm)
        {
            ViewBag.Title = "NonInvest";

            svm.SRNonInvest.SubmitDate = DateTime.Now;
            svm.SRNonInvest.KRIDataId = svm.KRINonInvestData.Id;
            db.SRNonInvests.Add(svm.SRNonInvest);
            db.SaveChanges();

            return RedirectToAction("NonInvestStrategicResponseList", new { Id = svm.KRINonInvestData.Id });
        }

        public ActionResult NonInvestStrategicResponseEdit(int Id)
        {
            ViewBag.Title = "NonInvest";

            var srNonInvest = db.SRNonInvests.Single(r => r.Id == Id);
            var user = srNonInvest.KRINonInvestData.UserInfo;

            var vm = new StrategicResponseViewModel
            {
                KRINonInvestData = srNonInvest.KRINonInvestData,
                SRNonInvest = srNonInvest,
                User = Utils.GetUserDataFromUserInfo(user)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NonInvestStrategicResponseEdit(StrategicResponseViewModel svm)
        {
            ViewBag.Title = "NonInvest";

            db.Entry(svm.SRNonInvest).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("NonInvestStrategicResponseList", new { svm.KRINonInvestData.Id });
        }

        public ActionResult NISRProgressList(int Id) {

            var srni = db.SRNonInvests.Include("KRINonInvestData").Single(r => r.Id == Id);
            var vm = new StrategicResponseViewModel {
                SRNonInvest = srni,
                KRINonInvestData = srni.KRINonInvestData,
                SRNonInvestProgresses = db.SRNonInvestProgresses.Where(r => r.SRId == Id).ToList(),
            };

            return View(vm);
        }

        public ActionResult NISRProgressNew(int Id)
        {
            var srni = db.SRNonInvests.Include("KRINonInvestData").Single(r => r.Id == Id);
            var vm = new StrategicResponseViewModel
            {
                SRNonInvest = srni,
                KRINonInvestData = srni.KRINonInvestData
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NISRProgressNew(StrategicResponseViewModel svm)
        {
            ViewBag.Title = "NonInvest";

            db.SRNonInvestProgresses.Add(svm.SRNonInvestProgress);
            db.SaveChanges();

            return RedirectToAction("NISRProgressList", new { svm.SRNonInvest.Id });
        }

        public ActionResult NISRProgressView(int Id) {
            var progress = db.SRNonInvestProgresses.Include("SRNonInvest").Single(d => d.Id == Id);

            var vm = new StrategicResponseViewModel {
                SRNonInvestProgress = progress,
                SRNonInvest = progress.SRNonInvest
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NISRProgressView(StrategicResponseViewModel vm)
        {
            db.Entry(vm.SRNonInvestProgress).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("NISRProgressView", new { vm.SRNonInvestProgress.Id });
        }

        public ActionResult NonInvestStrategicResponseDetail()
        {
            ViewBag.Title = "NonInvest";
            return View();
        }

        public ActionResult NISRProgressActionList(int Id) {

            var vm = new StrategicResponseViewModel
            {
                SRNonInvestProgress = db.SRNonInvestProgresses.Single(d => d.Id == Id),
                SRNIProgressActions = db.SRNIProgressActions.Where(d => d.SRNonInvestProgressId == Id).ToList()
            };

            return View(vm);
        }

        public ActionResult NISRProgressActionNew(int Id) {

            var vm = new StrategicResponseViewModel {
                SRNonInvestProgress = db.SRNonInvestProgresses.Single(d => d.Id == Id)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NISRProgressActionNew(StrategicResponseViewModel vm) {

            vm.SRNIProgressAction.SRNonInvestProgressId = vm.SRNonInvestProgress.Id;
            vm.SRNIProgressAction.Tanggal = DateTime.Now;

            db.SRNIProgressActions.Add(vm.SRNIProgressAction);
            db.SaveChanges();

            return RedirectToAction("NISRProgressActionList", new { vm.SRNonInvestProgress.Id });
        }

        public ActionResult Invest()
        {
            ViewBag.Title = "Invest";

            var vm = new InvestViewModel
            {
                KRIInvests = db.KRIInvests.ToList()
            };

            return View(vm);
        }

        public ActionResult ManageInvest(int Id)
        {
            ViewBag.Title = "Invest";

            var kri = db.KRIInvests.Single(d => d.Id == Id);
            var vm = new InvestViewModel
            {
                KRIInvest = kri,
                User = Utils.LoadUserDataFromSession()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManageInvest(int Id, InvestViewModel vm)
        {
            var user = Utils.LoadUserDataFromSession();
            var kri = db.KRIInvests.Single(d => d.Id == Id);
            var kriParam = kri.KRIInvestParameters.Last();
            var indicatorCode = "K" + Utils.GetSerialNumberTemplate() + ".I" + Id;
            var value = vm.KRIInvestData.Value;

            var nonInvest = new KRIInvestData
            {
                Value = value,
                UserId = user.UserId,
                CreatedAt = DateTime.Now,
                TransactionDate = vm.KRIInvestData.TransactionDate,
                Code = "",
                KRIInvestId = Id,
                Grade = Utils.GenerateKRIGrade(kriParam, value),
                Target = kriParam.Target ?? 0
            };

            db.KRIInvestDatas.Add(nonInvest);
            db.SaveChanges();

            nonInvest.Code = indicatorCode + "." + nonInvest.Id;
            db.SaveChanges();
            
            vm.KRIInvest = db.KRIInvests.Include("KRIInvestDatas.UserInfo").Single(d => d.Id == Id);
            vm.User = Utils.LoadUserDataFromSession();

            return View(vm);
        }

        public ActionResult InvestStrategicResponseList(int Id)
        {
            ViewBag.Title = "Invest";

            var kriIndicator = db.KRIInvestDatas.Include("KRIInvest").Include("SRInvests").Single(r => r.Id == Id);
            var vm = new InvestStrategicResponseViewModel
            {
                KRIInvestData = kriIndicator,
                SRInvests = db.SRInvests.Where(r => r.KRIInvestDataId == Id).ToList()
            };


            ViewBag.currentPage = "Strategic Response";
            ViewBag.breadCrumb = "KRI / Investasi / " + kriIndicator.KRIInvest.Name + " / Strategic Response";
            ViewBag.breadCrumbProperty = "style='background-color: orange;'";

            return View(vm);
        }

        public ActionResult InvestStrategicResponseNew(int Id)
        {
            ViewBag.Title = "Invest";

            var user = Utils.LoadUserDataFromSession();

            var kriIndicator = db.KRIInvestDatas.Include("KRIInvest").Include("UserInfo").Single(r => r.Id == Id);
            var vm = new InvestStrategicResponseViewModel
            {
                KRIInvestData = kriIndicator,
                User = Utils.GetUserDataFromUserInfo(kriIndicator.UserInfo)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InvestStrategicResponseNew(InvestStrategicResponseViewModel svm)
        {
            ViewBag.Title = "Invest";

            svm.SRInvest.SubmitDate = DateTime.Now;
            svm.SRInvest.KRIInvestDataId = svm.KRIInvestData.Id;
            db.SRInvests.Add(svm.SRInvest);
            db.SaveChanges();

            return RedirectToAction("InvestStrategicResponseList", new { Id = svm.KRIInvestData.Id });
        }

        public ActionResult InvestStrategicResponseEdit(int Id)
        {
            ViewBag.Title = "Invest";

            var srInvest = db.SRInvests.Single(r => r.Id == Id);
            var user = srInvest.KRIInvestData.UserInfo;

            var vm = new InvestStrategicResponseViewModel
            {
                KRIInvestData = srInvest.KRIInvestData,
                SRInvest = srInvest,
                User = Utils.GetUserDataFromUserInfo(user)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InvestStrategicResponseEdit(InvestStrategicResponseViewModel svm)
        {
            ViewBag.Title = "Invest";

            db.Entry(svm.SRInvest).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("InvestStrategicResponseList", new { svm.KRIInvestData.Id });
        }

        public ActionResult ISRProgressList(int Id)
        {

            var sri = db.SRInvests.Include("KRIInvestData").Single(r => r.Id == Id);
            var vm = new InvestStrategicResponseViewModel
            {
                SRInvest = sri,
                KRIInvestData = sri.KRIInvestData,
                SRInvestProgresses = db.SRInvestProgresses.Where(r => r.SRInvestId == Id).ToList(),
            };

            return View(vm);
        }

        public ActionResult ISRProgressNew(int Id)
        {
            var sri = db.SRInvests.Include("KRIInvestData").Single(r => r.Id == Id);
            var vm = new InvestStrategicResponseViewModel
            {
                SRInvest = sri,
                KRIInvestData = sri.KRIInvestData
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ISRProgressNew(InvestStrategicResponseViewModel svm)
        {
            ViewBag.Title = "Invest";

            db.SRInvestProgresses.Add(svm.SRInvestProgress);
            db.SaveChanges();

            return RedirectToAction("ISRProgressList", new { svm.SRInvest.Id });
        }

        public ActionResult ISRProgressView(int Id)
        {
            var progress = db.SRInvestProgresses.Include("SRInvest").Single(d => d.Id == Id);

            var vm = new InvestStrategicResponseViewModel
            {
                SRInvestProgress = progress,
                SRInvest = progress.SRInvest
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ISRProgressView(InvestStrategicResponseViewModel vm)
        {
            db.Entry(vm.SRInvestProgress).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ISRProgressView", new { vm.SRInvestProgress.Id });
        }

        public ActionResult InvestStrategicResponseDetail()
        {
            ViewBag.Title = "Invest";
            return View();
        }

        public ActionResult ISRProgressActionList(int Id)
        {

            var vm = new InvestStrategicResponseViewModel
            {
                SRInvestProgress = db.SRInvestProgresses.Single(d => d.Id == Id),
                SRIProgressActions = db.SRIProgressActions.Where(d => d.SRInvestProgressId == Id).ToList()
            };

            return View(vm);
        }

        public ActionResult ISRProgressActionNew(int Id)
        {

            var vm = new InvestStrategicResponseViewModel
            {
                SRInvestProgress = db.SRInvestProgresses.Single(d => d.Id == Id)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ISRProgressActionNew(InvestStrategicResponseViewModel vm)
        {

            vm.SRIProgressAction.SRInvestProgressId = vm.SRInvestProgress.Id;
            vm.SRIProgressAction.Tanggal = DateTime.Now;

            db.SRIProgressActions.Add(vm.SRIProgressAction);
            db.SaveChanges();

            return RedirectToAction("ISRProgressActionList", new { vm.SRInvestProgress.Id });
        }
    }
}