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
    
    public partial class KRIMitigationAttachment
    {
        public int Id { get; set; }
        public string AttachName { get; set; }
        public string Notes { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
        public int ContentLength { get; set; }
        public byte[] Data { get; set; }
        public int KRIRiskMitigationId { get; set; }
    
        public virtual KRIRiskMitigation KRIRiskMitigation { get; set; }
    }
}
