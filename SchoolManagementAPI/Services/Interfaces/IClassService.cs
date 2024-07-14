using SchoolManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementAPI.Services.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<Class>> GetAllClasses();
        Task<Class> GetClassById(int id);
        Task AddClass(Class cls);
        Task UpdateClass(Class cls);
        Task DeleteClass(int id);
        Task<bool> ClassExists(int id);
    }
}
