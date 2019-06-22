using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.OrgStruct
{
    public class KantorCabangViewModel
    {
        public Dept Direktorat { get; set; }
        public Branch KantorCabang { get; set; }
        public KantorCabangParam Param { get; set; }
        public BranchClass Kelas { get; set; }
        public Korwil korwil { get; set; }
    }

    public class KantorCabangParam
    {
        public int? DeptId { get; set; }
        public int? KelasId { get; set; }
        public int? KorwilId { get; set; }
        public SelectList DirektoratList { get; set; }
        public SelectList KelasList { get; set; }
        public SelectList KorwilList { get; set; }
    }
}