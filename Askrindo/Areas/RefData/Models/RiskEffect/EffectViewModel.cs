using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.RiskEffect
{
    public class EffectViewModel
    {
        public Effect Effect { get; set; }
        public IEnumerable<Effect> Effects { get; set; }
        public EffectType EffectType { get; set; }
    }
}