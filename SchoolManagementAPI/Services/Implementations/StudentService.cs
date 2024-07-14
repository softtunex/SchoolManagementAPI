using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;
using SchoolManagementAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementAPI.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _studentRepository.GetStudents();
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await _studentRepository.GetStudent(id);
        }
        public async Task<Student> AddStudent(Student student)
        {
            var existingStudent = await _studentRepository.GetStudentByDetails(student.FirstName, student.LastName, student.DateOfBirth);
            if (existingStudent != null)
            {                                                     
                throw new System.Exception("Student already exists.");
            }
            return await _studentRepository.AddStudent(student);
        }
        public async Task<Student> UpdateStudent(Student student)
        {
            var existingStudent = await _studentRepository.GetStudent(student.StudentId);
            if (existingStudent != null)
            {
                throw new System.Exception("Student not found");
            }
            return await _studentRepository.UpdateStudent(student);
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var existingStudent = await _studentRepository.GetStudent(id);
            if (existingStudent == null)
            {
                throw new System.Exception("Student not found.");
            }
            return await _studentRepository.DeleteStudent(id);
        }
        public async Task<bool> StudentExists(int id)
        {
            return await _studentRepository.StudentExists(id);
        }
        
    }
}
