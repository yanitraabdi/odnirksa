using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.RiskCause
{
    public class CauseViewModel
    {
        public Cause Cause { get; set; }
        public CauseType CauseType { get; set; }
        public IEnumerable<Cause> Causes { get; set; }
    }
}