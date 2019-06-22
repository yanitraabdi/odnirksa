using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models
{
    public class RiskEventModel
    {
        public RiskEvent riskEvent { get; set; }
        public IEnumerable<RiskEvent> riskEventList { get; set; }
        public int? typeId { get; set; }
        public int? groupId { get; set; }
        public int? reId { get; set; }
        public bool? canmodify { get; set; }
    }
}