using System;
using System.ComponentModel.DataAnnotations;
using MockSchoolManagement.Models.EnumTypes;

namespace MockSchoolManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string  Name { get; set; }

        public MajorEnum Major { get; set; }
        public string  Email { get; set; }

        public string  PhotoPath { get; set; }
    }

}
