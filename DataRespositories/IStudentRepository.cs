using System;
using System.Collections.Generic;
namespace MockSchoolManagement.Models
{
    public interface IStudentRepository
    {
        //Student GetStudent(int Id);
        //IEnumerable<Student> GetAllStudent();

        //通过id获取学生信息
        Student GetStudentById(int id);
        //获取所有学生信息
        IEnumerable<Student> GetAllStudent();
        //添加学生信息
        Student Insert(Student student);
        //修改学生信息
        Student Update(Student updateStudent);
        //删除学生信息
        Student Delete(int id);

    }
    
}
