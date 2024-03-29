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
    
    public partial class LossEvent
    {
        public int LossEventId { get; set; }
        public string LossEventCode { get; set; }
        public Nullable<System.DateTime> InputDate { get; set; }
        public string KlasifikasiId { get; set; }
        public string LossEventName { get; set; }
        public Nullable<System.DateTime> LossDate { get; set; }
        public string LossCause { get; set; }
        public Nullable<decimal> Assets { get; set; }
        public string Location { get; set; }
        public string PihakTerlibat { get; set; }
        public string ImpactNonFinancial { get; set; }
        public Nullable<decimal> ImpactFinancial { get; set; }
        public string Action { get; set; }
        public string Keterangan { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public Nullable<System.Guid> ApproveId { get; set; }
        public Nullable<int> DeptId { get; set; }
        public Nullable<int> SubDeptId { get; set; }
        public Nullable<int> DivisionId { get; set; }
        public Nullable<int> SubDivId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> SubBranchIs { get; set; }
        public Nullable<int> BizUnitId { get; set; }
        public string JobTitle { get; set; }
        public string LossOwner { get; set; }
        public string ProductType { get; set; }
        public string Tertanggung { get; set; }
        public string DebiturTertanggung { get; set; }
        public string Obligee { get; set; }
        public string Principal { get; set; }
        public string NilaiJaminan { get; set; }
        public string Collateral { get; set; }
        public string Project { get; set; }
        public string CasePosition { get; set; }
        public string Affiliate { get; set; }
        public string CaseType { get; set; }
        public string Coverage { get; set; }
        public string Units { get; set; }
        public string LossType { get; set; }
    }
}
