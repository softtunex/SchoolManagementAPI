using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectById(int id);
        Task AddSubject(Subject subject);
        Task UpdateSubject(Subject subject);
        Task DeleteSubject(int id);
        Task<bool> SubjectExists(int id);
    }
}
