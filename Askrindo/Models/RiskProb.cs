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
    
    public partial class RiskProb
    {
        public int RiskId { get; set; }
        public int ProbOption { get; set; }
        public Nullable<int> Poisson1 { get; set; }
        public Nullable<int> Poisson2 { get; set; }
        public Nullable<int> Binom1 { get; set; }
        public Nullable<int> Binom2 { get; set; }
        public Nullable<decimal> Approx1 { get; set; }
        public Nullable<decimal> Approx2 { get; set; }
        public Nullable<decimal> Approx3 { get; set; }
        public Nullable<decimal> Compare { get; set; }
        public Nullable<int> FreqId { get; set; }
        public Nullable<decimal> ProbValue { get; set; }
        public Nullable<int> ProbLevelId { get; set; }
    
        public virtual ProbLevel ProbLevel { get; set; }
        public virtual Freq Freq { get; set; }
    }
}
