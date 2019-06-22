using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.OrgStruct
{
    public class BagianCabangViewModel
    {
        public SubBranch BagianCabang { get; set; }
        public Branch Cabang { get; set; }
        public BagianCabangParam Param { get; set; }
    }

    public class BagianCabangParam
    {
        public int? CabangId { get; set; }
        public SelectList CabangList { get; set; }
    }
}