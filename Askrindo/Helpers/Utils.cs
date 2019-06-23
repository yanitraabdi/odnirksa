using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;
using System.Data.Entity;

namespace Askrindo.Helpers
{
    public class UserData
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public int OrgPos { get; set; }
        public int OrgPosId { get; set; }
        public bool IsRiskOwner { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string OrgPosName { get; set; }
        public int? DeptId { get; set; }
        public int? SubDeptId { get; set; }
        public int? DivisionId { get; set; }
        public int? SubDivId { get; set; }
        public int? BranchId { get; set; }
        public int? SubBranchId { get; set; }
        public int? BizUnitId { get; set; }
        public int? BranchClassId { get; set; }
    }

    public class Utils
    {
        public const string S_ADMIN = "Adminermask15";

        public const string S_ISADMIN = "IsAdmin";
        public const string S_ISADMINMR = "IsAdminMR";
        public const string S_ORGPOS = "OrgPos";
        public const string S_FULLNAME = "FullName";
        public const string S_JOBTITLE = "JobTitle";
        public const string S_POS1 = "Pos1";
        public const string S_POS2 = "Pos2";

        public const int ORGPOS_DEPT = 1;
        public const int ORGPOS_SUBDEPT = 2;
        public const int ORGPOS_DIVISION = 3;
        public const int ORGPOS_SUBDIV = 4;
        public const int ORGPOS_BRANCH = 5;
        public const int ORGPOS_SUBBRANCH = 6;
        public const int ORGPOS_BIZUNIT = 7;

        public const int BRANCHCLASS1 = 1;
        public const int BRANCHCLASS2 = 2;
        public const int BRANCHCLASS3 = 3;

        public const int PROBLEVEL1 = 1;
        public const int PROBLEVEL5 = 5;

        public const int IMPACTLEVEL1 = 1;
        public const int IMPACTLEVEL2 = 2;
        public const int IMPACTLEVEL3 = 3;
        public const int IMPACTLEVEL4 = 4;
        public const int IMPACTLEVEL5 = 5;

        public const int IMPACTPOS_HQ = 1;
        public const int IMPACTPOS_BRANCH1 = 2;
        public const int IMPACTPOS_BRANCH2 = 3;
        public const int IMPACTPOS_BRANCH3 = 4;
        public const int IMPACTPOS_BIZUNIT = 5;
        public const int IMPACTPOS_SUPPORTINGHQ = 6;
        public const int IMPACTPOS_SUPPORTINGBRANCH = 7;
        public const int IMPACTPOS_SUPPORTINGBIZUNIT = 8;

        public const int FREQUENCY1 = 1;

        public const int MAX_LIMIT_APPROVAL_DAYS = 3;

        public const int PROBOPTION_POISSON = 1;
        public const int PROBOPTION_BINOMIAL = 2;
        public const int PROBOPTION_APPROXIMATION = 3;
        public const int PROBOPTION_COMPARISON = 4;
        public const int PROBOPTION_FREQUENCY = 5;

        public static string OrgPosLabel(int orgPos)
        {
            switch (orgPos)
            {
                case ORGPOS_DEPT:
                    return "Direktorat";
                case ORGPOS_SUBDEPT:
                    return "Bagian";
                case ORGPOS_DIVISION:
                    return "Divisi";
                case ORGPOS_SUBDIV:
                    return "Bagian";
                case ORGPOS_BRANCH:
                    return "Cabang";
                case ORGPOS_SUBBRANCH:
                    return "Bagian";
                case ORGPOS_BIZUNIT:
                    return "KUP";
                default:
                    return string.Empty;
            }
        }

        public static string GetRiskOrgNameLoss(LossEvent i)
        {
            AskrindoEntities db = new AskrindoEntities();

            var r = db.Risks.Where(p => p.UserId == i.UserId).FirstOrDefault();

            switch (r.OrgPos)
            {
                case ORGPOS_DEPT:
                    return r.Dept.DeptName;
                case ORGPOS_SUBDEPT:
                    return r.SubDept.SubDeptName;
                case ORGPOS_DIVISION:
                    return r.Division.DivisionName;
                case ORGPOS_SUBDIV:
                    return r.SubDiv.SubDivName;
                case ORGPOS_BRANCH:
                    return r.Branch.BranchName;
                case ORGPOS_SUBBRANCH:
                    return r.SubBranch.SubBranchName;
                case ORGPOS_BIZUNIT:
                    return r.BizUnit.BizUnitName;
                default:
                    return string.Empty;
            }
        }

        public static string GetRiskOrgName(Risk r)
        {
            switch (r.OrgPos)
            {
                case ORGPOS_DEPT:
                    return r.Dept.DeptName;
                case ORGPOS_SUBDEPT:
                    return r.SubDept.SubDeptName;
                case ORGPOS_DIVISION:
                    return r.Division.DivisionName;
                case ORGPOS_SUBDIV:
                    return r.SubDiv.SubDivName;
                case ORGPOS_BRANCH:
                    return r.Branch.BranchName;
                case ORGPOS_SUBBRANCH:
                    return r.Branch.BranchName;
                //return r.SubBranch.SubBranchName;
                case ORGPOS_BIZUNIT:
                    return r.BizUnit.BizUnitName;
                default:
                    return string.Empty;
            }
        }

        public static string GetImpactLevelText(int impactLevelId)
        {
            AskrindoEntities db = new AskrindoEntities();
            var data = db.ImpactLevels.Single(p => p.ImpactLevelId == impactLevelId);
            return impactLevelId.ToString() + " - " + data.ImpactLevelName;
        }

        public static void GetRiskLevelColors(int riskLevelId, out string backColor, out string foreColor)
        {
            backColor = "White";
            foreColor = "Black";

            AskrindoEntities db = new AskrindoEntities();
            var levels = db.RiskLevels;
            foreach (var item in levels)
            {
                if (riskLevelId >= item.MinValue && riskLevelId <= item.MaxValue)
                {
                    backColor = item.BackColor;
                    foreColor = item.ForeColor;
                    return;
                }
            }
        }

        public static string GetProbLevelText(int probLevelId)
        {
            AskrindoEntities db = new AskrindoEntities();
            var data = db.ProbLevels.Single(p => p.ProbLevelId == probLevelId);
            return probLevelId.ToString() + " - " + data.ProbLevelName;
        }

        public static int GetImpactPos(UserData data)
        {
            AskrindoEntities db = new AskrindoEntities();

            switch (data.OrgPos)
            {
                case ORGPOS_SUBDEPT:
                    var subDept = db.SubDepts.Single(p => p.SubDeptId == data.SubDeptId);
                    if (subDept.IsSupporting)
                        return IMPACTPOS_SUPPORTINGHQ;
                    else
                        return IMPACTPOS_HQ;
                case ORGPOS_DIVISION:
                    var div = db.Divisions.Single(p => p.DivisionId == data.DivisionId);
                    if (div.IsSupporting)
                        return IMPACTPOS_SUPPORTINGHQ;
                    else
                        return IMPACTPOS_HQ;
                case ORGPOS_SUBDIV:
                    var subDiv = db.SubDivs.Single(p => p.SubDivId == data.SubDivId);
                    if (subDiv.IsSupporting)
                        return IMPACTPOS_SUPPORTINGHQ;
                    else
                        return IMPACTPOS_HQ;
                case ORGPOS_BRANCH:
                    var branch = db.Branches.Single(p => p.BranchId == data.BranchId);
                    if (branch.IsSupporting)
                        return IMPACTPOS_SUPPORTINGBRANCH;
                    else
                    {
                        if (branch.ClassId == BRANCHCLASS1)
                            return IMPACTPOS_BRANCH1;
                        else if (branch.ClassId == BRANCHCLASS2)
                            return IMPACTPOS_BRANCH2;
                        else
                            return IMPACTPOS_BRANCH3;
                    }
                case ORGPOS_SUBBRANCH:
                    var subBranch = db.SubBranches.Single(p => p.SubBranchId == data.SubBranchId);
                    if (subBranch.IsSupporting)
                        return IMPACTPOS_SUPPORTINGBRANCH;
                    else
                    {
                        if (subBranch.Branch.ClassId == BRANCHCLASS1)
                            return IMPACTPOS_BRANCH1;
                        else if (subBranch.Branch.ClassId == BRANCHCLASS2)
                            return IMPACTPOS_BRANCH2;
                        else
                            return IMPACTPOS_BRANCH3;
                    }
                case ORGPOS_BIZUNIT:
                    var biz = db.BizUnits.Single(p => p.BizUnitId == data.BizUnitId);
                    if (biz.IsSupporting)
                        return IMPACTPOS_SUPPORTINGBIZUNIT;
                    else
                        return IMPACTPOS_BIZUNIT;
                default:
                    return IMPACTPOS_HQ;
            }
        }

        private static UserData GetUserDataFromDb(string userName)
        {
            AskrindoEntities db = new AskrindoEntities();
            UserData data = new UserData();

            var currentUser = db.AspNetUsers.Where(d => d.UserName == userName).FirstOrDefault();
            var userId = Guid.Parse(currentUser.Id);

            data.IsRiskOwner = false;
            data.IsAdmin = string.Compare(userName.ToLower(), Utils.S_ADMIN.ToLower()) == 0;
            if (data.IsAdmin)
            {
                data.UserName = userName;
                data.FullName = "Administrator";
            }
            else
            {
                UserInfo nfo = db.UserInfos.Where(p => p.UserId == userId).FirstOrDefault();
                data.UserId = userId;
                data.UserName = nfo.AspNetUser.UserName;
                data.FullName = nfo.FullName;
                data.JobTitle = nfo.JobTitle;
                data.OrgPos = nfo.OrgPos;
                data.IsRiskOwner = nfo.IsRiskOwner;

                switch (data.OrgPos)
                {
                    case ORGPOS_DIVISION:
                        data.OrgPosId = (int)nfo.DivisionId;
                        Division div = db.Divisions.Single(p => p.DivisionId == nfo.DivisionId);
                        data.OrgPosName = string.Format("Direktorat: {0}, Divisi: {1}",
                            div.Dept.DeptName, div.DivisionName);
                        data.DivisionId = div.DivisionId;
                        data.DeptId = div.DeptId;
                        break;
                    case ORGPOS_SUBDEPT:
                        data.OrgPosId = (int)nfo.SubDeptId;
                        SubDept subDept = db.SubDepts.Single(p => p.SubDeptId == nfo.SubDeptId);
                        data.OrgPosName = string.Format("Direktorat: {0}, Bagian: {1}",
                            subDept.Dept.DeptName, subDept.SubDeptName);
                        data.SubDeptId = subDept.SubDeptId;
                        data.DeptId = subDept.DeptId;
                        break;
                    case ORGPOS_SUBDIV:
                        data.OrgPosId = (int)nfo.SubDivId;
                        SubDiv subDiv = db.SubDivs.Single(p => p.SubDivId == nfo.SubDivId);
                        data.OrgPosName = string.Format("Divisi: {0}, Bagian: {1}",
                            subDiv.Division.DivisionName, subDiv.SubDivName);
                        data.SubDivId = subDiv.SubDivId;
                        data.DivisionId = subDiv.DivisionId;
                        data.DeptId = subDiv.Division.DeptId;
                        break;
                    case ORGPOS_BRANCH:
                        data.OrgPosId = (int)nfo.BranchId;
                        Branch branch = db.Branches.Single(p => p.BranchId == nfo.BranchId);
                        data.OrgPosName = string.Format("Cabang: {0}", branch.BranchName);
                        data.BranchId = branch.BranchId;
                        data.BranchClassId = branch.ClassId;
                        break;
                    case ORGPOS_SUBBRANCH:
                        data.OrgPosId = (int)nfo.SubBranchId;
                        SubBranch subBranch = db.SubBranches.Single(p => p.SubBranchId == nfo.SubBranchId);
                        data.OrgPosName = string.Format("Cabang: {0}, Bagian: {1}",
                            subBranch.Branch.BranchName, subBranch.SubBranchName);
                        data.SubBranchId = subBranch.SubBranchId;
                        data.BranchId = subBranch.BranchId;
                        data.BranchClassId = subBranch.Branch.ClassId;
                        break;
                    case ORGPOS_BIZUNIT:
                        data.OrgPosId = (int)nfo.BizUnitId;
                        BizUnit biz = db.BizUnits.Single(p => p.BizUnitId == nfo.BizUnitId);
                        data.OrgPosName = string.Format("Cabang: {0}, KUP: {1}",
                            biz.Branch.BranchName, biz.BizUnitName);
                        data.BizUnitId = biz.BizUnitId;
                        data.BranchId = biz.BranchId;
                        data.BranchClassId = biz.Branch.ClassId;
                        break;
                }
            }

            HttpContext.Current.Session["Data"] = data;

            return data;
        }
       
        public static int? GetOrgPosId(UserData user) {
            int? orgPosUnitId = null;

            switch (user.OrgPos)
            {
                case Utils.ORGPOS_DEPT:
                    orgPosUnitId = user.DeptId;
                    break;
                case Utils.ORGPOS_SUBDEPT:
                    orgPosUnitId = user.SubDeptId;
                    break;
                case Utils.ORGPOS_DIVISION:
                    orgPosUnitId = user.DivisionId;
                    break;
                case Utils.ORGPOS_SUBDIV:
                    orgPosUnitId = user.SubDivId;
                    break;
                case Utils.ORGPOS_BRANCH:
                    orgPosUnitId = user.BranchId;
                    break;
                case Utils.ORGPOS_SUBBRANCH:
                    orgPosUnitId = user.SubBranchId;
                    break;
                case Utils.ORGPOS_BIZUNIT:
                    orgPosUnitId = user.BizUnitId;
                    break;
            }

            return orgPosUnitId;
        }

        public static UserData GetUserDataFromUserInfo(UserInfo nfo)
        {
            AskrindoEntities db = new AskrindoEntities();
            UserData data = new UserData();

            var currentUser = nfo.AspNetUser;
            var userId = Guid.Parse(currentUser.Id);

            data.IsRiskOwner = false;
            data.IsAdmin = string.Compare(currentUser.UserName.ToLower(), Utils.S_ADMIN.ToLower()) == 0;
            if (data.IsAdmin)
            {
                data.UserName = currentUser.UserName;
                data.FullName = "Administrator";
            }
            else
            {
                data.UserId = userId;
                data.UserName = nfo.AspNetUser.UserName;
                data.FullName = nfo.FullName;
                data.JobTitle = nfo.JobTitle;
                data.OrgPos = nfo.OrgPos;
                data.IsRiskOwner = nfo.IsRiskOwner;

                switch (data.OrgPos)
                {
                    case ORGPOS_DIVISION:
                        data.OrgPosId = (int)nfo.DivisionId;
                        Division div = db.Divisions.Single(p => p.DivisionId == nfo.DivisionId);
                        data.OrgPosName = string.Format("Direktorat: {0}, Divisi: {1}",
                            div.Dept.DeptName, div.DivisionName);
                        data.DivisionId = div.DivisionId;
                        data.DeptId = div.DeptId;
                        break;
                    case ORGPOS_SUBDEPT:
                        data.OrgPosId = (int)nfo.SubDeptId;
                        SubDept subDept = db.SubDepts.Single(p => p.SubDeptId == nfo.SubDeptId);
                        data.OrgPosName = string.Format("Direktorat: {0}, Bagian: {1}",
                            subDept.Dept.DeptName, subDept.SubDeptName);
                        data.SubDeptId = subDept.SubDeptId;
                        data.DeptId = subDept.DeptId;
                        break;
                    case ORGPOS_SUBDIV:
                        data.OrgPosId = (int)nfo.SubDivId;
                        SubDiv subDiv = db.SubDivs.Single(p => p.SubDivId == nfo.SubDivId);
                        data.OrgPosName = string.Format("Divisi: {0}, Bagian: {1}",
                            subDiv.Division.DivisionName, subDiv.SubDivName);
                        data.SubDivId = subDiv.SubDivId;
                        data.DivisionId = subDiv.DivisionId;
                        data.DeptId = subDiv.Division.DeptId;
                        break;
                    case ORGPOS_BRANCH:
                        data.OrgPosId = (int)nfo.BranchId;
                        Branch branch = db.Branches.Single(p => p.BranchId == nfo.BranchId);
                        data.OrgPosName = string.Format("Cabang: {0}", branch.BranchName);
                        data.BranchId = branch.BranchId;
                        data.BranchClassId = branch.ClassId;
                        break;
                    case ORGPOS_SUBBRANCH:
                        data.OrgPosId = (int)nfo.SubBranchId;
                        SubBranch subBranch = db.SubBranches.Single(p => p.SubBranchId == nfo.SubBranchId);
                        data.OrgPosName = string.Format("Cabang: {0}, Bagian: {1}",
                            subBranch.Branch.BranchName, subBranch.SubBranchName);
                        data.SubBranchId = subBranch.SubBranchId;
                        data.BranchId = subBranch.BranchId;
                        data.BranchClassId = subBranch.Branch.ClassId;
                        break;
                    case ORGPOS_BIZUNIT:
                        data.OrgPosId = (int)nfo.BizUnitId;
                        BizUnit biz = db.BizUnits.Single(p => p.BizUnitId == nfo.BizUnitId);
                        data.OrgPosName = string.Format("Cabang: {0}, KUP: {1}",
                            biz.Branch.BranchName, biz.BizUnitName);
                        data.BizUnitId = biz.BizUnitId;
                        data.BranchId = biz.BranchId;
                        data.BranchClassId = biz.Branch.ClassId;
                        break;
                }
            }

            HttpContext.Current.Session["Data"] = data;

            return data;
        }
        public static UserData LoadUserDataFromSession()
        {
            UserData data = HttpContext.Current.Session["Data"] as UserData;
            if (data == null)
            {
                data = GetUserDataFromDb(HttpContext.Current.User.Identity.Name);
            }
            return data;
        }

        public static UserData LoadUserDataFromSession(string userName)
        {
            UserData data = HttpContext.Current.Session["Data"] as UserData;
            if (data == null)
            {
                data = GetUserDataFromDb(userName);
            }
            return data;
        }

        private static void ValidateSerialNumber()
        {
            AskrindoEntities db = new AskrindoEntities();
            SerialNumber sn = db.SerialNumbers.Where(s => s.Id == 1).FirstOrDefault();
            if (db.SerialNumbers.Count() == 0)
            {
                sn = new SerialNumber();
                sn.Year = DateTime.Now.Year;
                sn.SN = 1;
                db.SerialNumbers.Add(sn);
                db.SaveChanges();
            }
            else
            {
                sn = db.SerialNumbers.First();
                if (sn.Year != DateTime.Now.Year)
                {
                    sn.Year = DateTime.Now.Year;
                    sn.SN = 1;
                    db.SaveChanges();
                }
            }
        }

        private static void ValidateSerialNumberLossEvent()
        {
            AskrindoEntities db = new AskrindoEntities();
            SerialNumber sn = db.SerialNumbers.Where(s => s.Id == 2).FirstOrDefault();
            if (db.SerialNumbers.Count() == 0)
            {
                sn = new SerialNumber();
                sn.Year = DateTime.Now.Year;
                sn.SN = 1;
                db.SerialNumbers.Add(sn);
                db.SaveChanges();
            }
            else
            {
                sn = db.SerialNumbers.First();
                if (sn.Year != DateTime.Now.Year)
                {
                    sn.Year = DateTime.Now.Year;
                    sn.SN = 1;
                    db.SaveChanges();
                }
            }
        }

        public static string GetFormattedSerialNumber(UserData data)
        {
            ValidateSerialNumber();
            AskrindoEntities db = new AskrindoEntities();

            string branchCode = "99";
            string bizCode = "00";

            if (data.BranchClassId != null)
            {
                Branch branch = db.Branches.Single(p => p.BranchId == data.BranchId);
                branchCode = branch.BranchCode.Trim().PadLeft(2, '0');
            }
            if (data.BizUnitId != null)
            {
                BizUnit biz = db.BizUnits.Single(p => p.BizUnitId == data.BizUnitId);
                bizCode = biz.BizUnitCode.Trim().PadLeft(2, '0');
            }

            string year = DateTime.Now.Year.ToString().PadLeft(4, '0');
            string month = DateTime.Now.Month.ToString().PadLeft(2, '0');

            SerialNumber sn = db.SerialNumbers.Where(s => s.Id == 1).FirstOrDefault();

            return branchCode + "." + bizCode + "." + year + "." + month + "." + sn.SN.ToString().PadLeft(4, '0');
        }

        public static string GetFormattedSerialNumberLossEvent(UserData data)
        {
            ValidateSerialNumberLossEvent();
            AskrindoEntities db = new AskrindoEntities();

            string branchCode = "99";
            string bizCode = "00";

            if (data.BranchClassId != null)
            {
                Branch branch = db.Branches.Single(p => p.BranchId == data.BranchId);
                branchCode = branch.BranchCode.Trim().PadLeft(2, '0');
            }
            if (data.BizUnitId != null)
            {
                BizUnit biz = db.BizUnits.Single(p => p.BizUnitId == data.BizUnitId);
                bizCode = biz.BizUnitCode.Trim().PadLeft(2, '0');
            }

            string year = DateTime.Now.Year.ToString().PadLeft(4, '0');
            string month = DateTime.Now.Month.ToString().PadLeft(2, '0');

            SerialNumber sn = db.SerialNumbers.Where(s => s.Id == 2).FirstOrDefault();

            return branchCode + "." + bizCode + "." + year + "." + month + "." + sn.SN.ToString().PadLeft(4, '0');
        }

        public static string GetSerialNumberTemplate()
        {
            UserData data = LoadUserDataFromSession();
            AskrindoEntities db = new AskrindoEntities();

            string branchCode = "99";
            string bizCode = "00";

            if (data.BranchClassId.HasValue)
            {
                Branch branch = db.Branches.Single(p => p.BranchId == data.BranchId);
                branchCode = branch.BranchCode.Trim().PadLeft(2, '0');
            }
            if (data.BizUnitId.HasValue)
            {
                BizUnit biz = db.BizUnits.Single(p => p.BizUnitId == data.BizUnitId);
                bizCode = biz.BizUnitCode.Trim().PadLeft(2, '0');
            }

            string year = DateTime.Now.Year.ToString().PadLeft(4, '0');
            string month = DateTime.Now.Month.ToString().PadLeft(2, '0');

            return branchCode + "." + bizCode + "." + year + "." + month;
        }

        public static void IncrementSerialNumber(AskrindoEntities db)
        {
            var sn = db.SerialNumbers.Where(s => s.Id == 1).FirstOrDefault();
            sn.SN++;
            db.SaveChanges();
        }

        public static void IncrementSerialNumberLossEvent(AskrindoEntities db)
        {
            var sn = db.SerialNumbers.Where(s => s.Id == 2).FirstOrDefault();
            sn.SN++;
            db.SaveChanges();
        }

        public static int GetProbLevelFromValue(int pct)
        {
            AskrindoEntities db = new AskrindoEntities();
            int maxValue = int.MinValue;
            foreach (var level in db.ProbLevels)
            {
                if (pct >= level.PctMin && pct < level.PctMax)
                    return level.ProbLevelId;

                if (maxValue < level.PctMax)
                    maxValue = level.PctMax;
            }
            if (pct >= maxValue)
                return PROBLEVEL5;
            else
                return PROBLEVEL1;
        }

        public static int GetProbLevelFromValue(decimal pct)
        {
            AskrindoEntities db = new AskrindoEntities();
            int maxValue = int.MinValue;
            foreach (var level in db.ProbLevels)
            {
                if (pct >= level.PctMin && pct < level.PctMax)
                    return level.ProbLevelId;

                if (maxValue < level.PctMax)
                    maxValue = level.PctMax;
            }
            if (pct >= maxValue)
                return PROBLEVEL5;
            else
                return PROBLEVEL1;
        }

        public static int GetImpactLevelFromMoney(decimal value, int impactPos = IMPACTPOS_HQ)
        {
            AskrindoEntities db = new AskrindoEntities();
            var impactRef = db.ImpactRefs.First();
            decimal pct = 0M;
            switch (impactPos)
            {
                case IMPACTPOS_HQ:
                    pct = impactRef.HQPct;
                    break;
                case IMPACTPOS_BRANCH1:
                    pct = impactRef.Branch1Pct;
                    break;
                case IMPACTPOS_BRANCH2:
                    pct = impactRef.Branch2Pct;
                    break;
                case IMPACTPOS_BRANCH3:
                    pct = impactRef.Branch3Pct;
                    break;
                case IMPACTPOS_BIZUNIT:
                    pct = impactRef.BizUnitPct;
                    break;
                case IMPACTPOS_SUPPORTINGHQ:
                    pct = impactRef.HQPct;
                    break;
                case IMPACTPOS_SUPPORTINGBRANCH:
                    pct = impactRef.SupportingBranchPct;
                    break;
                case IMPACTPOS_SUPPORTINGBIZUNIT:
                    pct = impactRef.SupportingBizUnitPct;
                    break;
            }

            decimal maxValue = decimal.MinValue;
            decimal value1;
            decimal value2;
            foreach (var level in db.ImpactLevels)
            {
                value1 = level.MoneyMin * pct / 100M;
                value2 = level.MoneyMax * pct / 100M;
                if (value >= value1 && value < value2)
                    return level.ImpactLevelId;

                if (maxValue < value2)
                    maxValue = value2;
            }
            if (value >= maxValue)
                return IMPACTLEVEL5;
            else
                return IMPACTLEVEL1;
        }

        public static void CreateFirstApprovalSchedule(Risk risk, AskrindoEntities db)
        {
            RiskApproval app;
            app = db.RiskApprovals.Where(p => p.RiskId == risk.RiskId && p.OrgPos == risk.OrgPos).FirstOrDefault();
            if (app == null)
            {
                app = new RiskApproval();
                app.RiskId = risk.RiskId;
                app.OrgPos = risk.OrgPos;
                switch (app.OrgPos)
                {
                    case ORGPOS_DEPT:
                        app.DeptId = risk.DeptId;
                        app.OrgName = risk.Dept.DeptName;
                        break;
                    case ORGPOS_SUBDEPT:
                        app.SubDeptId = risk.SubDeptId;
                        app.OrgName = db.SubDepts.First(d => d.SubDeptId == risk.SubDeptId).SubDeptName;
                        break;
                    case ORGPOS_DIVISION:
                        app.DivisionId = risk.DivisionId;
                        app.OrgName = db.Divisions.First(d => d.DivisionId == risk.DivisionId).DivisionName;
                        break;
                    case ORGPOS_SUBDIV:
                        app.SubDivId = risk.SubDivId;

                        app.OrgName =db.SubDivs.First(d=>d.SubDivId== risk.SubDivId).SubDivName;
                        break;
                    case ORGPOS_BRANCH:
                        app.BranchId = risk.BranchId;
                        app.OrgName = db.Branches.First(d => d.BranchId == risk.BranchId).BranchName;
                        break;
                    case ORGPOS_SUBBRANCH:
                        app.SubBranchId = risk.SubBranchId;
                        app.OrgName = risk.SubBranch.SubBranchName;
                        break;
                    case ORGPOS_BIZUNIT:
                        app.BizUnitId = risk.BizUnitId;
                        app.OrgName = risk.BizUnit.BizUnitName;
                        break;
                }

                app.LimitDate = risk.RiskDate.AddDays(MAX_LIMIT_APPROVAL_DAYS);
                app.LastApproval = app.OrgPos == ORGPOS_SUBDEPT || app.OrgPos == ORGPOS_DIVISION || app.OrgPos == ORGPOS_BRANCH;
                app.IsReadOnly = false;

                db.RiskApprovals.Add(app);
            }
        }

        public static void CreateFirstApprovalSchedule(Risk risk)
        {
            AskrindoEntities db = new AskrindoEntities();
            CreateFirstApprovalSchedule(risk, db);
            db.SaveChanges();
        }


        public static void CalcRiskLevel(Risk risk)
        {
            if (risk.ProbLevelId == null || risk.ImpactLevelId == null)
                risk.RiskLevel = null;
            else
                risk.RiskLevel = (int)risk.ProbLevelId * (int)risk.ImpactLevelId;
        }


        public static string GetProbOptionName(int probOption)
        {
            switch (probOption)
            {
                case PROBOPTION_POISSON:
                    return "Statistik Poisson (data tersedia)";
                case PROBOPTION_BINOMIAL:
                    return "Statistik Binomial (data tersedia)";
                case PROBOPTION_APPROXIMATION:
                    return "Aproksimasi (data tidak tersedia)";
                case PROBOPTION_COMPARISON:
                    return "Perbandingan (data tidak tersedia)";
                case PROBOPTION_FREQUENCY:
                    return "Frekuensi (data tidak tersedia)";
                default:
                    return string.Empty;
            }
        }

        public static string CreateNewMitigationCode(int riskId)
        {
            var db = new AskrindoEntities();
            var risk = db.Risks.FirstOrDefault(p => p.RiskId == riskId);
            var riskCode = risk.RiskCode;
            var mitigations = db.RiskMitigations.Where(p => p.RiskId == riskId);
            int i = 1;
            string s;
            while (true)
            {
                s = risk.RiskCode + "." + i.ToString().PadLeft(2, '0');
                var m = mitigations.FirstOrDefault(p => p.MitigationCode == s);
                if (m == null)
                    return s;
                i++;
            }
        }

        public static void CreateFirstMitigationApprovalSchedule(RiskMitigation rm)
        {
            AskrindoEntities db = new AskrindoEntities();
            CreateFirstMitigationApprovalSchedule(rm, db);
        }

        public static void CreateFirstMitigationApprovalSchedule(RiskMitigation mg, AskrindoEntities db)
        {
            MitigationApproval apr = new MitigationApproval();
            apr.MitigationId = mg.MitigationId;
            apr.OrgPos = mg.OrgPos;
            switch (apr.OrgPos)
            {
                case ORGPOS_DEPT:
                    apr.DeptId = mg.DeptId;
                    break;
                case ORGPOS_SUBDEPT:
                    apr.SubDeptId = mg.SubDeptId;
                    break;
                case ORGPOS_DIVISION:
                    apr.DivisionId = mg.DivisionId;
                    break;
                case ORGPOS_SUBDIV:
                    apr.SubDivId = mg.SubDivId;
                    break;
                case ORGPOS_BRANCH:
                    apr.BranchId = mg.BranchId;
                    break;
                case ORGPOS_SUBBRANCH:
                    apr.SubBranchId = mg.SubBranchId;
                    break;
                case ORGPOS_BIZUNIT:
                    apr.BizUnitId = mg.BizUnitId;
                    break;
            }
            apr.LastApproval = apr.OrgPos == ORGPOS_SUBDEPT || apr.OrgPos == ORGPOS_DIVISION || apr.OrgPos == ORGPOS_BRANCH;
            apr.IsReadOnly = false;
            db.MitigationApprovals.Add(apr);
            db.SaveChanges();
        }

        public static void ApproveMitigation(int approvalId, AskrindoEntities db)
        {
            using (var trans = db.Database.BeginTransaction())
            {
                UserData data = LoadUserDataFromSession();
                MitigationApproval apr = db.MitigationApprovals.Where(p => p.ApprovalId == approvalId).FirstOrDefault();
                apr.ApprovalDate = DateTime.Now;
                apr.UserId = data.UserId;
                apr.JobTitle = data.JobTitle;
                db.SaveChanges();

                apr.RiskMitigation.IsReadOnly = true;
                db.SaveChanges();

                if (apr.LastApproval)
                {
                    // mitigation approval complete
                    apr.RiskMitigation.ApprovalDate = apr.ApprovalDate;
                    db.SaveChanges();

                    MitigationApproval prevApr = db.MitigationApprovals
                        .Where(p => p.MitigationId == apr.MitigationId && p.ApprovalId != apr.ApprovalId && p.ApprovalDate != null)
                        .FirstOrDefault();
                    if (prevApr != null)
                        prevApr.IsReadOnly = true;
                    db.SaveChanges();

                    RiskState rs = new RiskState();
                    rs.RiskId = apr.RiskMitigation.RiskId;
                    rs.MitigationId = apr.MitigationId;
                    rs.StateDate = (DateTime)apr.ApprovalDate;
                    rs.ProbLevelId = (int)apr.RiskMitigation.ProbLevelId;
                    rs.ImpactLevelId = (int)apr.RiskMitigation.ImpactLevelId;
                    rs.RiskLevel = (int)apr.RiskMitigation.RiskLevel;
                    db.RiskStates.Add(rs);
                    db.SaveChanges();
                }
                else
                {
                    // create next approval schedule
                    MitigationApproval nextApr = new MitigationApproval();
                    nextApr.MitigationId = apr.MitigationId;
                    nextApr.LimitDate = DateTime.Now.AddDays(Utils.MAX_LIMIT_APPROVAL_DAYS);
                    nextApr.LastApproval = true;

                    switch (apr.OrgPos)
                    {
                        case Utils.ORGPOS_SUBDIV:
                            SubDiv subDiv = db.SubDivs.Single(p => p.SubDivId == apr.SubDivId);
                            nextApr.OrgPos = Utils.ORGPOS_DIVISION;
                            nextApr.DivisionId = subDiv.DivisionId;
                            break;
                        case Utils.ORGPOS_SUBBRANCH:
                            SubBranch subBranch = db.SubBranches.Single(p => p.SubBranchId == apr.SubBranchId);
                            nextApr.OrgPos = Utils.ORGPOS_BRANCH;
                            nextApr.BranchId = subBranch.BranchId;
                            break;
                        case Utils.ORGPOS_BIZUNIT:
                            BizUnit bizUnit = db.BizUnits.Single(p => p.BizUnitId == apr.BizUnitId);
                            nextApr.OrgPos = Utils.ORGPOS_BRANCH;
                            nextApr.BranchId = bizUnit.BranchId;
                            break;
                    }
                    db.MitigationApprovals.Add(nextApr);
                    db.SaveChanges();
                }
                trans.Commit();
            }
        }

        private static string GenerateKRIGrade(KRILimitPoint limitPoint, string order, decimal? target, string type, decimal value)
        {
            if (target.HasValue)
            {
                if (type == "target")
                {
                    value = (value / target.Value) * 100;
                }
                else if (type == "reference")
                {
                    value = ((value - target.Value) / target.Value) * 100;
                }
                else
                {

                }
            }

            var gs = GradeString();

            if (type == "segment")
            {
                return value > target.Value ? gs[0] : gs[3];
            }
            else
            {
                if (
                    (limitPoint.Min1.HasValue && limitPoint.Min1.Value <= value) ||
                    (limitPoint.Max1.HasValue && limitPoint.Max1.Value >= value)
                    )
                {
                    return order == ">" ? gs[0] : gs[3];
                }
                else if (limitPoint.Min2 <= value && limitPoint.Max2 >= value)
                {
                    return order == ">" ? gs[1] : gs[2];
                }
                else if (limitPoint.Min3 <= value && limitPoint.Max3 >= value)
                {
                    return order == ">" ? gs[2] : gs[1];
                }
                else
                {
                    return order == ">" ? gs[3] : gs[0];
                }
            }
        }

        public static string[] GradeString() {
            return new string[] {
                "safe",
                "warning",
                "danger",
                "risk"
            };
        }

        public static string GenerateKRIGrade(KRINonInvestParameter param, decimal value)
        {
            var lp = new KRILimitPoint
            {
                Min1 = param.Min1,
                Max1 = param.Max1,

                Min2 = param.Min2,
                Max2 = param.Max2,

                Min3 = param.Min3,
                Max3 = param.Max3,

                Min4 = param.Min4,
                Max4 = param.Max4
            };
            return GenerateKRIGrade(lp, param.Order, param.Target, param.Type, value);
        }

        public static string GenerateKRIGrade(KRIInvestParameter param, decimal value)
        {
            var lp = new KRILimitPoint
            {
                Min1 = param.Min1,
                Max1 = param.Max1,

                Min2 = param.Min2,
                Max2 = param.Max2,

                Min3 = param.Min3,
                Max3 = param.Max3,

                Min4 = param.Min4,
                Max4 = param.Max4
            };
            return GenerateKRIGrade(lp, param.Order, param.Target, param.Type, value);
        }

        public static void GenerateKRIDummy() {
            AskrindoEntities db = new AskrindoEntities();

            var NIIndicators = new List<KRINonInvest> {
                //new KRINonInvest{ Name = "Hasil Underwriting (Premi bruto - klaim - biaya reass + recovery + klaim reass)", Division = "Asuransi Umum", DivisionCode = "AUM" },
                //new KRINonInvest{ Name = "Claim Ratio (premi/claim)", Division = "Asuransi Umum", DivisionCode = "AUM" },
                //new KRINonInvest{ Name = "SLA Penutupan Pertanggungan", Division = "Asuransi Umum", DivisionCode = "AUM" },
                //new KRINonInvest{ Name = "Hasil Underwriting (Premi bruto - klaim - biaya reass + recovery + klaim reass)", Division = "Underwriting Non Kredit", DivisionCode = "UNK" },
                //new KRINonInvest{ Name = "Claim Ratio (premi/claim)", Division = "Underwriting Non Kredit", DivisionCode = "UNK" },

                //new KRINonInvest{ Name = "SLA Penutupan Pertanggungan", Division = "Underwriting Non Kredit", DivisionCode = "UNK" },
                //new KRINonInvest{ Name = "Hasil Underwriting (Premi bruto - klaim - biaya reass + recovery + klaim reass)", Division = "Underwriting Kredit", DivisionCode = "UKR" },
                //new KRINonInvest{ Name = "Claim Ratio (premi/claim)", Division = "Underwriting Kredit", DivisionCode = "UKR" },
                //new KRINonInvest{ Name = "SLA Penutupan Pertanggungan", Division = "Underwriting Kredit", DivisionCode = "UKR" },
                //new KRINonInvest{ Name = "Claim Ratio (premi/claim)", Division = "Klaim", DivisionCode = "KLM" },

                //new KRINonInvest{ Name = "SLA Penutupan Pertanggungan", Division = "Klaim", DivisionCode = "KLM" },
                //new KRINonInvest{ Name = "Indeks kepuasan pelanggan", Division = "Klaim", DivisionCode = "KLM" },
                //new KRINonInvest{ Name = "Ketepatan isi laporan keuangan", Division = "Akuntansi dan Anggaran", DivisionCode = "AKA" },
                //new KRINonInvest{ Name = "Penyajian laporan keuangan tepat waktu", Division = "Akuntansi dan Anggaran", DivisionCode = "AKA" },
                //new KRINonInvest{ Name = "Claim Ratio (premi/claim)", Division = "Hukum dan Subrogasi", DivisionCode = "HKS" },

                //new KRINonInvest{ Name = "Produktifitas pegawai", Division = "Hukum dan Subrogasi", DivisionCode = "HKS"},
                //new KRINonInvest{ Name = "Premi Bruto", Division = "Retail dan Program", DivisionCode = "RTP" },
                //new KRINonInvest{ Name = "Pangsa Pasar", Division = "Retail dan Program", DivisionCode = "RTP" },
                //new KRINonInvest{ Name = "Indeks Kepuasan Pelanggan", Division = "Retail dan Program", DivisionCode = "RTP" },
                //new KRINonInvest{ Name = "Produktifitas pegawai", Division = "Manajemen Bisnis", DivisionCode = "MNB" },

                //new KRINonInvest{ Name = "Produktifitas pegawai", Division = "Sumber Daya Manusia", DivisionCode = "SDM" },
                //new KRINonInvest{ Name = "Tenaga Ahli", Division = "Sumber Daya Manusia", DivisionCode = "SDM" },
                //new KRINonInvest{ Name = "Tingkat Kepuasan Pegawai", Division = "Sumber Daya Manusia", DivisionCode = "SDM" },
                //new KRINonInvest{ Name = "Claim Ratio (premi/claim)", Division = "Pemasaran BUMN", DivisionCode = "PBU" },
                //new KRINonInvest{ Name = "Premi Bruto", Division = "Komersial Bank", DivisionCode = "KMB" },

                //new KRINonInvest{ Name = "Premi Bruto", Division = "KUR dan Program", DivisionCode = "KUP" },
                //new KRINonInvest{ Name = "Claim Ratio (premi/claim)", Division = "KUR dan Program", DivisionCode = "KUP" },
                //new KRINonInvest{ Name = "SLA Penutupan Pertanggungan", Division = "KUR dan Program", DivisionCode = "KUP" },
                //new KRINonInvest{ Name = "Penyerapan Plafond KUR", Division = "KUR dan Program", DivisionCode = "KUP" },
                //new KRINonInvest{ Name = "Downtime (core system)", Division = "Teknologi Informasi", DivisionCode = "TIN" },

                new KRINonInvest{ Name = "Premi Bruto", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "Hasil Underwriting", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "Kontribusi Anak Perusahaan", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "Return of Equity", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "Earning After Tax", Division = "", DivisionCode = "" },

                new KRINonInvest{ Name = "Risk Based Capital", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "Rasio BOPO", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "SBN", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "Pangsa Pasar", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "Indeks Kepuasan Pelanggan", Division = "", DivisionCode = "" },

                new KRINonInvest{ Name = "Claim Ratio", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "Downtime", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "GCG", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "KPKU", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "SLA Penutupan Pertanggungan", Division = "", DivisionCode = "" },

                new KRINonInvest{ Name = "YOI", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "Penyerapan Plafond KUR", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "Produktifitas Pegawai", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "Tenaga Ahli", Division = "", DivisionCode = "" },
                new KRINonInvest{ Name = "Tingkat Kepuasan Pegawai", Division = "", DivisionCode = "" },
            };

            db.KRINonInvests.AddRange(NIIndicators);
            db.SaveChanges();

            var NIParameters = new List<KRINonInvestParameter> ();

            //for (int i = 1; i <= 30; i++)
            //{
            //    if ((new List<int> { 2,5,8,15,24,27 }).Exists(d => d == i))
            //    {
            //        NIParameters.Add(new KRINonInvestParameter
            //        {
            //            Min1 = -20,
            //            Min2 = -20,
            //            Max2 = -5,
            //            Min3 = -5,
            //            Max3 = 5,
            //            Max4 = 5,
            //            Order = "<",
            //            KRINonInvestId = i,
            //            Type = "target",
            //            Target = 1000_000_000,
            //            CreatedAt = DateTime.Now
            //        });
            //    }
            //    else if((new List<int> { 3,28 }).Exists(d => d == i))
            //    {
            //        NIParameters.Add(new KRINonInvestParameter
            //        {
            //            Min1 = 70,
            //            Min2 = 70,
            //            Max2 = 80,
            //            Min3 = 80,
            //            Max3 = 90,
            //            Max4 = 90,
            //            Order = "<",
            //            KRINonInvestId = i,
            //            Type = "target",
            //            Target = 1000_000_000,
            //            CreatedAt = DateTime.Now
            //        });
            //    }
            //    else if ((new List<int> { 6,9,10 }).Exists(d => d == i))
            //    {
            //        NIParameters.Add(new KRINonInvestParameter
            //        {
            //            Min1 = 70,
            //            Min2 = 70,
            //            Max2 = 80,
            //            Min3 = 80,
            //            Max3 = 90,
            //            Max4 = 100,
            //            Order = "<",
            //            KRINonInvestId = i,
            //            Type = "target",
            //            Target = 1000_000_000,
            //            CreatedAt = DateTime.Now
            //        });
            //    }
            //    else if((new List<int> { 12,19,22,29 }).Exists(d => d == i))
            //    {
            //        NIParameters.Add(new KRINonInvestParameter
            //        {
            //            Min1 = 97,
            //            Max1 = 100,
            //            Min2 = 94,
            //            Max2 = 96,
            //            Min3 = 90,
            //            Max3 = 93,
            //            Max4 = 90,
            //            Order = ">",
            //            KRINonInvestId = i,
            //            Type = "target",
            //            Target = 1000_000_000,
            //            CreatedAt = DateTime.Now
            //        });
            //    }
            //    else if ((new List<int> { 16,20,21,23 }).Exists(d => d == i))
            //    {
            //        NIParameters.Add(new KRINonInvestParameter
            //        {
            //            Min1 = 99,
            //            Max1 = 100,
            //            Min2 = 98,
            //            Max2 = 99,
            //            Min3 = 95,
            //            Max3 = 98,
            //            Max4 = 95,
            //            Order = ">",
            //            KRINonInvestId = i,
            //            Type = "target",
            //            Target = 1000_000_000,
            //            CreatedAt = DateTime.Now
            //        });
            //    }
            //    else
            //    {
            //        NIParameters.Add(new KRINonInvestParameter
            //        {
            //            Min1 = 100,
            //            Min2 = 95,
            //            Max2 = 100,
            //            Min3 = 90,
            //            Max3 = 95,
            //            Max4 = 90,
            //            Order = ">",
            //            KRINonInvestId = i,
            //            Type = "target",
            //            Target = 1000_000_000,
            //            CreatedAt = DateTime.Now
            //        });
            //    }
            //}

            for (int i = 1; i <= 20; i++)
            {
                if ((new List<int> { 3 }).Exists(d => d == i))
                {
                    NIParameters.Add(new KRINonInvestParameter
                    {
                        Min1 = 25,
                        Min2 = 20,
                        Max2 = 25,
                        Min3 = 15,
                        Max3 = 20,
                        Max4 = 15,
                        Order = ">",
                        KRINonInvestId = i,
                        Type = "target",
                        Target = 1000_000_000,
                        CreatedAt = DateTime.Now
                    });
                }
                else if ((new List<int> { 6 }).Exists(d => d == i))
                {
                    NIParameters.Add(new KRINonInvestParameter
                    {
                        Min1 = 200,
                        Min2 = 150,
                        Max2 = 200,
                        Min3 = 120,
                        Max3 = 150,
                        Max4 = 120,
                        Order = ">",
                        KRINonInvestId = i,
                        Type = "target",
                        Target = 1000_000_000,
                        CreatedAt = DateTime.Now
                    });
                }
                else if ((new List<int> { 7 }).Exists(d => d == i))
                {
                    NIParameters.Add(new KRINonInvestParameter
                    {
                        Max1 = 5,
                        Min2 = 5,
                        Max2 = 10,
                        Min3 = 10,
                        Max3 = 15,
                        Min4 = 15,
                        Order = "<",
                        KRINonInvestId = i,
                        Type = "target",
                        Target = 1000_000_000,
                        CreatedAt = DateTime.Now
                    });
                }
                else if ((new List<int> { 8 }).Exists(d => d == i))
                {
                    NIParameters.Add(new KRINonInvestParameter
                    {
                        Min1 = 40,
                        Min2 = 30,
                        Max2 = 40,
                        Min3 = 20,
                        Max3 = 30,
                        Max4 = 20,
                        Order = ">",
                        KRINonInvestId = i,
                        Type = "target",
                        Target = 1000_000_000,
                        CreatedAt = DateTime.Now
                    });
                }
                else if ((new List<int> { 10, 17, 19 }).Exists(d => d == i))
                {
                    NIParameters.Add(new KRINonInvestParameter
                    {
                        Min1 = 97,
                        Max1 = 100,
                        Min2 = 94,
                        Max2 = 96,
                        Min3 = 90,
                        Max3 = 93,
                        Max4 = 90,
                        Order = ">",
                        KRINonInvestId = i,
                        Type = "target",
                        Target = 1000_000_000,
                        CreatedAt = DateTime.Now
                    });
                }
                else if ((new List<int> { 11 }).Exists(d => d == i))
                {
                    NIParameters.Add(new KRINonInvestParameter
                    {
                        Min1 = -20,
                        Min2 = -20,
                        Max2 = -5,
                        Min3 = -5,
                        Max3 = 5,
                        Max4 = 5,
                        Order = "<",
                        KRINonInvestId = i,
                        Type = "target",
                        Target = 1000_000_000,
                        CreatedAt = DateTime.Now
                    });
                }
                else if ((new List<int> { 12 }).Exists(d => d == i))
                {
                    NIParameters.Add(new KRINonInvestParameter
                    {
                        Min1 = 0,
                        Min2 = 1,
                        Max2 = 60,
                        Min3 = 61,
                        Max3 = 120,
                        Max4 = 120,
                        Order = "<",
                        KRINonInvestId = i,
                        Type = "none",
                        Target = 1000_000_000,
                        CreatedAt = DateTime.Now
                    });
                }
                else if ((new List<int> { 13, 14, 18, 20 }).Exists(d => d == i))
                {
                    NIParameters.Add(new KRINonInvestParameter
                    {
                        Min1 = 99,
                        Max1 = 100,
                        Min2 = 98,
                        Max2 = 99,
                        Min3 = 95,
                        Max3 = 98,
                        Max4 = 95,
                        Order = ">",
                        KRINonInvestId = i,
                        Type = "target",
                        Target = 1000_000_000,
                        CreatedAt = DateTime.Now
                    });
                }
                else if ((new List<int> { 16 }).Exists(d => d == i))
                {
                    NIParameters.Add(new KRINonInvestParameter
                    {
                        Order = ">",
                        KRINonInvestId = i,
                        Type = "segment",
                        Target = 5.25M,
                        CreatedAt = DateTime.Now
                    });
                }
                else
                {
                    NIParameters.Add(new KRINonInvestParameter
                    {
                        Min1 = 100,
                        Min2 = 95,
                        Max2 = 100,
                        Min3 = 90,
                        Max3 = 95,
                        Max4 = 90,
                        Order = ">",
                        KRINonInvestId = i,
                        Type = "target",
                        Target = 1000_000_000,
                        CreatedAt = DateTime.Now
                    });
                }
            }

            db.KRINonInvestParameters.AddRange(NIParameters);
            db.SaveChanges();

            var IIndicators = new List<KRIInvest> {
                new KRIInvest{ Name = "Indeks Harga Saham Gabungan ", Division = "Keuangan dan Bisnis", DivisionCode = "KUB" },
                new KRIInvest{ Name = "Nilai Tukar Rupiah", Division = "Keuangan dan Bisnis", DivisionCode = "KUB" },
                new KRIInvest{ Name = "Country Risk Premium", Division = "Keuangan dan Bisnis", DivisionCode = "KUB" },
                new KRIInvest{ Name = "7 Days Reverse Repo", Division = "Keuangan dan Bisnis", DivisionCode = "KUB" },
                new KRIInvest{ Name = "Inflasi", Division = "Keuangan dan Bisnis", DivisionCode = "KUB" },
                new KRIInvest{ Name = "Fed Rate", Division = "Keuangan dan Bisnis", DivisionCode = "KUB" },
                new KRIInvest{ Name = "Yield Sun", Division = "Keuangan dan Bisnis", DivisionCode = "KUB" }
            };

            db.KRIInvests.AddRange(IIndicators);
            db.SaveChanges();

            var IParameters = new List<KRIInvestParameter>();

            for (int i = 1; i <= 7; i++)
            {
                IParameters.Add(new KRIInvestParameter
                {
                    Max1 = 4.9M,
                    Min1 = -5,

                    Max2 = -5.1M,
                    Min2 = -10,

                    Max3 = -9.9M,
                    Min3 = -14.9M,

                    Max4 = -14.9M,
                    Min4 = -15,

                    Order = ">",
                    KRIInvestId = i,
                    Type = "reference",
                    Target = 6000,
                    CreatedAt = DateTime.Now
                });
            }

            db.KRIInvestParameters.AddRange(IParameters);
            db.SaveChanges();
        }
    }

    public class KRILimitPoint {
        public decimal? Min1 { get; set; }
        public decimal? Max1 { get; set; }

        public decimal Min2 { get; set; }
        public decimal Max2 { get; set; }

        public decimal Min3 { get; set; }
        public decimal Max3 { get; set; }

        public decimal? Min4 { get; set; }
        public decimal? Max4 { get; set; }
    }

    public static class Extensions
    {
        public static string MaxLength(this string s, int length)
        {
            if (s.Length > length)
            {
                if (s.Length > 2)
                    return s.Substring(0, length - 3) + "...";
                else
                    return s.Substring(0, length);
            }
            else
                return s;
        }
    }
}