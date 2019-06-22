using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Askrindo.Areas.RCSA.Models
{
    public class RCSAInputAttachmentModel
    {
        public string prob_type { get; set; }
        public double tb_avail { get; set; }
        public double tb_ap1 { get; set; }
        public double tb_ap2 { get; set; }
        public double tb_ap3 { get; set; }
        public double tb_diff { get; set; }
        public int sb_freq{get;set;}
    }
}