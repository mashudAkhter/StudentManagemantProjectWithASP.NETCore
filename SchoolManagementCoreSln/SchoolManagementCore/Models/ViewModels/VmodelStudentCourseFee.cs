using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.Models.ViewModels
{
    public class VmodelStudentCourseFee
    {
        public int StudentInfoId { get; set; }
        public string StudentName { get; set; }
        public List<StudentInfo> StudentList { get; set; }
        public List<VmodelFeeTbl> CourseList { get; set; }
    }
}
