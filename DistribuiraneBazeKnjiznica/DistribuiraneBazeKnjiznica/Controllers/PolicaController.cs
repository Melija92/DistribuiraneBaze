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
    public class PolicaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Polica.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polica polica = db.Polica.Find(id);
            if (polica == null)
            {
                return HttpNotFound();
            }
            return View(polica);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PolicaID,Oznaka")] Polica polica)
        {
            if (ModelState.IsValid)
            {
                db.Polica.Add(polica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(polica);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polica polica = db.Polica.Find(id);
            if (polica == null)
            {
                return HttpNotFound();
            }
            return View(polica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PolicaID,Oznaka")] Polica polica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(polica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(polica);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Polica polica = db.Polica.Find(id);
            if (polica == null)
            {
                return HttpNotFound();
            }
            return View(polica);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Polica polica = db.Polica.Find(id);
            db.Polica.Remove(polica);
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
