//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Comando
{
    using System;
    using System.Collections.Generic;
    
    public partial class Utente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utente()
        {
            this.Verbale = new HashSet<Verbale>();
        }
    
        public long Id { get; set; }
        public string Login { get; set; }
        public string Pwd { get; set; }
        public Nullable<System.DateTime> UltimoAccesso { get; set; }
        public string Descrizione { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verbale> Verbale { get; set; }
    }
}
