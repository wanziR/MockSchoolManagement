using MockSchoolManagement.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockSchoolManagement.DataRespositories
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDBContext _context;

        public SQLStudentRepository(AppDBContext context)
        {
            _context = context;
        }
        public Student Delete(int id)
        {
            Student student = _context.Students.Find(id);
            if (student !=null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return student;
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _context.Students;
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }

        public Student Insert(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student Update(Student updateStudent)
        {
            var student = _context.Students.Attach(updateStudent);
            _context.SaveChanges();
            return updateStudent;
        }
    }
}
