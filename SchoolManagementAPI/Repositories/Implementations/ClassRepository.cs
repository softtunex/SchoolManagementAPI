using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SchoolManagementAPI.Repositories.Implementations
{
    public class ClassRepository : IClassRepository
    {
        private readonly SchoolContext _context;
        public ClassRepository(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Class>> GetClasses()
        {
            return await _context.Classes.ToListAsync();
        }
        public async Task<Class> GetClassById(int id)
        {
            return await _context.Classes.FindAsync(id);
        }
        public async Task AddClass(Class cls)
        {
            _context.Classes.Add(cls);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateClass(Class cls)
        {
            _context.Entry(cls).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteClass(int id)
        {
            var cls = await _context.Classes.FindAsync(id);
            if (cls != null)
            {
                _context.Classes.Remove(cls);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ClassExists(int id)
        {
            return await _context.Classes.AnyAsync(e=>e.ClassId == id);
        }

    }
}
