using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sklep.Database;
using Sklep.Models;

namespace Sklep.Controllers
{
    public class TransakcjeController : Controller
    {
        private Context db = new Context();

        // GET: Transakcje
        public ActionResult Index()
        {
            var transkacja = db.Transkacja.Include(t => t.Artykul);
            return View(transkacja.ToList());
        }

        // GET: Transakcje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transakcja transakcja = db.Transkacja.Find(id);
            if (transakcja == null)
            {
                return HttpNotFound();
            }
            return View(transakcja);
        }

        // GET: Transakcje/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ID = id;
            Artykul Artykul = db.Artykul.Find(id);
            if (Artykul == null)
            {
                return HttpNotFound();
            }
            ViewBag.max = Artykul.Ilosc;
            ViewBag.ArtykulID = new SelectList(db.Artykul, "Id_towaru", "Nazwa");
            return View();
        }

        // POST: Transakcje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_transakcji,Ilosc")] Transakcja transakcja, int Id)
        {
            if (ModelState.IsValid)
            {
                var transakcja2 = new Transakcja();

                transakcja2.ID_transakcji = transakcja.ID_transakcji;
                transakcja2.Ilosc = transakcja.Ilosc;
                transakcja2.Utworzono = DateTime.Now;
                transakcja2.Potwierdzono = false;
                transakcja2.ArtykulID = Id;

                db.Transkacja.Add(transakcja2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtykulID = new SelectList(db.Artykul, "Id_towaru", "Nazwa", transakcja.ArtykulID);
            return View(transakcja);
        }

        // GET: Transakcje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transakcja transakcja = db.Transkacja.Find(id);
            if (transakcja == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtykulID = new SelectList(db.Artykul, "Id_towaru", "Nazwa", transakcja.ArtykulID);
            return View(transakcja);
        }

        // POST: Transakcje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_transakcji")] Transakcja transakcja)
        {
            if (ModelState.IsValid)
            {
                Transakcja transakcja2 = db.Transkacja.Find(transakcja.ID_transakcji);
                transakcja2.Potwierdzono = true;

                if (TryUpdateModel(transakcja2))
                {
                    try
                    {
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    catch (DataException)
                    {
                    }
                }

                //db.Entry(transakcja).State = transakcja2;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtykulID = new SelectList(db.Artykul, "Id_towaru", "Nazwa", transakcja.ArtykulID);
            return View(transakcja);
        }

        // GET: Transakcje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transakcja transakcja = db.Transkacja.Find(id);
            if (transakcja == null)
            {
                return HttpNotFound();
            }

            if (transakcja.Potwierdzono)
            {
                ViewBag.Potwierdzono = true;
                return View();
            } else
            {
                ViewBag.Potwierdzono = false;
                return View(transakcja);
            }


            
        }

        // POST: Transakcje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transakcja transakcja = db.Transkacja.Find(id);
            db.Transkacja.Remove(transakcja);
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
