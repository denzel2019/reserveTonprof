//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace reserverProf.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.Abonnement = new HashSet<Abonnement>();
            this.gestionCompte = new HashSet<gestionCompte>();
            this.reservation = new HashSet<reservation>();
        }
    
        public int Id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public int telephone { get; set; }
        public string adresse { get; set; }
        public int codePostal { get; set; }
        public string ville { get; set; }
        public string email { get; set; }
        public string presentation { get; set; }
        public string photo { get; set; }
        public Nullable<int> matiere_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Abonnement> Abonnement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<gestionCompte> gestionCompte { get; set; }
        public virtual matiere matiere { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservation> reservation { get; set; }
    }
}
