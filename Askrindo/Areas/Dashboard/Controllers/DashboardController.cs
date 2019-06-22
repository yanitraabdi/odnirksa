using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Askrindo.Areas.Dashboard.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetRiskTotal()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetRiskMatrix()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetDLELoss()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetKRIPercentage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetRiskDistribution()
        {
            return View();
        }
    }
}