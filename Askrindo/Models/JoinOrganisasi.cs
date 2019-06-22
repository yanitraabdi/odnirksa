using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Askrindo.Models
{
    public class JoinOrganisasi
    {
        public Dept Dept { get; set; }
        public SubDept SubDept { get; set; }
        public Division Division { get; set; }
        public SubDiv SubDiv { get; set; }
        public Branch Branch { get; set; }
        public SubBranch SubBranch { get; set; }
        public BranchClass BranchClass { get; set; }
        public BizUnit BizUnit { get; set; }
    }
}