using Askrindo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Helpers;

namespace Askrindo.Areas.KRI.Models
{
    public class NonInvestViewModel
    {
        public List<KRINonInvest> KRINonInvests { get; set; }
        public KRINonInvest KRINonInvest { get; set; }
        public UserData User { get; set; }
        public KRINonInvestData KRINonInvestData { get; set; }
    }

    public class StrategicResponseViewModel
    {
        public KRINonInvestData KRINonInvestData { get; set; }

        public SRNonInvest SRNonInvest { get; set; }
        public List<SRNonInvest> SRNonInvests { get; set; }

        public SRNonInvestProgress SRNonInvestProgress { get; set; }
        public List<SRNonInvestProgress> SRNonInvestProgresses { get; set; }

        public SRNIProgressAction SRNIProgressAction { get; set; }
        public List<SRNIProgressAction> SRNIProgressActions { get; set; }

        public UserData User { get; set; }
    }
}