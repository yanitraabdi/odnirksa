using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Askrindo.Areas.Report.Models.RiskChart
{
    public class RiskChartViewModel
    {
        public int? PosId { get; set; }
        public int? BranchId { get; set; }
        public int? SubDivId { get; set; }
        public bool IsApproved { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReportDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReportDate2 { get; set; }

        [Required]
        public int ChartTypeId { get; set; } // column, bar, pie

        [Required]
        public int XValueId { get; set; } // none, sebab, akibat, klasifikasi, pusat/cabang, cabang, prob, dampak, tingkat risiko

        [Required]
        public int YValueId { get; set; } // jumlah data, prob, dampak, prob & dampak, tingkat risiko

        public SelectList PosList { get; set; }
        public SelectList Branches { get; set; }
        public SelectList ChartTypes { get; set; }
        public SelectList XValues { get; set; }
        public SelectList YValues { get; set; }
        public SelectList Unit { get; set; }
    }

    public class ChartData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Count { get; set; }
        public decimal Value { get; set; }
        public decimal Value2 { get; set; }
    }
}