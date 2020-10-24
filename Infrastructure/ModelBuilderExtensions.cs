using Microsoft.EntityFrameworkCore;
using MockSchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockSchoolManagement.Models.EnumTypes;

namespace MockSchoolManagement.Infrastructure
{
    public static class ModelBuildeExtensions
    {
      
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                       new Student
                       {
                           Id = 1,
                           Name = "周龙",
                           Major =MajorEnum.ComputerScience,
                           Email = "5@5amcn.com"
                       }
                       );
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   Id = 2,
                   Name = "张三",
                   Major = MajorEnum.Mathematics,
                   Email = "zs@5amcn.com"
               }
               );
        }
    }
}
