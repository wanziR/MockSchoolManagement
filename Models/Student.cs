using System;
namespace MockSchoolManagement.Models
{
    public class Student//@_@ 包含数据的类Student
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        /// <summary>
        /// 主修科目
        /// </summary>
        public string  Major { get; set; }
        public string  Email { get; set; }
    }

    //public interface IStudentRepository
    //{
    //    Student GetStudent(int id);
    //    void Save(Student student);
    //}

    //public class MockStudentRepository : IStudentRepository//@_@管理数据的类StudentRepostory
    //{
    //    public Student GetStudent(int id)
    //    {
    //        //写逻辑实现查询学生详情
    //        throw new NotImplementedException();
    //    }

    //    public void Save(Student student)
    //    {
    //        //写逻辑实现保存学生信息
    //        throw new NotImplementedException();
    //    }
    //}
}
