//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Askrindo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SRNonInvest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SRNonInvest()
        {
            this.SRNonInvestProgresses = new HashSet<SRNonInvestProgress>();
        }
    
        public int Id { get; set; }
        public int KRIDataId { get; set; }
        public string CauseAnalysis { get; set; }
        public string StrategicResponse { get; set; }
        public System.DateTime SubmitDate { get; set; }
    
        public virtual KRINonInvestData KRINonInvestData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SRNonInvestProgress> SRNonInvestProgresses { get; set; }
    }
}
