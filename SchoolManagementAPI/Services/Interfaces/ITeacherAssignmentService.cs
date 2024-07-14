using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface ITeacherAssignmentService
    {
        Task<IEnumerable<TeacherAssignment>> GetAllTeacherAssignments();
        Task<TeacherAssignment> GetTeacherAssignmentById(int id);
        Task AddTeacherAssignment(TeacherAssignment teacher);
        Task UpdateTeacherAssignment(TeacherAssignment teacher);
        Task DeleteTeacherAssignment(int id);
        Task<bool> TeacherAssignmentExists(int id);
    }
}
