using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementAPI.Models;
namespace SchoolManagementAPI.Repositories.Interfaces
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetClasses();
        Task<Class> GetClassById(int id);
        Task AddClass(Class cls);
        Task UpdateClass(Class cls);
        Task DeleteClass(int id);
        Task<bool> ClassExists(int id);

    }
}
