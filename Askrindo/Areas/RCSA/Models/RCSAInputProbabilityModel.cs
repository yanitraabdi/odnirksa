using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Askrindo.Areas.RCSA.Models
{
    public class RCSAInputImpactModel
    {
        public string impact_type { get; set; }
        public double moneyDirect { get; set; }
        public int impactTypeId { get; set; }
        public int impactLevelId { get; set; }
        public double moneyIndirect { get; set; }
    }
}