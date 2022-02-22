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
    public class PatientsController : Controller
    {
        private WassetPortalDBEntities db = new WassetPortalDBEntities();

        // GET: Patients
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.Hospital).Include(p => p.Hospitals_Packages).Include(p => p.SampleResult).Include(p => p.SampleStatu);
            return View(patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.FK_Hospital_ID = new SelectList(db.Hospitals, "HospitalID", "HospitalNameAr");
            ViewBag.FK_Hospital_Package_ID = new SelectList(db.Hospitals_Packages, "Hospitals_PackagesID", "Hospitals_PackagesID");
            ViewBag.FK_Result = new SelectList(db.SampleResults, "SampleResultID", "SampleResultName");
            ViewBag.Fk_StatusID = new SelectList(db.SampleStatus, "Sample_Status_ID", "SampleStatusName");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,PASSPORT,ID_IQAMA,NATIONALITY,Gender,DOB,MOBILE,HESN_NO,C_Case,FK_Hospital_Package_ID,Patient_Status,FK_Hospital_ID,Fk_StatusID,FK_Result,BirthDate")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Hospital_ID = new SelectList(db.Hospitals, "HospitalID", "HospitalNameAr", patient.FK_Hospital_ID);
            ViewBag.FK_Hospital_Package_ID = new SelectList(db.Hospitals_Packages, "Hospitals_PackagesID", "Hospitals_PackagesID", patient.FK_Hospital_Package_ID);
            ViewBag.FK_Result = new SelectList(db.SampleResults, "SampleResultID", "SampleResultName", patient.FK_Result);
            ViewBag.Fk_StatusID = new SelectList(db.SampleStatus, "Sample_Status_ID", "SampleStatusName", patient.Fk_StatusID);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Hospital_ID = new SelectList(db.Hospitals, "HospitalID", "HospitalNameAr", patient.FK_Hospital_ID);
            ViewBag.FK_Hospital_Package_ID = new SelectList(db.Hospitals_Packages, "Hospitals_PackagesID", "Hospitals_PackagesID", patient.FK_Hospital_Package_ID);
            ViewBag.FK_Result = new SelectList(db.SampleResults, "SampleResultID", "SampleResultName", patient.FK_Result);
            ViewBag.Fk_StatusID = new SelectList(db.SampleStatus, "Sample_Status_ID", "SampleStatusName", patient.Fk_StatusID);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,PASSPORT,ID_IQAMA,NATIONALITY,Gender,DOB,MOBILE,HESN_NO,C_Case,FK_Hospital_Package_ID,Patient_Status,FK_Hospital_ID,Fk_StatusID,FK_Result,BirthDate")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Hospital_ID = new SelectList(db.Hospitals, "HospitalID", "HospitalNameAr", patient.FK_Hospital_ID);
            ViewBag.FK_Hospital_Package_ID = new SelectList(db.Hospitals_Packages, "Hospitals_PackagesID", "Hospitals_PackagesID", patient.FK_Hospital_Package_ID);
            ViewBag.FK_Result = new SelectList(db.SampleResults, "SampleResultID", "SampleResultName", patient.FK_Result);
            ViewBag.Fk_StatusID = new SelectList(db.SampleStatus, "Sample_Status_ID", "SampleStatusName", patient.Fk_StatusID);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
