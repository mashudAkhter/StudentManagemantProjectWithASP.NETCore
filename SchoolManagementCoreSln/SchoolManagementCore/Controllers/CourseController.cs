using Microsoft.AspNetCore.Mvc;
using SchoolManagementCore.BLL.Interfaces;
using SchoolManagementCore.DAL;
using SchoolManagementCore.Models;
using SchoolManagementCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.Controllers
{
    public class CourseController : Controller
    {
        private readonly IStudentRepository _repoObj;
        private readonly ConnectionDBContext _context;

        public CourseController(IStudentRepository repoObj, ConnectionDBContext context)
        {
            _repoObj = repoObj;
            _context = context;
        }
        public ActionResult CourseList()
        {
            List<Course> courseList = _repoObj.GetCourses();
            return View(courseList);
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCourse(CreateCourseViewModel viewobj)
        {
            Course courseObj = new Course();
            courseObj.CourseName = viewobj.CourseName;
            _repoObj.SaveCourse(courseObj);
            RedirectToAction("CourseList");
            return RedirectToAction("CourseList");
        }
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            Course courseObj = _context.Courses.SingleOrDefault(g => g.ID == id);
            CreateCourseViewModel courseObj2 = new CreateCourseViewModel();
            if (courseObj != null)
            {
                // gradeObj = new Grade();
                courseObj2.CourseName = courseObj.CourseName;
            }

            return View(courseObj);
        }
        [HttpPost]
        public ActionResult EditCourse(CreateCourseViewModel viewObj)
        {
            Course courseObj = new Course();
            courseObj.CourseName = viewObj.CourseName;
            courseObj.ID = viewObj.ID;
            _repoObj.UpdateCourse(courseObj);
            return RedirectToAction("CourseList");
        }
        public ActionResult DeleteCourse(int id)
        {
            Course courseobj = _repoObj.GetCourseById(id);
            if (courseobj != null)
            {
                _repoObj.DeleteCourse(courseobj.ID);
                return RedirectToAction("CourseList");
            }
            return View(courseobj);
        }
    }
}
