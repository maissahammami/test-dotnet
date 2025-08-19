using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain.Models
{
    public class Livre
    {
        [Key]
        public int IDLivre { get; set; }
        public string Titre { get; set; }
        public string ISBN { get; set; }
        public string Auteur { get; set; }
        public DateTime DateEdition { get; set; }
        public string Categorie { get; set; }
        public bool Disponibilite { get; set; }

        // Navigation properties
        public ICollection<Emprunt> Emprunts { get; set; }
        public ICollection<Exemplaire> Exemplaires { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }

}
