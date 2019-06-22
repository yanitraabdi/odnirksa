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
    
    public partial class ImpactDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImpactDetail()
        {
            this.RiskNonMoneyImpacts = new HashSet<RiskNonMoneyImpact>();
            this.KRIRiskNonMoneyImpacts = new HashSet<KRIRiskNonMoneyImpact>();
        }
    
        public int ImpactDetailId { get; set; }
        public int ImpactTypeId { get; set; }
        public int ImpactLevelId { get; set; }
        public string ImpactDetailName { get; set; }
    
        public virtual ImpactLevel ImpactLevel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RiskNonMoneyImpact> RiskNonMoneyImpacts { get; set; }
        public virtual ImpactType ImpactType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KRIRiskNonMoneyImpact> KRIRiskNonMoneyImpacts { get; set; }
    }
}
