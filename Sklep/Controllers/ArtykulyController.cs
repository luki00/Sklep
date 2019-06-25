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

namespace Sklep.Controllers
{
    public class ArtykulyController : Controller
    {
        private Context db = new Context();

        // GET: Artykuly
        public ActionResult Index()
        {
            return View(db.Artykul.ToList());
        }

        // GET: Artykuly/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artykul artykul = db.Artykul.Find(id);
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
        public ActionResult Create([Bind(Include = "Id_towaru,Nazwa,Ilosc,Jednostka,Opis,Zdjecie")] Artykul artykul)
        {
            
            if (ModelState.IsValid)
            {
                /*
                if (artykul.Plik.FileName == null)
                {
                    throw new HttpException(404, "error");
                } else { ViewBag.Error = artykul.Plik.FileName;}
                */

                db.Artykul.Add(artykul);
                db.SaveChanges();
                return RedirectToAction("Index");

                /*
            



                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Pliki/"), fileName);
                        file.SaveAs(path);
                        return View(artykul);
                    }
                }
                */
            }

            return View(artykul);
        }

        // GET: Artykuly/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artykul artykul = db.Artykul.Find(id);
            if (artykul == null)
            {
                return HttpNotFound();
            }
            return View(artykul);
        }

        // POST: Artykuly/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_towaru,Nazwa,Ilosc,Jednostka,Opis,Zdjecie")] Artykul artykul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artykul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artykul);
        }

        // GET: Artykuly/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artykul artykul = db.Artykul.Find(id);
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
            Artykul artykul = db.Artykul.Find(id);
            db.Artykul.Remove(artykul);
            db.SaveChanges();
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
