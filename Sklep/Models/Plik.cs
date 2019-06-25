using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sklep.Models
{
    public class Plik
    {
        [Key]
        public int ID { get; set; }
        [NotMapped]
        public HttpPostedFileBase Zawartosc { get; set; }
    }
}