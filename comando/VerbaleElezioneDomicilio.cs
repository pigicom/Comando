//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace comando
{
    using System;
    using System.Collections.Generic;
    
    public partial class VerbaleElezioneDomicilio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VerbaleElezioneDomicilio()
        {
            this.DocumentoCollegato = new HashSet<DocumentoCollegato>();
            this.DocumentoWord = new HashSet<DocumentoWord>();
        }
    
        public long Id { get; set; }
        public string Titolo { get; set; }
        public string Giorno { get; set; }
        public string Ora { get; set; }
        public string PenitGrado { get; set; }
        public string PenitNome { get; set; }
        public string PenitCognome { get; set; }
        public Nullable<System.DateTime> DataTrasgressione { get; set; }
        public Nullable<System.DateTime> DataVerbale { get; set; }
        public string IdentificatoMediante { get; set; }
        public string LingueParlate { get; set; }
        public string MiChiamo { get; set; }
        public string SonoNato { get; set; }
        public Nullable<System.DateTime> DataNascita { get; set; }
        public string ResidenteA { get; set; }
        public string InVia { get; set; }
        public string AvvocatoNominato { get; set; }
        public string AvvocatoStudioVia { get; set; }
        public string AvvocatoStudioTel { get; set; }
        public string AvvocatoStudioFax { get; set; }
        public string AvvocatoStudioCell { get; set; }
        public string AvvocatoStudioEmail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentoCollegato> DocumentoCollegato { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentoWord> DocumentoWord { get; set; }
    }
}
