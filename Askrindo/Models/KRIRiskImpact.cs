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
    
    public partial class KRIRiskImpact
    {
        public int Id { get; set; }
        public string MoneyDirect { get; set; }
        public string MoneyIndirect { get; set; }
        public int ImpactLevelImpactLevelId { get; set; }
        public Nullable<int> KRIRiskRiskId { get; set; }
    
        public virtual ImpactLevel ImpactLevel { get; set; }
        public virtual KRIRisk KRIRisk { get; set; }
    }
}
