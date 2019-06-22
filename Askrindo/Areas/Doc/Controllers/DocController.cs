using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;
using Askrindo.Areas.Doc.Models.Doc;

namespace Askrindo.Areas.Doc.Controllers
{
    [Authorize]
    public class DocController : Controller
    {
        AskrindoEntities db = new AskrindoEntities();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View(db.HelpMenus);
        }

        public ActionResult List(int menuId)
        {
            DocVM vm = new DocVM();
            vm.HelpMenus = db.HelpMenus;
            vm.HelpMenu = db.HelpMenus.Single(p => p.MenuId == menuId);
            vm.HelpDocs = db.HelpDocs.Where(p => p.MenuId == menuId && p.IsVisible);
            return View(vm);
        }

        public ActionResult DocDownload(int id)
        {
            byte[] fileData;
            var doc = db.HelpDocs.Single(p => p.DocId == id);
            fileData = doc.Data.ToArray();
            return File(fileData, doc.ContentType, doc.Filename);
        }
    }
}
