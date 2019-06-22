using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.RiskEffect
{
    public class EffectTypeViewModel
    {
        public EffectGroup EffectGroup { get; set; }
        public EffectType EffectType { get; set; }
        public IEnumerable<EffectType> EffectTypes { get; set; }
    }
}