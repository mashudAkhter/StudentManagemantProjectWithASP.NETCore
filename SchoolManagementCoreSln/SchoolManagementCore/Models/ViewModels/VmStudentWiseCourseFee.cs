using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.Models.ViewModels
{
    public class VmStudentWiseCourseFee
    {
        public int StudentInfoId { get; set; }
        public string StudentName { get; set; }
        public List<VmodelStudentInfo> StudentList { get; set; }
        public List<VmodelFeeTbl> CourseFeeList { get; set; }
    }
}
