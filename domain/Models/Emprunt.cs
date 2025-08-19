using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain.Models
{
    public class Emprunt
    {
        [Key]
        public int IDEmprunt { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime DateRetour { get; set; }

        // Foreign Keys
        public int FKAdherent { get; set; }
        [ForeignKey("FKAdherent")]
        public Adherent Adherent { get; set; }

        public int FKLivre { get; set; }
        [ForeignKey("FKLivre")]
        public Livre Livre { get; set; }
    }
}
