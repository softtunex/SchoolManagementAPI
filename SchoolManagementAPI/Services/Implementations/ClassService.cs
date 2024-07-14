using SchoolManagementAPI.Repositories.Interfaces;
using SchoolManagementAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Services.Implementations
{
    public class ClassService: IClassService
    {
        private readonly IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public async Task<IEnumerable<Class>> GetAllClasses() { 
            return await _classRepository.GetClasses();
        }
        public async Task<Class> GetClassById(int id)
        {
            return await _classRepository.GetClassById(id);
        }
        public async Task AddClass(Class cls)
        {
            await _classRepository.AddClass(cls);
        }
        public async Task UpdateClass(Class cls)
        {
            await _classRepository.UpdateClass(cls);
        }
        public async Task DeleteClass(int id)
        {
            await _classRepository.DeleteClass(id);
        }
        public async Task<bool> ClassExists(int id)
        {
            return await _classRepository.ClassExists(id);
        }
    }
}
