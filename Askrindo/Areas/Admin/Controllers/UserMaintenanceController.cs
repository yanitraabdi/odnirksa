using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Areas.Admin.Models.UserMaintenance;
using System.Web.Security;
using Askrindo.Models;

namespace Askrindo.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserMaintenanceController : Controller
    {
        AskrindoEntities db = new AskrindoEntities();

        public ActionResult Index()
        {
            UserViewModel vm = new UserViewModel();
            vm.UserList = new List<AskrindoUser>();

            var users = db.UserInfos.Include("AspNetUser").OrderBy(p => p.FullName);
            foreach (var u in users)
            {
                vm.UserList.Add(new AskrindoUser()
                {
                    UserId = u.UserId,
                    UserName = u.AspNetUser.UserName,
                    FullName = u.FullName,
                    LastLoginDate = DateTime.Now,
                    IsRiskOwner = u.IsRiskOwner,
                    IsLocked = u.AspNetUser.LockoutEnabled
                });
            }
            return View(vm);
        }

        public ActionResult UnlockUser(Guid userId)
        {
            MembershipUser usr = Membership.GetUser(userId);
            if (usr == null)
            {
                ViewBag.Message = "Data user tidak ditemukan";
                return View("Error");
            }
            return View(db.UserInfos.Single(p => p.UserId == userId));
        }

        [HttpPost, ActionName("UnlockUser")]
        public ActionResult UnlockUserConfirmed(Guid userId)
        {
            MembershipUser usr = Membership.GetUser(userId);
            if (usr == null)
            {
                ViewBag.Message = "Tidak bisa meng-unlock user. Data user tidak ditemukan";
                return View("Error");
            }
            if (usr.UnlockUser())
            {
                Membership.UpdateUser(usr);
                ViewBag.Message = "User telah di-unlock";
                return View("Info");
            }
            else
            {
                ViewBag.Message = "Gagal meng-unlock user";
                return View("Error");
            }
        }
    }
}
