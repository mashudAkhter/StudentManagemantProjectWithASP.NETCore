using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.Models.ViewModels
{
    public class VmodelFeeTbl
    {
        public int FeeTblId { get; set; }
        public string Month { get; set; }
        public decimal CourseFee { get; set; }
        public string ImagePath { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public int StudentInfoId { get; set; }
        public int ExamFee { get; set; }
        public string StudentName { get; set; }
        public IFormFile ImgFile { get; set; }
        public List<StudentInfo> StudentList { get; set; }
    }
}
