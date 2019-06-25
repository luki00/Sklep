using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sklep.Models
{
    public class Transakcja
    {
        [Key]
        public int ID_transakcji { get; set; }
        public int Ilosc { get; set; }
        
        public DateTime Utworzono { get; set; }
        public Transakcja() {
            Utworzono = DateTime.Now;
        }
        public bool Potwierdzono { get; set; }
        [Required]
        public int ArtykulID { get; set; }
        [ForeignKey("ArtykulID")]
        public Artykul Artykul { get; set; } 
    }
}