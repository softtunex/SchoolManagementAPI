using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementAPI.Models;
namespace SchoolManagementAPI.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(int id);
        Task<Student> GetStudentByDetails(string firstName, string lastName, DateTime dateOfBirth); // Add this line
        Task<bool> StudentExists(int id);
    }
}