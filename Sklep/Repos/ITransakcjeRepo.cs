using Sklep.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep.Repos
{
    public interface ITransakcjeRepo
    {
        TransakcjeListViewModel GetTransakcjeList();
        TransakcjeListViewModel GetTransakcjeDetails(int id);
        bool SetTransakcje(int id, int Quantity);
        TransakcjeListViewModel GetTransakcjeAccept(int id);
        bool SetTransakcjeAccept(int id);
        TransakcjeListViewModel GetTransakcje(int id);
        bool DeleteTransakcje(int id);
    }
}