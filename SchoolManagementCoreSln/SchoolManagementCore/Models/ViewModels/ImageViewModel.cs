using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.Models.ViewModels
{
    public class ImageViewModel : CreateStudentModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
