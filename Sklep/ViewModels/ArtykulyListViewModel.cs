using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sklep.ViewModels
{
    public class ArtykulyListViewModel
    {
        public List<ArtykulyListItemViewModel> List { get; set; }
        public ArtykulyDetailsViewModel Details { get; set; }
        public ArtykulyDetailsViewModel Get { get; set; }

    }

    public class ArtykulyListItemViewModel
    {
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Zdjecie")]
        public byte[] Photo { get; set; }
        public int Id { get; set; }
    }

    public class ArtykulyDetailsViewModel
    {
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Zdjecie")]
        public byte[] Photo { get; set; }
        [Display(Name = "Zdjecie")]
        public HttpPostedFileBase File { get; set; }
        [Display(Name = "Opis")]
        public string Describtion { get; set; }
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }
        [Display(Name = "Jednostka")]
        public Sklep.Models.jednostka Unit { get; set; }
        public int Id { get; set; }
    }


    public class ArtykulyViewModel
    {
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Zdjecie")]
        public HttpPostedFileBase Photo { get; set; }
        [Display(Name = "Opis")]
        public string Describtion { get; set; }
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }
        [Display(Name = "Jednostka")]
        public Sklep.Models.jednostka Unit { get; set; }
        public int Id { get; set; }
    }

}