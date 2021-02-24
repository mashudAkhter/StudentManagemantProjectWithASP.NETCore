using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.Models.ViewModels
{
    public class CreateStudentModel
    {
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Student Name Is Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Student Name")]
        [StringLength(50, ErrorMessage = "Student Name Must be within 50 Charecter")]
        public string Name { get; set; }
        [CustomDateOfBirth(ErrorMessage = "Date of Birth must be less than or equal to Today's Date")]
        public DateTime DoB { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Is Required")]
        public string Phone { get; set; }
        [Range(5000, 50000, ErrorMessage = "CourseFee must be between 5000 to 50,000")]
        public decimal CourseFee { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public List<Course> courseList { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
