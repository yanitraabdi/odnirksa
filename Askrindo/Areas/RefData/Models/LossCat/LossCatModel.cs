using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models
{
    public class LossCatModel
    {
        public KlasifikasiKerugian lossCat { get; set; }
        public IEnumerable<KlasifikasiKerugian> lossCatList { get; set; }
        public int? typeId { get; set; }
        public int? groupId { get; set; }
        public int? reId { get; set; }
    }
}