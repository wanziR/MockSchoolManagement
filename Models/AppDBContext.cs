using System;
using Microsoft.EntityFrameworkCore;
namespace MockSchoolManagement.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        
    }
}
