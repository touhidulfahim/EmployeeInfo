﻿using System;
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
    public class DistrictController : Controller
    {
        private EmployeeInfoDbEntities db = new EmployeeInfoDbEntities();

        // GET: /District/
        public ActionResult Index()
        {
            var districts = db.Districts.Include(d => d.Division);
            return View(districts.ToList());
        }

        // GET: /District/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // GET: /District/Create
        public ActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionName");
            return View();
        }

        // POST: /District/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="DistrictId,DistrictName,DivisionId")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(district);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionName", district.DivisionId);
            return View(district);
        }

        // GET: /District/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionName", district.DivisionId);
            return View(district);
        }

        // POST: /District/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DistrictId,DistrictName,DivisionId")] District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionName", district.DivisionId);
            return View(district);
        }

        // GET: /District/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        // POST: /District/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            District district = db.Districts.Find(id);
            db.Districts.Remove(district);
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
