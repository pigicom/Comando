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
    
    public partial class CategoriaVerbale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoriaVerbale()
        {
            this.Verbale = new HashSet<Verbale>();
        }
    
        public long ID { get; set; }
        public string Descrizione { get; set; }
        public Nullable<long> IDPadre { get; set; }
        public string Pagina { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verbale> Verbale { get; set; }
    }
}