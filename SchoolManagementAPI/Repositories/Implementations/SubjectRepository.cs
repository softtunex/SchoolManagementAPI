using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Repositories.Implementations
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SchoolContext _context;
        public SubjectRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }
        public async Task<Subject> GetSubject(int id)
        {
            return await _context.Subjects.FindAsync(id);
        }
        public async Task AddSubject(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateSubject(Subject subject)
        {
            _context.Entry(subject).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> SubjectExists(int id)
        {
            return await _context.Subjects.AnyAsync(e => e.SubjectId == id);
        }
    }
}
