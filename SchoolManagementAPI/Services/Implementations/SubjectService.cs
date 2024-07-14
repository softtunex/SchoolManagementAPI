using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;
using SchoolManagementAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementAPI.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            return await _subjectRepository.GetSubjects();
        }
        public async Task<Subject> GetSubjectById(int id)
        {
            return await _subjectRepository.GetSubject(id);
        }
        public async Task AddSubject(Subject subject)
        {
            await _subjectRepository.AddSubject(subject);
        }
        public async Task UpdateSubject(Subject subject)
        {
            await _subjectRepository.UpdateSubject(subject);
        }
        public async Task DeleteSubject(int id)
        {
            await _subjectRepository.DeleteSubject(id);
        }
        public async Task<bool> SubjectExists(int id)
        {
            return await _subjectRepository.SubjectExists(id);
        }
    }
}
