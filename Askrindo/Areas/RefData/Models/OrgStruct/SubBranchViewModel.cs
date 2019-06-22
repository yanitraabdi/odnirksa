using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.OrgStruct
{
    public class SubBranchViewModel
    {
        public Branch Branch { get; set; }
        public SubBranch SubBranch { get; set; }
        public IEnumerable<SubBranch> SubBranches { get; set; }
    }
}