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
    
    public partial class KRIRiskEffectLine
    {
        public int Id { get; set; }
        public string CustomEffect { get; set; }
        public string Note { get; set; }
        public int EffectEffectId { get; set; }
        public int EffectGroupEffectGroupId { get; set; }
        public int EffectTypeEffectTypeId { get; set; }
        public int KRIRiskRiskId { get; set; }
    
        public virtual Effect Effect { get; set; }
        public virtual EffectGroup EffectGroup { get; set; }
        public virtual EffectType EffectType { get; set; }
        public virtual KRIRisk KRIRisk { get; set; }
    }
}