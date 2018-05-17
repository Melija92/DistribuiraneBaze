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
    public class AutorstvoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Autorstvo
        public ActionResult Index()
        {
            var autorstvo = db.Autorstvo.Include(a => a.Autor).Include(a => a.Knjiga);
            return View(autorstvo.ToList());
        }

        // GET: Autorstvo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autorstvo autorstvo = db.Autorstvo.Find(id);
            if (autorstvo == null)
            {
                return HttpNotFound();
            }
            return View(autorstvo);
        }

        // GET: Autorstvo/Create
        public ActionResult Create()
        {
            ViewBag.AutorID = new SelectList(db.Autor, "AutorID", "OIB");
            ViewBag.KnjigaID = new SelectList(db.Knjiga, "KnjigaID", "Naziv");
            return View();
        }

        // POST: Autorstvo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AutorstvoID,KnjigaID,AutorID,UdioAutorstva")] Autorstvo autorstvo)
        {
            if (ModelState.IsValid)
            {
                db.Autorstvo.Add(autorstvo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorID = new SelectList(db.Autor, "AutorID", "OIB", autorstvo.AutorID);
            ViewBag.KnjigaID = new SelectList(db.Knjiga, "KnjigaID", "Naziv", autorstvo.KnjigaID);
            return View(autorstvo);
        }

        // GET: Autorstvo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autorstvo autorstvo = db.Autorstvo.Find(id);
            if (autorstvo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorID = new SelectList(db.Autor, "AutorID", "OIB", autorstvo.AutorID);
            ViewBag.KnjigaID = new SelectList(db.Knjiga, "KnjigaID", "Naziv", autorstvo.KnjigaID);
            return View(autorstvo);
        }

        // POST: Autorstvo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutorstvoID,KnjigaID,AutorID,UdioAutorstva")] Autorstvo autorstvo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autorstvo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorID = new SelectList(db.Autor, "AutorID", "OIB", autorstvo.AutorID);
            ViewBag.KnjigaID = new SelectList(db.Knjiga, "KnjigaID", "Naziv", autorstvo.KnjigaID);
            return View(autorstvo);
        }

        // GET: Autorstvo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autorstvo autorstvo = db.Autorstvo.Find(id);
            if (autorstvo == null)
            {
                return HttpNotFound();
            }
            return View(autorstvo);
        }

        // POST: Autorstvo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autorstvo autorstvo = db.Autorstvo.Find(id);
            db.Autorstvo.Remove(autorstvo);
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
