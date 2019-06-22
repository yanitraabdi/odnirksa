using Askrindo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Askrindo.Areas.RCSA.Models
{
    public class RCSARiskInputModel
    {
        public string __RequestVerificationToken { get; set; }
        public string prob_type { get; set; }
        public double tb_avail { get; set; }
        public double tb_ap1 { get; set; }
        public double tb_ap2 { get; set; }
        public double tb_ap3 { get; set; }
        public double tb_diff { get; set; }
        public int sb_freq { get; set; }
        public string impact_type { get; set; }
        public double moneyDirect { get; set; }
        public int impactTypeId { get; set; }
        public int impactLevelId { get; set; }
        public double moneyIndirect { get; set; }
        public string attachName { get; set; }
        public string notes { get; set; }
        public int risk_event { get; set; }
        public string risk_event_note { get; set; }
        public string risk_date { get; set; }
        public int[]risk_causes { get; set; }

        public string[]risk_cause_notes { get; set; }
        public int[] risk_effects { get; set; }
        public string[] risk_effect_notes { get; set; }

    }
}