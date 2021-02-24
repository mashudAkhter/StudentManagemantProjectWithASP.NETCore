using SchoolManagementCore.Models;
using SchoolManagementCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.BLL.Interfaces
{
    public interface IStudentRepository
    {
        List<StudentListViewModel> GetStudentList();
        List<CreateStudentModel> GetCreateStudents();
        void UpdateStudent(Student obj);
        void SaveStudent(Student obj);
        void DeleteStudent(int id);
        Student GetStudentById(int id);
        List<Course> GetCourses();
        void SaveCourse(Course obj);
        void UpdateCourse(Course obj);
        Course GetCourseById(int CourseID);
        void DeleteCourse(int id);
    }
}
