using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.NonMoneyImpact
{
    public class ImpactDetailViewModel
    {
        public ImpactDetail ImpactDetail { get; set; }
        public IEnumerable<ImpactDetail> ImpactDetails { get; set; }
        public ImpactType ImpactType { get; set; }
    }
}