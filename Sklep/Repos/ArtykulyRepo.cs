﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using Sklep.Database;
using Sklep.Models;
using Sklep.ViewModels;

namespace Sklep.Repos
{

    public class ArtykulyRepo : IArtykulyRepo
    {
        private Context db = new Context();

        public ArtykulyListViewModel GetArtykulyList()
        {
            return new ArtykulyListViewModel {
                List = db.Artykul.Select(e => new ArtykulyListItemViewModel {
                    Id = e.Id_towaru,
                    Name = e.Nazwa,
                    Photo = e.Zdjecie
                }).ToList()
            };
        }



        public ArtykulyListViewModel GetArtykulyDetails(int id) {

            return new ArtykulyListViewModel { Details = db.Artykul.Where(r => r.Id_towaru == id).Select(e => new ArtykulyDetailsViewModel
            {
                Id = e.Id_towaru,
                Describtion = e.Opis,
                Name = e.Nazwa,
                Photo = e.Zdjecie,
                Quantity = e.Ilosc,
                Unit = e.Jednostka
            }).First() };
           
        }



        public bool SetArtykulyItem(int id, string Name, string Describtion, int Quantity, Sklep.Models.jednostka Unit, HttpPostedFileBase Photo)
        {
            try
            {
                Artykul art = new Artykul() {
                Id_towaru = id,
                Nazwa = Name,
                Ilosc = Quantity,
                Jednostka = Unit,
                Opis = Describtion
            };

            
                byte[] bytes;

            if (Photo != null && Photo.ContentLength > 0)
            {

                using (BinaryReader br = new BinaryReader(Photo.InputStream))
                {
                    bytes = br.ReadBytes(Photo.ContentLength);
                }
                art.Zdjecie = bytes;
            }

                db.Artykul.Add(art);
                db.SaveChanges();
            } catch {
                return false;
            }
           
            return true;
        }


        public bool EditArtykulyItem(int id, string Name, string Describtion, int Quantity, Sklep.Models.jednostka Unit, HttpPostedFileBase Photo)
        {
            bool a = false;
            byte[] bytes;

            
            Artykul art = db.Artykul.Find(id);
            art.Nazwa = Name;
            art.Ilosc = Quantity;
            art.Jednostka = Unit;
            art.Opis = Describtion;

            //throw new HttpException(404, "error");
            
            if (Photo != null && Photo.ContentLength > 0)
            {

                using (BinaryReader br = new BinaryReader(Photo.InputStream))
                {
                    bytes = br.ReadBytes(Photo.ContentLength);
                }
                art.Zdjecie = bytes;
            }
            else
            {
              //  a = true;
            }


            //db.Entry(art).State = EntityState.Modified;
            //if (a) { db.Entry(art).Property(x => x.Zdjecie).IsModified = false; }

            db.SaveChanges();
            return true;
        }




            public bool DeleteArtykulyItem(int id)
        {
            try {

                db.Artykul.Remove(db.Artykul.Find(id));
                db.SaveChanges();

            } catch {
                return false;
            }
            return true;
        }
    }
}