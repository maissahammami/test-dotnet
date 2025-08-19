using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain.Models
{
    public class Inscrit
    {
        [Key]
        public int IDInscrit { get; set; }
        public string CodeDInscription { get; set; }
        public DateTime FaitDInscription { get; set; }
        public DateTime DateInscription { get; set; }

        // Foreign Key
        public int FKPersonne { get; set; }
        [ForeignKey("FKPersonne")]
        public Personne Personne { get; set; }

        // Navigation property
        public Adherent Adherent { get; set; }
    }
}
