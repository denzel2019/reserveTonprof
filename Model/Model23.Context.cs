﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Abonnement> Abonnement { get; set; }
        public virtual DbSet<Donnees> Donnees { get; set; }
        public virtual DbSet<gestionCompte> gestionCompte { get; set; }
        public virtual DbSet<jours> jours { get; set; }
        public virtual DbSet<matiere> matiere { get; set; }
        public virtual DbSet<message> message { get; set; }
        public virtual DbSet<reservation> reservation { get; set; }
        public virtual DbSet<statutRdv> statutRdv { get; set; }
        public virtual DbSet<user> user { get; set; }
    }
}