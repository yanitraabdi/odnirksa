using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.OrgStruct
{
    public class DibawahDirektoratData
    {
        public int? SubDeptId { get; set; }
        public int? DeptId { get; set; }
        public string SubDeptName { get; set; }
        public bool IsSupporting { get; set; }
    }

    public class DibawahDirektoratParam
    {
        public int? DeptId { get; set; }
        public SelectList Direktorat { get; set; }
    }

    public class DibawahDirektoratViewModal
    {
        //public List<DibawahDirektoratData> RiskList { get; set; }
        public SubDept DibawahDirektorat { get; set; }
        public IEnumerable<SubDept> SubDepts { get; set; }
        public Dept Direktorat { get; set; }
        public DibawahDirektoratParam Param { get; set; }
    }
}