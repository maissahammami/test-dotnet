using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain.Models
{
    public class Exemplaire
    {
        [Key]
        public int IDExemplaire { get; set; }
        public int NombreExemplaire { get; set; }

        // Foreign Key
        public int FKLivre { get; set; }
        [ForeignKey("FKLivre")]
        public Livre Livre { get; set; }
    }
}
