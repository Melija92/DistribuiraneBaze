using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DistribuiraneBazeKnjiznica.Models;
using PagedList;

namespace DistribuiraneBazeKnjiznica.Controllers
{
    public class AutorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Autor
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ImeSortParm = String.IsNullOrEmpty(sortOrder) ? "ime_desc" : "";
            ViewBag.PrezimeSortParm = sortOrder == "prezime_asc" ? "prezime_desc" : "prezime_asc";
            ViewBag.OIBSortParm =  sortOrder == "oib_asc" ? "oib_desc" : "oib_asc";
            
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;
            var autori = db.Autor.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
                autori = autori.Where(s => s.Ime.Contains(searchString) || s.Prezime.Contains(searchString));

            switch (sortOrder)
            {
                case "ime_desc":
                    autori = autori.OrderByDescending(s => s.Ime);
                    break;
                case "prezime_desc":
                    autori = autori.OrderByDescending(s => s.Prezime);
                    break;
                case "prezime_asc":
                    autori = autori.OrderBy(s => s.Prezime);
                    break;
                case "oib_desc":
                    autori = autori.OrderByDescending(s => s.OIB);
                    break;
                case "oib_asc":
                    autori = autori.OrderBy(s => s.OIB);
                    break;
                default:
                    autori = autori.OrderBy(s => s.Ime);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(autori.ToPagedList(pageNumber, pageSize));
        }

        // GET: Autor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AutorID,OIB,Ime,Prezime")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Autor.Add(autor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autor);
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // POST: Autor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutorID,OIB,Ime,Prezime")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        // GET: Autor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autor autor = db.Autor.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autor autor = db.Autor.Find(id);
            db.Autor.Remove(autor);
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
