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
        bool DeleteArtykulyItem(int id);
        bool SetArtykulyItem(ArtykulyListViewModel artykul);
        bool EditArtykulyItem(ArtykulyListViewModel artykul);

        //bool SetArtykulyItem(int id, string Name, string Describtion, int Quantity, Sklep.Models.jednostka Unit, HttpPostedFileBase Photo);
        //bool EditArtykulyItem(int id, string Name, string Describtion, int Quantity, Sklep.Models.jednostka Unit, HttpPostedFileBase Photo);
    }
}