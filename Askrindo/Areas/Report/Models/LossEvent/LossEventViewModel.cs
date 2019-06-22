using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Askrindo.Models;


namespace Askrindo.Areas.Report.Models.LossEvent
{
    public class Param
    {
        public int? PosId { get; set; }
        public int? BranchId { get; set; }
        public int? SubDivId { get; set; }
        public int? KlasId { get; set; }
        public int? PeriodeId { get; set; }

        public Boolean IsApproved { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReportDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReportDate2 { get; set; }

        public SelectList Unit { get; set; }
        public SelectList PosList { get; set; }
        public SelectList klasList { get; set; }
        public SelectList Periode { get; set; }

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

    public class LossRecord
    {
        public Askrindo.Models.LossEvent lossEvent { get; set; }
        public Askrindo.Models.LossEventPemilikView lossEventPemilik { get; set; }
        public Askrindo.Models.LossEventTahunView lossEventTahun { get; set; }
        public Askrindo.Models.LossEventBulanView lossEventBulan { get; set; }
        public Askrindo.Models.LossEventKantorView lossEventKantor { get; set; }
        public KlasifikasiKerugian klas { get; set; }
        public String pemilik { get; set; }
        public String year { get; set; }
    }
    
    public class LossEventViewModel
    {
        public Param Param { get; set; }
        public List<LossRecord> LossList { get; set; }
    }



}