using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementCore.DAL
{
    public class ConnectionDBContext:IdentityDbContext
    {
        public ConnectionDBContext(DbContextOptions<ConnectionDBContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentInfo> StudentInfos { get; set; }
        public DbSet<FeeTbl> FeeTbls { get; set; }
    }
}
