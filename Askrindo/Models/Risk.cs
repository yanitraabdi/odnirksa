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
    
    public partial class Risk
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Risk()
        {
            this.IsMultiCE = false;
            this.RiskAttachments = new HashSet<RiskAttachment>();
            this.RiskCauseLines = new HashSet<RiskCauseLine>();
            this.RiskEffectLines = new HashSet<RiskEffectLine>();
            this.RiskMitigations = new HashSet<RiskMitigation>();
            this.RiskApprovals = new HashSet<RiskApproval>();
        }
    
        public int RiskId { get; set; }
        public System.Guid UserId { get; set; }
        public string RiskCode { get; set; }
        public string RiskName { get; set; }
        public System.DateTime RiskDate { get; set; }
        public int OrgPos { get; set; }
        public Nullable<int> DeptId { get; set; }
        public Nullable<int> DivisionId { get; set; }
        public Nullable<int> SubDivId { get; set; }
        public Nullable<int> SubBranchId { get; set; }
        public Nullable<int> BizUnitId { get; set; }
        public Nullable<int> CauseGroupId { get; set; }
        public Nullable<int> CauseTypeId { get; set; }
        public Nullable<int> CauseId { get; set; }
        public Nullable<int> EffectGroupId { get; set; }
        public Nullable<int> EffectTypeId { get; set; }
        public Nullable<int> EffectId { get; set; }
        public Nullable<int> RiskGroupId { get; set; }
        public string JobTitle { get; set; }
        public Nullable<decimal> ProbValue { get; set; }
        public Nullable<int> ProbLevelId { get; set; }
        public Nullable<int> ImpactLevelId { get; set; }
        public Nullable<decimal> ImpactMoney { get; set; }
        public Nullable<int> RiskLevel { get; set; }
        public Nullable<System.DateTime> ApprovalDate { get; set; }
        public Nullable<System.DateTime> CloseDate { get; set; }
        public bool IsReadOnly { get; set; }
        public Nullable<int> RiskEventId { get; set; }
        public Nullable<int> bisnisid { get; set; }
        public Nullable<int> aktifitasid { get; set; }
        public Nullable<System.DateTime> FRiskDate { get; set; }
        public Nullable<bool> IsMultiCE { get; set; }
        public Nullable<bool> IsProbSet { get; set; }
        public Nullable<bool> IsImpactSet { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> RiskCatId { get; set; }
        public Nullable<int> RiskTypeId { get; set; }
        public Nullable<int> SubDeptId { get; set; }
    
        public virtual CauseGroup CauseGroup { get; set; }
        public virtual Cause Caus { get; set; }
        public virtual EffectGroup EffectGroup { get; set; }
        public virtual Effect Effect { get; set; }
        public virtual RiskGroup RiskGroup { get; set; }
        public virtual Dept Dept { get; set; }
        public virtual ProbLevel ProbLevel { get; set; }
        public virtual ImpactLevel ImpactLevel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RiskAttachment> RiskAttachments { get; set; }
        public virtual SubDiv SubDiv { get; set; }
        public virtual SubBranch SubBranch { get; set; }
        public virtual BizUnit BizUnit { get; set; }
        public virtual RiskEvent RiskEvent { get; set; }
        public virtual bisni bisni { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RiskCauseLine> RiskCauseLines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RiskEffectLine> RiskEffectLines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RiskMitigation> RiskMitigations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RiskApproval> RiskApprovals { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public virtual Division Division { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual RiskCat RiskCat { get; set; }
        public virtual RiskType RiskType { get; set; }
        public virtual SubDept SubDept { get; set; }
    }
}
