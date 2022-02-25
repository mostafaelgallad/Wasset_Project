using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WassetPortal_DAL.Models;

namespace WassetPortal.Controllers
{
    public class Hospitals_PackagesController : Controller
    {
        private WassetPortalDBEntities db = new WassetPortalDBEntities();

        // GET: Hospitals_Packages
        public ActionResult Index()
        {
            var hospitals_Packages = db.Hospitals_Packages.Include(h => h.Hospital).Include(h => h.Test);
            return View(hospitals_Packages.ToList());
        }

        // GET: Hospitals_Packages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospitals_Packages hospitals_Packages = db.Hospitals_Packages.Find(id);
            if (hospitals_Packages == null)
            {
                return HttpNotFound();
            }
            return View(hospitals_Packages);
        }

        // GET: Hospitals_Packages/Create
        public ActionResult Create()
        {
            ViewBag.Fk_Hospital_ID = new SelectList(db.Hospitals, "HospitalID", "HospitalNameAr");
            ViewBag.Fk_Package_ID = new SelectList(db.Tests, "TestID", "TestNameEn");
            return View();
        }

        // POST: Hospitals_Packages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Hospitals_PackagesID,Fk_Hospital_ID,Fk_Package_ID,Hospital_Package_Status,Price")] Hospitals_Packages hospitals_Packages)
        {
            if (ModelState.IsValid)
            {
                db.Hospitals_Packages.Add(hospitals_Packages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fk_Hospital_ID = new SelectList(db.Hospitals, "HospitalID", "HospitalNameAr", hospitals_Packages.Fk_Hospital_ID);
            ViewBag.Fk_Package_ID = new SelectList(db.Tests, "TestID", "TestNameEn", hospitals_Packages.Fk_Package_ID);
            return View(hospitals_Packages);
        }

        // GET: Hospitals_Packages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospitals_Packages hospitals_Packages = db.Hospitals_Packages.Find(id);
            if (hospitals_Packages == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fk_Hospital_ID = new SelectList(db.Hospitals, "HospitalID", "HospitalNameAr", hospitals_Packages.Fk_Hospital_ID);
            ViewBag.Fk_Package_ID = new SelectList(db.Tests, "TestID", "TestNameEn", hospitals_Packages.Fk_Package_ID);
            return View(hospitals_Packages);
        }

        // POST: Hospitals_Packages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Hospitals_PackagesID,Fk_Hospital_ID,Fk_Package_ID,Hospital_Package_Status,Price")] Hospitals_Packages hospitals_Packages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospitals_Packages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fk_Hospital_ID = new SelectList(db.Hospitals, "HospitalID", "HospitalNameAr", hospitals_Packages.Fk_Hospital_ID);
            ViewBag.Fk_Package_ID = new SelectList(db.Tests, "TestID", "TestNameEn", hospitals_Packages.Fk_Package_ID);
            return View(hospitals_Packages);
        }

        // GET: Hospitals_Packages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospitals_Packages hospitals_Packages = db.Hospitals_Packages.Find(id);
            if (hospitals_Packages == null)
            {
                return HttpNotFound();
            }
            return View(hospitals_Packages);
        }

        // POST: Hospitals_Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospitals_Packages hospitals_Packages = db.Hospitals_Packages.Find(id);
            db.Hospitals_Packages.Remove(hospitals_Packages);
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
