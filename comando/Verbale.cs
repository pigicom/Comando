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
    
    public partial class Verbale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Verbale()
        {
            this.Violazione = new HashSet<Violazione>();
            this.Agente2 = new HashSet<Agente>();
        }
    
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Path { get; set; }
        public string Registro { get; set; }
        public Nullable<System.DateTime> DataOraApertura { get; set; }
        public Nullable<System.DateTime> DataOraChiusura { get; set; }
        public string Protocollo { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public string Indirizzo { get; set; }
        public Nullable<long> Violazione_Id { get; set; }
        public Nullable<long> Doc_Id { get; set; }
        public Nullable<long> Category_Id { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public Nullable<long> Agente2_Id { get; set; }
        public Nullable<long> Agente1_Id { get; set; }
        public Nullable<long> Avvocato_Id { get; set; }
        public Nullable<long> CategoriaVerbale_ID { get; set; }
        public Nullable<long> Trasgressore_Id { get; set; }
        public Nullable<long> Utente_Id { get; set; }
        public Nullable<long> Veicolo_Id { get; set; }
    
        public virtual Agente Agente { get; set; }
        public virtual Agente Agente1 { get; set; }
        public virtual CategoriaVerbale CategoriaVerbale { get; set; }
        public virtual Utente Utente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Violazione> Violazione { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agente> Agente2 { get; set; }
        public virtual Avvocato Avvocato { get; set; }
        public virtual Veicolo Veicolo { get; set; }
        public virtual Trasgressore Trasgressore { get; set; }
    }
}
