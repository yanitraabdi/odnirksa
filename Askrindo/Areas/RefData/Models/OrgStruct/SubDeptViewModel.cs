using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.OrgStruct
{
    public class SubDeptViewModel
    {
        public SubDept SubDept { get; set; }
        public IEnumerable<SubDept> SubDepts { get; set; }
        public Dept Dept { get; set; }
    }
}