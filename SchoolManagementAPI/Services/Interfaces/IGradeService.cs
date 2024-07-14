using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>> GetAllGrades();
        Task<Grade> GetGradeById(int id);
        Task AddGrade(Grade grade);
        Task UpdateGrade(Grade grade);
        Task DeleteGrade(int id);
        Task<bool> GradeExists(int id);
    }
}
