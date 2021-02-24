using Microsoft.EntityFrameworkCore;
using SchoolManagementCore.BLL.Interfaces;
using SchoolManagementCore.DAL;
using SchoolManagementCore.Models;
using SchoolManagementCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolManagementCore.BLL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ConnectionDBContext _context;

        public StudentRepository(ConnectionDBContext context)
        {
            _context = context;
        }
        public void DeleteCourse(int id)
        {
            Course delCourse = GetCourseById(id);
            _context.Courses.Remove(delCourse);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student delstudent = GetStudentById(id);
            _context.Students.Remove(delstudent);
            _context.SaveChanges();
        }

        public List<CreateStudentModel> GetCreateStudents()
        {
            List<CreateStudentModel> createstudentModels = new List<CreateStudentModel>();
            createstudentModels = _context.Students.Select(p => new CreateStudentModel
            {
                Name = p.Name,
                DoB = p.DoB,
                Email = p.Email,
                Phone = p.Phone,
                CourseFee = p.CourseFee,
                ImageName = p.ImageName,
                ImageUrl = p.ImageUrl,
                CourseID = p.Course.ID
            }).ToList();
            return createstudentModels;
        }

        public Course GetCourseById(int CourseID)
        {
            Course course = _context.Courses.SingleOrDefault(g => g.ID == CourseID);
            return course;
        }

        public List<Course> GetCourses()
        {
            List<Course> courseList = _context.Courses.ToList();
            return courseList;
        }

        public Student GetStudentById(int id)
        {
            Student student = _context.Students.SingleOrDefault(p => p.StudentID == id);
            return student;
        }

        public List<StudentListViewModel> GetStudentList()
        {
            List<StudentListViewModel> list = _context.Students.Select(p => new StudentListViewModel
            {
                StudentID = p.StudentID,
                Name = p.Name,
                DoB = p.DoB,
                Email = p.Email,
                Phone = p.Phone,
                CourseFee = p.CourseFee,
                ImageName = p.ImageName,
                ImageUrl = p.ImageUrl,
                CourseID = p.CourseID,
                CourseName = p.Course.CourseName,
            }).ToList();
            return list;
        }

        public void SaveCourse(Course obj)
        {
            _context.Courses.Add(obj);
            _context.SaveChanges();
        }

        public void SaveStudent(Student obj)
        {
            _context.Students.Add(obj);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateStudent(Student obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
