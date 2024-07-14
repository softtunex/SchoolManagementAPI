using SchoolManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementAPI.Repositories.Interfaces
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> GetGrades();
        Task<Grade> GetGradeById(int id);
        Task AddGrade(Grade grade);
        Task UpdateGrade(Grade grade);
        Task DeleteGrade(int id);
        Task<bool> GradeExists(int id);
    }
}
