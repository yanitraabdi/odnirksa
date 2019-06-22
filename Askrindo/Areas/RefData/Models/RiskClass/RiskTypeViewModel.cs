using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.RiskClass
{
    public class RiskTypeViewModel
    {
        public RiskType RiskType { get; set; }
        public IEnumerable<RiskType> RiskTypes { get; set; }
        public RiskGroup RiskGroup { get; set; }
        public IEnumerable<int> eventCount { get; set; }
    }
}