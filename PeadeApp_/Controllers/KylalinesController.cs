using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PeadeApp.Models;
using PeadeApp_.Models;

namespace PeadeApp_.Controllers
{
    public class KylalinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Kylalines Kõik külalised ja nende valikud
        public ActionResult Index()
        {
            var kylalised = db.Kylalined.Include(k => k.Pyha).ToList();
            return View(kylalised);
        }

        // GET: Kylalines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kylaline kylaline = db.Kylalined.Find(id);
            if (kylaline == null)
            {
                return HttpNotFound();
            }
            return View(kylaline);
        }

        // GET: Kylalines/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Kylalines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Nimi,Email,OnKutse,PyhaId")] Kylaline kylaline)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Kylalined.Add(kylaline);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(kylaline);
        //}

        // GET: Kylalines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kylaline kylaline = db.Kylalined.Find(id);
            if (kylaline == null)
            {
                return HttpNotFound();
            }
            return View(kylaline);
        }

        // POST: Kylalines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nimi,Email,OnKutse,PyhaId")] Kylaline kylaline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kylaline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kylaline);
        }

        // GET: Kylalines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kylaline kylaline = db.Kylalined.Find(id);
            if (kylaline == null)
            {
                return HttpNotFound();
            }
            return View(kylaline);
        }

        // POST: Kylalines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kylaline kylaline = db.Kylalined.Find(id);
            db.Kylalined.Remove(kylaline);
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
        // Filtreeritud andmed: tulevad külalised
        public ActionResult Tulevad()
        {
            var tulevad = db.Kylalined.Where(k => k.OnKutse == true);
            ViewBag.Filter = " Tulevad külalised";
            return View("Index", tulevad);
        }
        public ActionResult MitteTulevad()
        {
            var mittetulevad = db.Kylalined.Where(k => k.OnKutse == false);
            ViewBag.Filter = " Mitte tulevad külalised";
            return View("Index", mittetulevad);
        }
    }
}
