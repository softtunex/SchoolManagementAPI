using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementAPI.Models;
namespace SchoolManagementAPI.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetSubjects();
        Task<Subject> GetSubject(int id);
        Task AddSubject(Subject subject);
        Task UpdateSubject(Subject subject);
        Task DeleteSubject(int id);
        Task<bool> SubjectExists(int id);
    }
}