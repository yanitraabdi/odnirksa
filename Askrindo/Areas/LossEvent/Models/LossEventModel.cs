using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Models;
using System.ComponentModel.DataAnnotations;

namespace Askrindo.Areas.LossEvent.Models
{
    public class LossEventModel
    {
        public Askrindo.Models.LossEvent lossEvent { get; set; }
        public IEnumerable<Askrindo.Models.LossEvent> lossEventList { get; set; }

        [Required(ErrorMessage = "Harus diisi")]
        [DataType(DataType.Date)]
        public DateTime inputDate { get; set; }

        [Required(ErrorMessage = "Harus diisi")]
        [DataType(DataType.Date)]
        public DateTime lossDate { get; set; }

        [Required(ErrorMessage = "Harus diisi")]
        [DataType(DataType.Date)]
        public DateTime tglAwal { get; set; }

        [Required(ErrorMessage = "Harus diisi")]
        [DataType(DataType.Date)]
        public DateTime tglAkhir { get; set; }

        public SelectList klasifikasi { get; set; }

        public SelectList cakupan { get; set; }

        public String code { get; set; }

        public KlasifikasiKerugian klas { get; set; }

        public IEnumerable<joinLossEvent> joinLossEvent { get; set; }

    }

    public class joinLossEvent
    {
        public Askrindo.Models.LossEvent lossEvent { get; set; }
        public KlasifikasiKerugian klas { get; set; }
        public SubDiv subdiv { get; set; }
        public Branch branch { get; set; }

        public int pos { get; set; }

        public DateTime tglAwal { get; set; }
        public DateTime tglAkhir { get; set; }
    }

}