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
    
    public partial class ImpactType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImpactType()
        {
            this.ImpactDetails = new HashSet<ImpactDetail>();
        }
    
        public int ImpactTypeId { get; set; }
        public int ImpactCatId { get; set; }
        public string ImpactTypeName { get; set; }
        public string Notes { get; set; }
    
        public virtual ImpactCat ImpactCat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImpactDetail> ImpactDetails { get; set; }
    }
}