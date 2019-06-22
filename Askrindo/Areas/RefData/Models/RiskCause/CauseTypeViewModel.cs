﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.RiskCause
{
    public class CauseTypeViewModel
    {
        public CauseGroup CauseGroup { get; set; }
        public CauseType CauseType { get; set; }
        public IEnumerable<CauseType> CauseTypes { get; set; }
    }
}