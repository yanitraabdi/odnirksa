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
}