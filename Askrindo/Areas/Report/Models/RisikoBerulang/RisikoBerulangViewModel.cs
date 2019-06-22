using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Askrindo.Models;


namespace Askrindo.Areas.Report.Models.RisikoBerulang
{
    public class Param
    {
        public int? PosId { get; set; }
        public int? BranchId { get; set; }
        public int? SubDivId { get; set; }
        public int? KlasId { get; set; }
        public int? ReportId { get; set; }
        public int? PeriodeId { get; set; }

        public Boolean IsApproved { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReportDate1 { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReportDate2 { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReportDate3 { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReportDate4 { get; set; }

        public SelectList Unit { get; set; }
        public SelectList PosList { get; set; }
        public SelectList klasList { get; set; }
        public SelectList ReportType { get; set; }
        public SelectList PeriodeList { get; set; }

        public bool ShowLossCode { get; set; }
        public bool ShowLossDate { get; set; }
        public bool ShowOrg { get; set; }
        public bool ShowLossCat { get; set; }
        public bool ShowLossCause { get; set; }
        public bool ShowLossEffectFinancial { get; set; }
        public bool ShowLossEffectNonFinancial { get; set; }
        public bool ShowLossEvent { get; set; }
        public bool ShowPihakTerlibat { get; set; }
        public bool ShowLossAction { get; set; }
        public bool ShowAssets { get; set; }
        public bool ShowLocation { get; set; }
        public bool ShowKeterangan { get; set; }

    }

    public class RisikoBerulangRecord
    {
        public Askrindo.Models.RisikoBerulangRisikoUtama_Result risikoBerulangRisikoUtamaList { get; set; }
        public Askrindo.Models.RisikoBerulangKantorCabang_Result risikoBerulangKantorCabangList { get; set; }
        public Askrindo.Models.RisikoBerulangKantorPusat_Result risikoBerulangKantorPusatList { get; set; }
        public Askrindo.Models.RisikoBerulangSebabUtama_Result risikoBerulangSebabUtamaList { get; set; }
        public Askrindo.Models.RisikoBerulangTingkatRisiko_Result risikoBerulangTingkatRisikoList { get; set; }
    }
    
    public class RisikoBerulangViewModel
    {
        public Param Param { get; set; }
        public List<RisikoBerulangRecord> risikoBerulangList { get; set; }
    }

}