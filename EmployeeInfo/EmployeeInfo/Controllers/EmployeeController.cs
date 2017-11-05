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
    public class EmployeeController : Controller
    {
        private EmployeeInfoDbEntities db = new EmployeeInfoDbEntities();

        // GET: /Employee/
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.BloodGroup).Include(e => e.Education).Include(e => e.Gender).Include(e => e.MaritalStatu).Include(e => e.PoliceStation).Include(e => e.Position).Include(e => e.Religion).Include(e => e.Role).Include(e => e.Status).Include(e => e.Title);
            
            return View(employees.ToList());
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: /Employee/Create
        public ActionResult Create()
        {
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "BloodId", "GloodGroupName");
            ViewBag.Id = new SelectList(db.Educations, "EducationId", "GroupName");
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName");
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "MaritalStatusId", "MaritalStatusName");
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "PoliceStationId", "PoliceStationName");
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "PositionName");
            ViewBag.ReligionId = new SelectList(db.Religions, "ReligionId", "ReligionName");
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "StatusName");
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "TitleName");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "DivisionName");
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName");
            return View();
        }

        // POST: /Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,TitleId,FirstName,LastName,FathersName,MothersName,SpouseName,GenderId,DateOfBirth,MaritalStatusId,ReligionId,BloodGroupId,MobileNo,EmailId,NationalIdentity,ImagePath,Address1,Address2,PoliceStationId,ZipCode,JoiningDate,PositionId,RoleId,StatusId,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "BloodId", "GloodGroupName", employee.BloodGroupId);
            ViewBag.Id = new SelectList(db.Educations, "EducationId", "GroupName", employee.Id);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", employee.GenderId);
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "MaritalStatusId", "MaritalStatusName", employee.MaritalStatusId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "PoliceStationId", "PoliceStationName", employee.PoliceStationId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "PositionName", employee.PositionId);
            ViewBag.ReligionId = new SelectList(db.Religions, "ReligionId", "ReligionName", employee.ReligionId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", employee.RoleId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "StatusName", employee.StatusId);
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "TitleName", employee.TitleId);
            return View(employee);
        }

        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "BloodId", "GloodGroupName", employee.BloodGroupId);
            ViewBag.Id = new SelectList(db.Educations, "EducationId", "GroupName", employee.Id);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", employee.GenderId);
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "MaritalStatusId", "MaritalStatusName", employee.MaritalStatusId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "PoliceStationId", "PoliceStationName", employee.PoliceStationId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "PositionName", employee.PositionId);
            ViewBag.ReligionId = new SelectList(db.Religions, "ReligionId", "ReligionName", employee.ReligionId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", employee.RoleId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "StatusName", employee.StatusId);
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "TitleName", employee.TitleId);
            return View(employee);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,TitleId,FirstName,LastName,FathersName,MothersName,SpouseName,GenderId,DateOfBirth,MaritalStatusId,ReligionId,BloodGroupId,MobileNo,EmailId,NationalIdentity,ImagePath,Address1,Address2,PoliceStationId,ZipCode,JoiningDate,PositionId,RoleId,StatusId,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodGroupId = new SelectList(db.BloodGroups, "BloodId", "GloodGroupName", employee.BloodGroupId);
            ViewBag.Id = new SelectList(db.Educations, "EducationId", "GroupName", employee.Id);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", employee.GenderId);
            ViewBag.MaritalStatusId = new SelectList(db.MaritalStatus, "MaritalStatusId", "MaritalStatusName", employee.MaritalStatusId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "PoliceStationId", "PoliceStationName", employee.PoliceStationId);
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "PositionName", employee.PositionId);
            ViewBag.ReligionId = new SelectList(db.Religions, "ReligionId", "ReligionName", employee.ReligionId);
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", employee.RoleId);
            ViewBag.StatusId = new SelectList(db.Status, "StatusId", "StatusName", employee.StatusId);
            ViewBag.TitleId = new SelectList(db.Titles, "TitleId", "TitleName", employee.TitleId);
            return View(employee);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
