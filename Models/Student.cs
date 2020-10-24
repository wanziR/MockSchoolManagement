using System;
using MockSchoolManagement.Models.EnumTypes;

namespace MockSchoolManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        /// <summary>
        /// 主修科目
        /// </summary>
        public MajorEnum Major { get; set; }
        public string  Email { get; set; }

        public string  PhotoPath { get; set; }
    }

}
