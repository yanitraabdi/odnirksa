using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.OrgStruct
{
    public class BizUnitViewModel
    {
        public Branch Branch { get; set; }
        public BizUnit BizUnit { get; set; }
        public IEnumerable<BizUnit> BizUnits { get; set; }
    }
}