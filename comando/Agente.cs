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
    
    public partial class Agente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agente()
        {
            this.Verbale = new HashSet<Verbale>();
            this.Verbale1 = new HashSet<Verbale>();
            this.Verbale2 = new HashSet<Verbale>();
        }
    
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Grado { get; set; }
        public Nullable<bool> PoliziaGiudiziaria { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verbale> Verbale { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verbale> Verbale1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verbale> Verbale2 { get; set; }
    }
}
