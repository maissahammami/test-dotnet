using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain.Models
{
    public class Reservation
    {
        [Key]
        public int IDReservation { get; set; }  // clé primaire
        public string Statut { get; set; } = "En attente"; // garde au moins une colonne de données
        public string Commentaire { get; set; } = "";

        // Foreign Key vers Livre
        public int FKLivre { get; set; }
        [ForeignKey("FKLivre")]
        public Livre Livre { get; set; }



    }
}
