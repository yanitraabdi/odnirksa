using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Helpers;
using Askrindo.Models;

namespace Askrindo.Areas.KRI.Models
{
    public class InvestViewModel
    {
        public List<KRIInvest> KRIInvests { get; set; }
        public KRIInvest KRIInvest { get; set; }
        public UserData User { get; set; }
        public KRIInvestData KRIInvestData { get; set; }
    }

    public class InvestStrategicResponseViewModel
    {
        public KRIInvestData KRIInvestData { get; set; }

        public SRInvest SRInvest { get; set; }
        public List<SRInvest> SRInvests { get; set; }

        public SRInvestProgress SRInvestProgress { get; set; }
        public List<SRInvestProgress> SRInvestProgresses { get; set; }

        public SRIProgressAction SRIProgressAction { get; set; }
        public List<SRIProgressAction> SRIProgressActions { get; set; }

        public UserData User { get; set; }
    }
}