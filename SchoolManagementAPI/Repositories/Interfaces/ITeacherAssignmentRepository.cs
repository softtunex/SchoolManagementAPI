using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementAPI.Models;
namespace SchoolManagementAPI.Repositories.Interfaces
{
    public interface ITeacherAssignmentRepository
    {
        Task<IEnumerable<TeacherAssignment>> GetTeacherAssignments();
        Task<TeacherAssignment> GetTeacherAssignment(int id);
        Task AddTeacherAssignment(TeacherAssignment teacher);
        Task UpdateTeacherAssignment(TeacherAssignment teacher);
        Task DeleteTeacherAssignment(int id);
        Task<bool> TeacherAssignmentExists(int id);
    }
}