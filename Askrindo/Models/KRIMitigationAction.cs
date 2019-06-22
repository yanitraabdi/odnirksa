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
    
    public partial class KRIMitigationAction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KRIMitigationAction()
        {
            this.KRIActionApprovals = new HashSet<KRIActionApproval>();
            this.KRIActionProgresses = new HashSet<KRIActionProgress>();
        }
    
        public int Id { get; set; }
        public string PIC { get; set; }
        public string ActionCode { get; set; }
        public string ActionName { get; set; }
        public string ActionDate { get; set; }
        public string Require { get; set; }
        public string RKAPF { get; set; }
        public string RiskLevel { get; set; }
        public string LimitDate { get; set; }
        public string IsReadOnly { get; set; }
        public string TotalProgress { get; set; }
        public string Biaya { get; set; }
        public string PIC2 { get; set; }
        public int KRIRiskMitigationId { get; set; }
    
        public virtual KRIRiskMitigation KRIRiskMitigation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KRIActionApproval> KRIActionApprovals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KRIActionProgress> KRIActionProgresses { get; set; }
    }
}
