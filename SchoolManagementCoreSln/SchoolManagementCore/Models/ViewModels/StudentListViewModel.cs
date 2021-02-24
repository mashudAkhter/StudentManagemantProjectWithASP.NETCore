using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.Models.ViewModels
{
    public class StudentListViewModel
    {
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Is Required")]
        public string Phone { get; set; }
        public decimal CourseFee { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public virtual Course Course { get; set; }
    }
}
