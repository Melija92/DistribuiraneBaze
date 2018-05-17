using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DistribuiraneBazeKnjiznica.Models;

namespace DistribuiraneBazeKnjiznica.Controllers
{
    public class NakladnikController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Nakladnik.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nakladnik nakladnik = db.Nakladnik.Find(id);
            if (nakladnik == null)
            {
                return HttpNotFound();
            }
            return View(nakladnik);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NakladnikID,OIB,Naziv,Adresa,Email,Telefon")] Nakladnik nakladnik)
        {
            if (ModelState.IsValid)
            {
                db.Nakladnik.Add(nakladnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nakladnik);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nakladnik nakladnik = db.Nakladnik.Find(id);
            if (nakladnik == null)
            {
                return HttpNotFound();
            }
            return View(nakladnik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NakladnikID,OIB,Naziv,Adresa,Email,Telefon")] Nakladnik nakladnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nakladnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nakladnik);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nakladnik nakladnik = db.Nakladnik.Find(id);
            if (nakladnik == null)
            {
                return HttpNotFound();
            }
            return View(nakladnik);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nakladnik nakladnik = db.Nakladnik.Find(id);
            db.Nakladnik.Remove(nakladnik);
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
