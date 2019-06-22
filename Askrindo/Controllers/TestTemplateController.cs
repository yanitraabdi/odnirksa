using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Askrindo.Controllers
{
    public class TestTemplateController : Controller
    {
        // GET: TestTemplate
        public ActionResult Index()
        {
            ViewBag.Title = "Template Page";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}