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
    
    public partial class gestionCompte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gestionCompte()
        {
            this.Donnees = new HashSet<Donnees>();
        }
    
        public int Id { get; set; }
        public string identifiant { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string IP { get; set; }
        public Nullable<int> user_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donnees> Donnees { get; set; }
        public virtual user user { get; set; }
    }
}
