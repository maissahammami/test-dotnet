using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using domain.Models; 
namespace data.Context1
{
    public class BibliothequeContext : DbContext
    {
        public BibliothequeContext(DbContextOptions<BibliothequeContext> options)
            : base(options) { }

        public DbSet<Livre> Livres { get; set; }
        public DbSet<Emprunt> Emprunts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Inscrit> Inscrits { get; set; }
        public DbSet<Adherent> Adherents { get; set; }
        public DbSet<Exemplaire> Exemplaires { get; set; }
    }


}
