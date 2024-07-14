using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;
using SchoolManagementAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementAPI.Services.Implementations
{
    public class TeacherAssignmentService : ITeacherAssignmentService
    {
        private readonly ITeacherAssignmentRepository _teacherRepository;
        public TeacherAssignmentService(ITeacherAssignmentRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<IEnumerable<TeacherAssignment>> GetAllTeacherAssignments()
        {
            return await _teacherRepository.GetTeacherAssignments();
        }
        public async Task<TeacherAssignment> GetTeacherAssignmentById(int id)
        {
            return await _teacherRepository.GetTeacherAssignment(id);
        }
        public async Task AddTeacherAssignment(TeacherAssignment teacher)
        {
            await _teacherRepository.AddTeacherAssignment(teacher);
        }
        public async Task UpdateTeacherAssignment(TeacherAssignment teacher)
        {
            await _teacherRepository.UpdateTeacherAssignment(teacher);
        }
        public async Task DeleteTeacherAssignment(int id)
        {
            await _teacherRepository.DeleteTeacherAssignment(id);
        }
        public async Task<bool> TeacherAssignmentExists(int id)
        {
            return await _teacherRepository.TeacherAssignmentExists(id);
        }
    }
}
