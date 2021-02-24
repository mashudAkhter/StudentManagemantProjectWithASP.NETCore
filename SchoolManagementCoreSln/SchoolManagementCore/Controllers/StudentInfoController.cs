using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementCore.DAL;
using SchoolManagementCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.Controllers
{
    //[Authorize(Roles = "Admin, SuperAdmin, User")]
    public class StudentInfoController : Controller
    {
        private readonly ConnectionDBContext db;

        public StudentInfoController(ConnectionDBContext context)
        {
            db = context;
        }
        public ActionResult Index()
        {
            return View(db.StudentInfos.ToList());
        }

        // GET: StudentInfos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo student = db.StudentInfos.Find(id);
            if (student == null)
            {
                //return HttpNotFound();
            }
            return View(student);
        }

        // GET: StudentInfos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentInfos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "studentId,studentName")]*/ StudentInfo student)
        {
            if (ModelState.IsValid)
            {
                db.StudentInfos.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: StudentInfos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo student = db.StudentInfos.Find(id);
            if (student == null)
            {
                //return HttpNotFound();
            }
            return View(student);
        }

        // POST: StudentInfos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "studentId,studentName")]*/ StudentInfo student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: StudentInfos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo student = db.StudentInfos.Find(id);
            if (student == null)
            {
                //return HttpNotFound();
            }
            return View(student);
        }

        // POST: StudentInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var oProduct = db.FeeTbls.Where(p => p.StudentInfoId == id).FirstOrDefault();
            if (oProduct == null) // check if there any product exist under this student
            {
                StudentInfo student = db.StudentInfos.Find(id);
                db.StudentInfos.Remove(student);
                db.SaveChanges();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

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
