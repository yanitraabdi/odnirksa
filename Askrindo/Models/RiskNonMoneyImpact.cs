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
    
    public partial class RiskNonMoneyImpact
    {
        public int Id { get; set; }
        public int RiskId { get; set; }
        public int ImpactDetailId { get; set; }
        public int ImpactTypeId { get; set; }
        public int ImpactLevelId { get; set; }
    
        public virtual ImpactLevel ImpactLevel { get; set; }
        public virtual ImpactDetail ImpactDetail { get; set; }
        public virtual ImpactType ImpactType { get; set; }
    }
}
