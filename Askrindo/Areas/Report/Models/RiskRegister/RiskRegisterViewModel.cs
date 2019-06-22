using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Askrindo.Areas.Report.Models.RiskRegister
{
    public class Param
    {
        public int? PosId { get; set; }
        public int? BranchId { get; set; }
        public int? RiskLevelId { get; set; }
        public int? RiskLevelId2 { get; set; }
        public int? SubDivId { get; set; }
        public int? KorwilId { get; set; }
        public int? KlasId { get; set; }
        public int? BisnisId { get; set; }
        public bool IsApproved { get; set; }

        public String ReportName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime ReportDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime ReportDate2 { get; set; }

        public SelectList PosList { get; set; }
        public SelectList Branches { get; set; }
        public SelectList RiskLevels { get; set; }
        public SelectList Division { get; set; }
        public SelectList Unit { get; set; }
        public SelectList KlasList { get; set; }
        public SelectList BisnisList { get; set; }

        public bool ShowRiskCode { get; set; }
        public bool ShowRiskDate { get; set; }
        public bool ShowOrg { get; set; }
        public bool ShowRiskCat { get; set; }
        public bool ShowRiskType { get; set; }
        public bool ShowRiskCause { get; set; }
        public bool ShowRiskEffect { get; set; }
        public bool ShowRiskOwner { get; set; }
        public bool ShowProbLevel { get; set; }
        public bool ShowImpactLevel { get; set; }
        public bool ShowApprovedMitigations { get; set; }
        public bool ShowPlannedMitigations { get; set; }
        public bool ShowUraianProgress { get; set; }
        public bool ShowPIC { get; set; }
        public bool ShowUnitKerja { get; set; }
        public bool ShowResource { get; set; }
        public bool ShowEstimasi { get; set; }
        public bool ShowRKAP { get; set; }
        public bool ShowProgress { get; set; }
    }

    public class RiskRecord
    {
        public Risk Risk { get; set; }
        public IEnumerable<RiskMitigation> ApprovedMitigations { get; set; }
        public IEnumerable<RiskMitigation> PlannedMitigations { get; set; }
        public IEnumerable<MitigationsAction> MitigationActionApprove { get; set; }
        public IEnumerable<MitigationsAction> MitigationActionPlanned { get; set; }
        public IEnumerable<MitigationUnit> MitigationUnit { get; set; }
    }

    public class RiskRegisterViewModel
    {
        public Param Param { get; set; }
        //public List<Risk> RiskList { get; set; }
        public List<RiskRecord> RiskList { get; set; }
    }
}