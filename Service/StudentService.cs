using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAll();
        bool Add(Student model);
        bool Delete(int id);
        bool Update(Student model);
        Student Get(int id);
    }
    public class StudentService: IStudentService
    {
        private readonly StudentDbContext _studentDbContext;
        public StudentService(StudentDbContext studentDbContext) {
            _studentDbContext = studentDbContext;
        }
        public IEnumerable<Student> GetAll()
        {
            var result = new List<Student>();

            try
            {
                result = _studentDbContext.Student.ToList();
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public Student Get(int id)
        {
            var result = new Student();

            try
            {
                result = _studentDbContext.Student.Single(x => x.studentId == id);
            }
            catch (System.Exception)
            {

            }

            return result;
        }
        public bool Add(Student model) { 
            try
            {
                _studentDbContext.Add(model);
                _studentDbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool Update(Student model)
        {
            try
            {
                var originalModel = _studentDbContext.Student.Single(x =>
                    x.studentId == model.studentId
                );

                originalModel.name = model.name;
                originalModel.lastName = model.lastName;
                originalModel.bio = model.bio;

                _studentDbContext.Update(originalModel);
                _studentDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _studentDbContext.Entry(new Student { studentId = id }).State = EntityState.Deleted; ;
                _studentDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
