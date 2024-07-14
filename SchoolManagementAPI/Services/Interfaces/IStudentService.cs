using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> AddStudent(Student student); // Ensure it returns Student
        Task<Student> UpdateStudent(Student student); // Ensure it returns Student
        Task<Student> DeleteStudent(int id); // Ensure it returns Student
        Task<bool> StudentExists(int id);
    }
}
