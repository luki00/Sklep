using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep.ViewModels
{
    public class TransakcjeListViewModel
    {
        public List<TransakcjeListItemViewModel> List { get; set; }
        public TransakcjeListItemViewModel Details { get; set; }
        public TransakcjeItemCreateViewModel Accept { get; set; }
    }

    public class TransakcjeListItemViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Nazwa towaru")]
        public string Name { get; set; }
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }
        [Display(Name = "Potwierdzono")]
        public bool Accepted { get; set; }
        [Display(Name = "Jednostka")]
        public Models.jednostka Unit { get; set; }
        [Display(Name = "Zdjęcie")]
        public byte[] Photo { get; set; }
        [Display(Name = "Utworzono")]
        public DateTime Created { get; set; }
    }

    public class TransakcjeItemCreateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa towaru")]
        public string Name { get; set; }
        [Display(Name = "Ilosć")]
        public int Quantity { get; set; }
        [Display(Name = "Max")]
        public int Max { get; set; }

    }

}