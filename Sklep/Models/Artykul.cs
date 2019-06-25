using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sklep.Models
{
    public class Artykul
    {
        [Key]
        public int Id_towaru { get; set; }
        [DisplayName("Nazwa towaru")]
        public string Nazwa { get; set; }
        [DisplayName("Ilosc towaru")]
        public int Ilosc { get; set; }
        public jednostka Jednostka { get; set; }
        [DisplayName("Opis towaru")]
        public string Opis { get; set; }
        [DisplayName("Zdjęcie")]
        public byte[] Zdjecie { get; set; }

        [NotMapped]
        public HttpPostedFileBase Plik { get; set;}
        public virtual ICollection<Transakcja> Transakcje { get; set; }
    }
    public enum jednostka { szt, kg, g }

}

