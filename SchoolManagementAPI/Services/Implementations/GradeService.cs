using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;
using SchoolManagementAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementAPI.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }
        public async Task<IEnumerable<Grade>> GetAllGrades()
        {
            return await _gradeRepository.GetGrades();
        }
        public async Task<Grade> GetGradeById(int id)
        {
            return await _gradeRepository.GetGradeById(id);
        }
        public async Task AddGrade(Grade grade)
        {
            await _gradeRepository.AddGrade(grade);
        }
        public async Task UpdateGrade(Grade grade)
        {
            await _gradeRepository.UpdateGrade(grade);
        }
        public async Task DeleteGrade(int id)
        {
            await _gradeRepository.DeleteGrade(id);
        }
        public async Task<bool> GradeExists(int id)
        {
            return await _gradeRepository.GradeExists(id);
        }
    }
}
