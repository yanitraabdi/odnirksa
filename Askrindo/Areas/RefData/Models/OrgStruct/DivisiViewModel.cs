using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.OrgStruct
{
    public class DivisiData
    {
        public int? DivisionId { get; set; }
        public int? DeptId { get; set; }
        public string DivisionName { get; set; }
        public bool IsSupporting { get; set; }
    }

    public class DivisiViewModel
    {
        public Division Divisi { get; set; }
        public IEnumerable<Division> Divisii { get; set; }
        public Dept Direktorat { get; set; }
        public DivisiParam Param { get; set; }
    }

    public class DivisiParam
    {
        public int? DeptId { get; set; }
        public SelectList DivisiList { get; set; }
    }
}