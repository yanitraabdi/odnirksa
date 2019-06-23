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
    
    public partial class KRIMitigationApproval
    {
        public int Id { get; set; }
        public string OrgPos { get; set; }
        public string OrgPosId { get; set; }
        public string OrgName { get; set; }
        public string JobTitle { get; set; }
        public string ApprovalDate { get; set; }
        public string LimitDate { get; set; }
        public string LastApproval { get; set; }
        public string IsReadOnly { get; set; }
        public int KRIRiskMitigationId { get; set; }
        public System.Guid UserInfoUserId { get; set; }
    
        public virtual KRIRiskMitigation KRIRiskMitigation { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}