using System;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MockSchoolManagement.Infrastructure;

namespace MockSchoolManagement.Models
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        //种子数据 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().HasData(
            //    new Student
            //    {
            //        Id = 1,
            //        Name = "周龙",
            //        Major = "计算机",
            //        Email = "5@5amcn.com"
            //    }
            //    );
            //modelBuilder.Entity<Student>().HasData(
            //   new Student
            //   {
            //       Id = 2,
            //       Name = "张三",
            //       Major = "工商管理",
            //       Email = "zs@5amcn.com" 
            //   }
            //   );
            //====>创建一个seed()方法来保存这些种子数据，而这个方法是扩展方法，参数中包含this关键字(/Infrastructure/ModelBuilderExtensions.cs)。
            modelBuilder.Seed();
        }

    }
}
