using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sklep.Database;
using Sklep.Models;
using Sklep.Repos;
using Sklep.ViewModels;

namespace Sklep.Controllers
{
    public class ArtykulyController : Controller
    {
        private Context db = new Context();
        IArtykulyRepo artykulyRepo;

        public ArtykulyController()
        {
            artykulyRepo = new ArtykulyRepo();
        }

        // GET: Artykuly
        public ActionResult Index()
        {
            return View(artykulyRepo.GetArtykulyList());
        }

        // GET: Artykuly/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtykulyListViewModel artykul = artykulyRepo.GetArtykulyDetails(id);
            if (artykul == null)
            {
                return HttpNotFound();
            }
            


            return View(artykul);
        }

        // GET: Artykuly/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artykuly/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_towaru,Nazwa,Ilosc,Jednostka,Opis,Zdjecie,Plik")] Artykul artykul)
        {
            
            if (ModelState.IsValid)
            {

                artykulyRepo.SetArtykulyItem(artykul.Id_towaru,artykul.Nazwa,artykul.Opis,artykul.Ilosc,artykul.Jednostka,artykul.Plik);

                return RedirectToAction("Index");


                /*
                 [Bind(Include = "Id,Name,Describtion,Quantity,Unit,Photo")] ArtykulyGetViewModel artykul
                 
                 artykulyRepo.SetArtykulyItem(artykul.Id,artykul.Name,artykul.Describtion,artykul.Quantity,artykul.Unit,artykul.Photo);   
            
            if (artykul.Plik != null && artykul.Plik.ContentLength > 0)
               {
                   var fileName = Path.GetFileName(artykul.Plik.FileName);
                   var path = Path.Combine(Server.MapPath("~/Pliki/"), fileName);
                   artykul.Plik.SaveAs(path);
               }
               */

            }

            return View(artykul);
        }

        // GET: Artykuly/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtykulyListViewModel artykul = artykulyRepo.GetArtykulyDetails(id);

            if (artykul == null)
            {
                return HttpNotFound();
            }
            return View(artykulyRepo.GetArtykulyDetails(id));
        }

        // POST: Artykuly/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArtykulyListViewModel artykul)
        {
            if (ModelState.IsValid)
            {

                artykulyRepo.EditArtykulyItem(artykul.Details.Id, artykul.Details.Name, artykul.Details.Describtion, artykul.Details.Quantity, artykul.Details.Unit, artykul.Details.File);
                return RedirectToAction("Index");
            }
            return View(artykul);
        }

        // GET: Artykuly/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtykulyListViewModel artykul = artykulyRepo.GetArtykulyDetails(id);
            if (artykul == null)
            {
                return HttpNotFound();
            }
            return View(artykul);
        }

        // POST: Artykuly/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            artykulyRepo.DeleteArtykulyItem(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
