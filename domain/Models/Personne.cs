using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain.Models
{
    public class Personne
    {
        [Key]
        public int IDPersonne { get; set; }
        public string Cin { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }

        // Navigation property
        public ICollection<Inscrit> Inscrits { get; set; }
    }
}
