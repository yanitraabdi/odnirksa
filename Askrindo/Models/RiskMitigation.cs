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
    
    public partial class RiskMitigation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RiskMitigation()
        {
            this.MitigationAttachments = new HashSet<MitigationAttachment>();
            this.MitigationApprovals = new HashSet<MitigationApproval>();
            this.MitigationUnits = new HashSet<MitigationUnit>();
            this.MitigationsActions = new HashSet<MitigationsAction>();
        }
    
        public int MitigationId { get; set; }
        public int RiskId { get; set; }
        public string MitigationCode { get; set; }
        public string MitigationName { get; set; }
        public System.DateTime InputDate { get; set; }
        public System.DateTime MitigationDate { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<int> MitigationCatId { get; set; }
        public Nullable<int> MitigationTypeId { get; set; }
        public Nullable<int> ProbLevelId { get; set; }
        public Nullable<int> ImpactLevelId { get; set; }
        public Nullable<int> RiskLevel { get; set; }
        public Nullable<System.DateTime> LimitDate { get; set; }
        public Nullable<System.DateTime> ApprovalDate { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public string JobTitle { get; set; }
        public int OrgPos { get; set; }
        public Nullable<int> DeptId { get; set; }
        public Nullable<int> SubDeptId { get; set; }
        public Nullable<int> DivisionId { get; set; }
        public Nullable<int> SubDivId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> SubBranchId { get; set; }
        public Nullable<int> BizUnitId { get; set; }
        public bool IsReadOnly { get; set; }
    
        public virtual ProbLevel ProbLevel { get; set; }
        public virtual ImpactLevel ImpactLevel { get; set; }
        public virtual MitigationCat MitigationCat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MitigationAttachment> MitigationAttachments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MitigationApproval> MitigationApprovals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MitigationUnit> MitigationUnits { get; set; }
        public virtual Risk Risk { get; set; }
        public virtual MitigationType MitigationType { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MitigationsAction> MitigationsActions { get; set; }
    }
}