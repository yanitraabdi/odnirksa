using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;

namespace Askrindo.Areas.RCSA.Models
{
    public class RCSANewViewModel
    {
        public string KodeRisiko { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public List<RiskCat> RiskCats { get; set; }
        public List<CauseGroup> CauseGroups { get; set; }
        public List<EffectGroup> EffectGroups { get; set; }
    }

    public class SearchViewModel
    {
        public string Keyword { get; set; }
        public List<RiskEvent> RiskEvents { get; set; }
    }

    public class RiskViewModel
    {
        public Risk RiskData { get; set; }
        public List<RiskAttachment> AttachmentList { get; set; }
        public List<ImpactCat> ImpactCats { get; set; }
        public RiskImpact RiskImpact { get; set; }
        public RiskNonMoneyImpact RiskNonMoneyImpact { get; set; }
        public List<Freq> Freqs { get; set; }
        public RiskProb RiskProb { get; set; }
    }

    public class MitigationViewModel
    {
        public Risk Risk { get; set; }

        public RiskMitigation RiskMitigation { get; set; }
        public IEnumerable<RiskMitigation> RiskMitigations { get; set; }
        public SelectList MitigationCats { get; set; }
        public SelectList MitigationTypes { get; set; }
        public SelectList ProbLevels { get; set; }
        public SelectList ImpactLevels { get; set; }

        public IEnumerable<MitigationUnit> MitigationUnit { get; set; }
        public MitigationUnit MitigationUnits { get; set; }

        public Division division { get; set; }
        public IEnumerable<DivisionTable> DivisionTable { get; set; }
        public SelectList divisions { get; set; }
        public IEnumerable<Division> divisionName { get; set; }

        public Boolean IsMitigation { get; set; }

        public IEnumerable<MitigationApproval> MitigationApprovals { get; set; }
    }

    public class DivisionTable
    {
        public int DivisionId { get; set; }
        public String DivisionName { get; set; }
        public int MitigationUnitId { get; set; }
        public int MitigationId { get; set; }
    }

    public class MitigationActionModel
    {
        public int? PosId { get; set; }
        public SelectList PosList { get; set; }

        public int? BranchId { get; set; }
        public SelectList Branches { get; set; }

        public int? StateId { get; set; } // 1: normal, 2: read only, 3: approved, 4: closed
        public SelectList States { get; set; }

        public IEnumerable<MitigationApproval> MitigationApprovals { get; set; }
        public IEnumerable<RiskMitigation> RiskMitigations { get; set; }

        public MitigationsAction action { get; set; }
        public IEnumerable<MitigationsAction> actionList { get; set; }

        public RiskMitigation riskMitigation { get; set; }

        public ActionProgress progress { get; set; }
        public IEnumerable<ActionProgress> progressList { get; set; }

        [DataType(DataType.Date)]
        public DateTime tglAwal { get; set; }

        [DataType(DataType.Date)]
        public DateTime tglAkhir { get; set; }

        public SelectList prob { get; set; }
        public SelectList impact { get; set; }

        public ActionApproval ActionApproval { get; set; }

        public int? mitigationid { get; set; }

        public int? actionId { get; set; }
        public String mitigationcode { get; set; }
        public String mitigationactioncode { get; set; }
        public String actionName { get; set; }
        public String pic { get; set; }
        public String require { get; set; }
        public DateTime? limitDate { get; set; }
        public Boolean isRKAP1 { get; set; }
        public Boolean? isRKAP2 { get; set; }
        public Decimal totalProgress { get; set; }
        public Decimal? biaya { get; set; }

        public Decimal ActionProgress { get; set; }

    }

    public class MitigationActionAppModel
    {
        public IEnumerable<RiskMitigation> riskMitigation { get; set; }
        public IEnumerable<MitigationsAction> actionList { get; set; }
        public MitigationsAction action { get; set; }
        public RiskMitigation mitigation { get; set; }
        public ActionApproval actionApp { get; set; }

        public int actionId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime tglAwal { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime tglAkhir { get; set; }

        public String mitigationcode { get; set; }
        public Boolean isApproved { get; set; }
    }
}