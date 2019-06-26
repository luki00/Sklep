using Sklep.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.Repos
{
    public interface IArtykulyRepo
    {
        ArtykulyListViewModel GetArtykulyList();
        ArtykulyListViewModel GetArtykulyDetails(int id);
        bool SetArtykulyItem(int id, string Name, string Describtion, int Quantity, Sklep.Models.jednostka Unit, HttpPostedFileBase Photo);
        bool DeleteArtykulyItem(int id);
        bool EditArtykulyItem(int id, string Name, string Describtion, int Quantity, Sklep.Models.jednostka Unit, HttpPostedFileBase Photo);
    }
}