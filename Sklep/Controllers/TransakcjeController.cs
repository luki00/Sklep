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
using Sklep.Repos;
using Sklep.ViewModels;

namespace Sklep.Controllers
{
    public class TransakcjeController : Controller
    {
        private Context db = new Context();

        ITransakcjeRepo transakcjeRepo;

        public TransakcjeController()
        {
            transakcjeRepo = new TransakcjeRepo();
        }


        // GET: Transakcje
        public ActionResult Index()
        {
            //var transkacja = db.Transakcja.Include(t => t.Artykul);
            return View(transakcjeRepo.GetTransakcjeList());
        }

        // GET: Transakcje/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransakcjeListViewModel transakcja = transakcjeRepo.GetTransakcjeDetails(id);


            if (transakcja == null)
            {
                return HttpNotFound();
            }
            return View(transakcja);
        }

        // GET: Transakcje/Create
        public ActionResult Create(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            TransakcjeListViewModel Artykul = transakcjeRepo.GetTransakcje(id);
            if (Artykul == null)
            {
                return HttpNotFound();
            }

            return View(Artykul);
        }

        // POST: Transakcje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransakcjeListViewModel transakcja)
        {
            if (ModelState.IsValid)
            {
                
                transakcjeRepo.SetTransakcje(transakcja.Accept.Id, transakcja.Accept.Quantity);
                return RedirectToAction("Index");
            }
            return View(transakcja);
        }

        // GET: Transakcje/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransakcjeListViewModel transakcja = transakcjeRepo.GetTransakcjeAccept(id);
            if (transakcja == null)
            {
                return HttpNotFound();
            }
            return View(transakcja);
        }

        // POST: Transakcje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransakcjeListItemViewModel transakcja)
        {
            if (ModelState.IsValid)
            {
                transakcjeRepo.SetTransakcjeAccept(transakcja.Id);
                return RedirectToAction("Index");
            }
            return View(transakcja);
        }

        // GET: Transakcje/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransakcjeListViewModel transakcja = transakcjeRepo.GetTransakcjeDetails(id);
            if (transakcja == null)
            {
                return HttpNotFound();
            }

            if (transakcja.Details.Accepted)
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
            transakcjeRepo.DeleteTransakcje(id);
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
