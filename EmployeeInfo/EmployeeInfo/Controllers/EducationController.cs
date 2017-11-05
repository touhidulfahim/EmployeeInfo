using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeInfo;

namespace EmployeeInfo.Controllers
{
    public class EducationController : Controller
    {
        private EmployeeInfoDbEntities db = new EmployeeInfoDbEntities();

        // GET: /Education/
        public ActionResult Index()
        {
            var educations = db.Educations.Include(e => e.Certificate).Include(e => e.Employee).Include(e => e.Institute).Include(e => e.Result);
            return View(educations.ToList());
        }

        // GET: /Education/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // GET: /Education/Create
        public ActionResult Create()
        {
            ViewBag.CertificateId = new SelectList(db.Certificates, "CertificateId", "CertificateName");
            ViewBag.EducationId = new SelectList(db.Employees, "Id", "FirstName");
            ViewBag.InstituteId = new SelectList(db.Institutes, "InstituteId", "InstituteName");
            ViewBag.ResultId = new SelectList(db.Results, "ResultId", "ResultType");
            return View();
        }

        // POST: /Education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EducationId,EmployeeId,CertificateId,InstituteId,GroupName,Year,ResultId")] Education education)
        {
            if (ModelState.IsValid)
            {
                db.Educations.Add(education);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CertificateId = new SelectList(db.Certificates, "CertificateId", "CertificateName", education.CertificateId);
            ViewBag.EducationId = new SelectList(db.Employees, "Id", "FirstName", education.EducationId);
            ViewBag.InstituteId = new SelectList(db.Institutes, "InstituteId", "InstituteName", education.InstituteId);
            ViewBag.ResultId = new SelectList(db.Results, "ResultId", "ResultType", education.ResultId);
            return View(education);
        }

        // GET: /Education/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            ViewBag.CertificateId = new SelectList(db.Certificates, "CertificateId", "CertificateName", education.CertificateId);
            ViewBag.EducationId = new SelectList(db.Employees, "Id", "FirstName", education.EducationId);
            ViewBag.InstituteId = new SelectList(db.Institutes, "InstituteId", "InstituteName", education.InstituteId);
            ViewBag.ResultId = new SelectList(db.Results, "ResultId", "ResultType", education.ResultId);
            return View(education);
        }

        // POST: /Education/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EducationId,EmployeeId,CertificateId,InstituteId,GroupName,Year,ResultId")] Education education)
        {
            if (ModelState.IsValid)
            {
                db.Entry(education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CertificateId = new SelectList(db.Certificates, "CertificateId", "CertificateName", education.CertificateId);
            ViewBag.EducationId = new SelectList(db.Employees, "Id", "FirstName", education.EducationId);
            ViewBag.InstituteId = new SelectList(db.Institutes, "InstituteId", "InstituteName", education.InstituteId);
            ViewBag.ResultId = new SelectList(db.Results, "ResultId", "ResultType", education.ResultId);
            return View(education);
        }

        // GET: /Education/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: /Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Education education = db.Educations.Find(id);
            db.Educations.Remove(education);
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
