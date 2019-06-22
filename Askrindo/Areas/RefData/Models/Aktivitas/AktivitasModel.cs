using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Askrindo.Models;

namespace Askrindo.Areas.RefData.Models.Aktivitas
{
    public class AktivitasModel
    {
        public bisnis_aktifitas aktivitas { get; set; }
        public IEnumerable<bisnis_aktifitas> listAktivitas { get; set; }
        public bisni bisnis { get; set; }
        public int bisnisid { get; set; }
    }
}