using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.OrgStruct
{
    public class BagianData
    {
        public int? SubDivId { get; set; }
        public int? DivId { get; set; }
        public string SubDivName { get; set; }
        public bool IsSupporting { get; set; }
    }

    public class BagianViewModel
    {
        public SubDiv Bagian { get; set; }
        public IEnumerable<SubDiv> Bagians { get; set; }
        public Dept Direktorat { get; set; }
        public Division Divisi { get; set; }
        public BagianParam Param { get; set; }
    }

    public class BagianParam
    {
        public int? DeptId { get; set; }
        public int? DivId { get; set; }
        public SelectList DirektoratList { get; set; }
        public SelectList DivisiList { get; set; }
    }

}