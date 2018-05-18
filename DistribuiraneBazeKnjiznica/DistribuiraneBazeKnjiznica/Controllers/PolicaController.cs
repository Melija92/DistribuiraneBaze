﻿using System;
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
    public class PolicaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NazivSortParm = String.IsNullOrEmpty(sortOrder) ? "oznaka_desc" : "";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;
            var police = db.Polica.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
                police = police.Where(s => s.Oznaka.Contains(searchString));

            switch (sortOrder)
            {
                case "oznaka_desc":
                    police = police.OrderByDescending(s => s.Oznaka);
                    break;
                default:
                    police = police.OrderBy(s => s.Oznaka);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(police.ToPagedList(pageNumber, pageSize));
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
