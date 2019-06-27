using Sklep.ViewModels;
using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sklep.Database;
using Sklep.Models;

namespace Sklep.Repos
{
    public class TransakcjeRepo : ITransakcjeRepo
    {
        private Context db = new Context();

        public TransakcjeListViewModel GetTransakcjeList()
        {

            return new TransakcjeListViewModel
            {

                List = db.Transakcja.Select(e => new TransakcjeListItemViewModel
                {
                    Id = e.ID_transakcji,
                    Name = e.Artykul.Nazwa,
                    Quantity = e.Ilosc,
                    Accepted = e.Potwierdzono,
                    Created = e.Utworzono,
                    Unit = e.Artykul.Jednostka,
                    Photo = e.Artykul.Zdjecie

                }).ToList()


            };
        }

        public TransakcjeListViewModel GetTransakcjeDetails(int id)
        {

            return new TransakcjeListViewModel
            {
                Details = db.Transakcja.Where(r => r.ID_transakcji == id).Select(e => new TransakcjeListItemViewModel
                {
                    Id = e.ID_transakcji,
                    Name = e.Artykul.Nazwa,
                    Quantity = e.Ilosc,
                    Accepted = e.Potwierdzono,
                    Created = e.Utworzono,
                    Unit = e.Artykul.Jednostka,
                    Photo = e.Artykul.Zdjecie
                }).First()
            };
        }

        public bool SetTransakcje(int id, int Quantity)
        {
            var transakcja = new Transakcja()
            {
                Ilosc = Quantity,
                Utworzono = DateTime.Now,
                Potwierdzono = false,
                ArtykulID = id
            };
            db.Transakcja.Add(transakcja);
            db.SaveChanges();

            return true;
        }


        public TransakcjeListViewModel GetTransakcjeAccept(int id)
        {

            return new TransakcjeListViewModel
            {
                Details = db.Transakcja.Where(r => r.ID_transakcji == id).Select(e => new TransakcjeListItemViewModel
                {
                    Id = e.ID_transakcji,
                    Name = e.Artykul.Nazwa,
                    Quantity = e.Ilosc,
                    Accepted = e.Potwierdzono,
                    Unit = e.Artykul.Jednostka,
                }).First()
            };
        }

        public TransakcjeListViewModel GetTransakcje(int id)
        {

            return new TransakcjeListViewModel
            {
                Accept = db.Artykul.Where(r => r.Id_towaru == id).Select(e => new TransakcjeItemCreateViewModel
                {
                    Id = e.Id_towaru,
                    Name = e.Nazwa,
                    Max = e.Ilosc

                }).First()
            };
        }

        public bool SetTransakcjeAccept(int id)
        {
            Transakcja transakcja = db.Transakcja.Find(id);
            transakcja.Potwierdzono = true;
            db.SaveChanges();

            return true;
        }

        public bool DeleteTransakcje(int id)
        {
            Transakcja transakcja = db.Transakcja.Find(id);
            db.Transakcja.Remove(transakcja);
            db.SaveChanges();

            return true;
        }


    }
}