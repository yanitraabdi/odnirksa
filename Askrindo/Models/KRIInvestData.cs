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
    
    public partial class KRIInvestData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KRIInvestData()
        {
            this.SRInvests = new HashSet<SRInvest>();
        }
    
        public int Id { get; set; }
        public decimal Value { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string Code { get; set; }
        public string Grade { get; set; }
        public System.Guid UserId { get; set; }
        public int KRIInvestId { get; set; }
        public decimal Target { get; set; }
        public System.DateTime TransactionDate { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
        public virtual KRIInvest KRIInvest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SRInvest> SRInvests { get; set; }
    }
}
