using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.OrgStruct
{
    public class KantorUnitViewModel
    {
        public BizUnit KantorUnit { get; set; }
        public Branch Cabang { get; set; }
        public KantorUnitParam Param { get; set; }
    }

    public class KantorUnitParam
    {
        public int? CabangId { get; set; }
        public SelectList CabangList { get; set; }
    }
}