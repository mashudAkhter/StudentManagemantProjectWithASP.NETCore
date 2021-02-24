using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public Nullable<int> Status { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
