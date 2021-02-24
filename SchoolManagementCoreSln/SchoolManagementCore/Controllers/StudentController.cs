using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using SchoolManagementCore.BLL.Interfaces;
using SchoolManagementCore.BLL.Repositories;
using SchoolManagementCore.DAL;
using SchoolManagementCore.Models;
using SchoolManagementCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.Controllers
{
    [AllowAnonymous]
    //[Authorize(Roles = "Admin, SuperAdmin, User")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repoObj;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ConnectionDBContext _context;

        public StudentController(IStudentRepository repoObj, IHostingEnvironment hostingEnvironment, ConnectionDBContext context)
        {
            _repoObj = repoObj;
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
        public ActionResult Index(string SearchString, string CurrentFilter, string sortOrder, int? Page)
        {
            ViewBag.SortNameParam = string.IsNullOrEmpty(sortOrder) ? "name_des" : "";
            ViewBag.CourseFee = string.IsNullOrEmpty(sortOrder) ? "CourseFee_des" : "";
            if (SearchString != null)
            {
                Page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.CurrentFilter = SearchString;

            List<StudentListViewModel> studentList = _repoObj.GetStudentList();

            if (!string.IsNullOrEmpty(SearchString))
            {
                studentList = studentList.Where(n => n.Name.ToUpper().Contains(SearchString.ToUpper())).ToList();
            }
            switch (sortOrder)
            {
                case "name_des":
                    studentList = studentList.OrderByDescending(n => n.Name).ToList();
                    break;
                case "CourseFee_des":
                    studentList = studentList.OrderByDescending(n => n.CourseFee).ToList();
                    break;
                default:
                    studentList = studentList.OrderBy(n => n.Name).ToList();
                    break;
            }
            int PageSize = 6;
            int PageNumber = (Page ?? 1);
            return View("Index", studentList.ToPagedList(PageNumber, PageSize));


            //List<studentListViewModel> list = repoObj.GetstudentList();
            //return View(list);
        }

        public ActionResult Create()
        {
            CreateStudentModel crObj = new CreateStudentModel();
            crObj.courseList = _context.Courses.ToList();
            return View(crObj);
        }
        public ActionResult AddOrEdit(CreateStudentModel viewObj)
        {
            var result = false;

            string uniqueFile = ProcessUploadFile(viewObj);
            Student studentObj = new Student();
            studentObj.Name = viewObj.Name;
            studentObj.DoB = viewObj.DoB;

            studentObj.Email = viewObj.Email;
            studentObj.Phone = viewObj.Phone;
            studentObj.CourseFee = viewObj.CourseFee;
            studentObj.CourseID = viewObj.CourseID;
            //studentObj.ImageName = fileWithExtension;
            studentObj.ImageUrl = uniqueFile;
            //string fileServerPath = Path.Combine(Server.MapPath("~/Images/" + fileName + extension));
            //viewObj.ImageFile.SaveAs(fileServerPath);

            if (ModelState.IsValid)
            {
                if (viewObj.StudentID == 0)
                {
                    _repoObj.SaveStudent(studentObj);
                    result = true;
                }
                else
                {
                    studentObj.StudentID = viewObj.StudentID;
                    _repoObj.UpdateStudent(studentObj);
                    result = true;
                }
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (viewObj.StudentID == 0)
                {
                    CreateStudentModel crObj = new CreateStudentModel();
                    crObj.courseList = _context.Courses.ToList();
                    return View("Create", crObj);
                }
                else
                {
                    CreateStudentModel crObj = new CreateStudentModel();
                    crObj.courseList = _context.Courses.ToList();
                    return View("Edit", crObj);
                }
            }

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            Student studentObj = _repoObj.GetStudentById(id);
            CreateStudentModel viewObj = new CreateStudentModel();
            if (studentObj != null)
            {
                viewObj.StudentID = studentObj.StudentID;
                viewObj.Name = studentObj.Name;
                viewObj.DoB = studentObj.DoB;
                viewObj.Email = studentObj.Email;
                viewObj.Phone = studentObj.Phone;
                viewObj.ImageName = studentObj.ImageName;
                viewObj.CourseFee = studentObj.CourseFee;
                viewObj.CourseID = studentObj.CourseID;
                viewObj.courseList = _context.Courses.ToList();
                viewObj.ImageUrl = studentObj.ImageUrl;
            }
            return View(viewObj);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Student studentObj = _repoObj.GetStudentById(id);
            CreateStudentModel viewObj = new CreateStudentModel();
            if (studentObj != null)
            {
                viewObj.StudentID = studentObj.StudentID;
                viewObj.Name = studentObj.Name;
                viewObj.DoB = studentObj.DoB;
                viewObj.Email = studentObj.Email;
                viewObj.Phone = studentObj.Phone;
                viewObj.CourseFee = studentObj.CourseFee;
                viewObj.CourseID = studentObj.CourseID;
                viewObj.ImageUrl = studentObj.ImageUrl;
            }

            return View(viewObj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Student studentObj = _repoObj.GetStudentById(id);
            if (studentObj != null)
            {
                _repoObj.DeleteStudent(studentObj.StudentID);
                return RedirectToAction("Index");
            }
            return View(studentObj);
        }
        //public ActionResult Details(int StudentID)
        //{
        //    Student studentObj = _repoObj.GetStudentById(StudentID);
        //    StudentListViewModel viewObj = new StudentListViewModel();
        //    viewObj.StudentID = studentObj.StudentID;
        //    viewObj.Name = studentObj.Name;
        //    viewObj.DoB = studentObj.DoB;
        //    viewObj.Email = studentObj.Email;
        //    viewObj.Phone = studentObj.Phone;
        //    viewObj.CourseFee = studentObj.CourseFee;
        //    viewObj.CourseID = studentObj.CourseID;
        //    //viewObj.GradeName = studentObj.Grade.GradeName;
        //    viewObj.ImageUrl = studentObj.ImageUrl;
        //    return PartialView("_DetailsRecord", viewObj);
        //}


        public IActionResult Details(int id)
        {
            Student obj = _repoObj.GetStudentById(id);
            //ViewData["student"] = obj;
            //ViewBag.student = obj;
            return View(obj);
        }
        private string ProcessUploadFile(CreateStudentModel viewobj)
        {
            string uniqueFileName = null;
            var files = HttpContext.Request.Form.Files;
            foreach (var image in files)
            {
                if (image != null && image.Length > 0)
                {
                    var file = image;
                    var uploadFile = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                    if (file.Length > 0)
                    {
                        var fileName = file.FileName;
                        using (var fileStream = new FileStream(Path.Combine(uploadFile, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            uniqueFileName = fileName;
                        }
                    }

                }
            }

            return uniqueFileName;
        }
    }
}
