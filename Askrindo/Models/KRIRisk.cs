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
    
    public partial class KRIRisk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KRIRisk()
        {
            this.KRIRiskCauseLines = new HashSet<KRIRiskCauseLine>();
            this.KRIRiskEffectLines = new HashSet<KRIRiskEffectLine>();
            this.KRIRiskApprovals = new HashSet<KRIRiskApproval>();
            this.KRIRiskAttachments = new HashSet<KRIRiskAttachment>();
            this.KRIRiskProbs = new HashSet<KRIRiskProb>();
            this.KRIRiskImpacts = new HashSet<KRIRiskImpact>();
            this.KRIRiskNonMoneyImpacts = new HashSet<KRIRiskNonMoneyImpact>();
            this.KRIRiskMitigations = new HashSet<KRIRiskMitigation>();
        }
    
        public int RiskId { get; set; }
        public string RiskCode { get; set; }
        public string RiskName { get; set; }
        public System.DateTime RiskDate { get; set; }
        public int OrgPos { get; set; }
        public string OrgPosId { get; set; }
        public string JobTitle { get; set; }
        public Nullable<decimal> ProbValue { get; set; }
        public Nullable<decimal> ImpactMoney { get; set; }
        public Nullable<int> RiskLevel { get; set; }
        public Nullable<System.DateTime> ApprovalDate { get; set; }
        public Nullable<System.DateTime> CloseDate { get; set; }
        public bool IsReadOnly { get; set; }
        public Nullable<int> RiskEventId { get; set; }
        public Nullable<System.DateTime> FRiskDate { get; set; }
        public Nullable<bool> IsProbSet { get; set; }
        public Nullable<bool> IsImpactSet { get; set; }
        public int KRIDataId { get; set; }
        public System.Guid UserInfoUserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KRIRiskCauseLine> KRIRiskCauseLines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KRIRiskEffectLine> KRIRiskEffectLines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KRIRiskApproval> KRIRiskApprovals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KRIRiskAttachment> KRIRiskAttachments { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KRIRiskProb> KRIRiskProbs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KRIRiskImpact> KRIRiskImpacts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KRIRiskNonMoneyImpact> KRIRiskNonMoneyImpacts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KRIRiskMitigation> KRIRiskMitigations { get; set; }
    }
}
