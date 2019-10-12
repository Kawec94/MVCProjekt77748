using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVCProjekt77748.Models;

namespace MVCProjekt77748.Controllers
{
    public class KursController : Controller
    {
        private KursDBContext db = new KursDBContext();
        private ZapisDBContext zapisDB = new ZapisDBContext();

        // GET: Kurs
        public ActionResult Index(string searchString)
        {
            var kursy = from m in db.Kursy
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                kursy = kursy.Where(s => s.Tytul.Contains(searchString));
            }

            return View(kursy);
        }

        // GET: Kurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurs kurs = db.Kursy.Find(id);
            if (kurs == null)
            {
                return HttpNotFound();
            }
            return View(kurs);
        }

        // GET: Kurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tytul,DataRozpoczecia,Poziom,Cena,LiczbaMiejsc,LiczbaWolnychMiejsc")] Kurs kurs)
        {
            if (ModelState.IsValid)
            {
                db.Kursy.Add(kurs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kurs);
        }

        // GET: Kurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurs kurs = db.Kursy.Find(id);
            if (kurs == null)
            {
                return HttpNotFound();
            }
            return View(kurs);
        }

        // POST: Kurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tytul,DataRozpoczecia,Poziom,Cena,LiczbaMiejsc,LiczbaWolnychMiejsc")] Kurs kurs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kurs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kurs);
        }

        // GET: Kurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kurs kurs = db.Kursy.Find(id);
            if (kurs == null)
            {
                return HttpNotFound();
            }
            return View(kurs);
        }

        public ActionResult Save(int id)
        {
            var query = from upd in db.Kursy where upd.IDKursu == id select upd;

            foreach (Kurs upd in query)
            {
                upd.LiczbaWolnychMiejsc--;
            }
            var userID = User.Identity.GetUserId();
            var zapis = new Zapis { Id = userID.ToString(), IDKursu = id };
            zapisDB.Zapisy.Add(zapis);
            zapisDB.SaveChanges();

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
            }
            return View();
        }

        // POST: Kurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kurs kurs = db.Kursy.Find(id);
            db.Kursy.Remove(kurs);
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
