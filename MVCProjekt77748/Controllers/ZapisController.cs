using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCProjekt77748.Models;

namespace MVCProjekt77748.Controllers
{
    public class ZapisController : Controller
    {
        private ZapisDBContext db = new ZapisDBContext();

        // GET: Zapis
        public ActionResult Index()
        {
            return View(db.Zapisy.ToList());
        }

        // GET: Zapis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zapis zapis = db.Zapisy.Find(id);
            if (zapis == null)
            {
                return HttpNotFound();
            }
            return View(zapis);
        }

        // GET: Zapis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zapis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDZapisu,Email")] Zapis zapis)
        {
            if (ModelState.IsValid)
            {
                db.Zapisy.Add(zapis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zapis);
        }

        // GET: Zapis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zapis zapis = db.Zapisy.Find(id);
            if (zapis == null)
            {
                return HttpNotFound();
            }
            return View(zapis);
        }

        // POST: Zapis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDZapisu,Email")] Zapis zapis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zapis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zapis);
        }

        // GET: Zapis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zapis zapis = db.Zapisy.Find(id);
            if (zapis == null)
            {
                return HttpNotFound();
            }
            return View(zapis);
        }

        // POST: Zapis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zapis zapis = db.Zapisy.Find(id);
            db.Zapisy.Remove(zapis);
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
