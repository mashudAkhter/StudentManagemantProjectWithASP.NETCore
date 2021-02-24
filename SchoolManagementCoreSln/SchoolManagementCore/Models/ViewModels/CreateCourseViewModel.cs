using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.Models.ViewModels
{
    public class CreateCourseViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Course is Required")]
        public string CourseName { get; set; }
    }
}
