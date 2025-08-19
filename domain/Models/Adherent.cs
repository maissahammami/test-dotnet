using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain.Models
{
    public class Adherent
    {
        [Key]
        public int IDInscrit { get; set; }
        public DateTime DateDInscription { get; set; }

        // Foreign Key
        public int FKInscrit { get; set; }
        [ForeignKey("FKInscrit")]
        public Inscrit Inscrit { get; set; }
    }
}
