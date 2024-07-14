using SchoolManagementAPI.Repositories.Interfaces;
using SchoolManagementAPI.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementAPI.Repositories.Implementations
{
    public class GradeRepository:IGradeRepository
    {
        private readonly SchoolContext _context;
        public GradeRepository(SchoolContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Grade>> GetGrades()
        {
            return await _context.Grades.ToListAsync();
        }
        public async Task<Grade> GetGradeById(int id)
        {
            return await _context.Grades.FindAsync(id);
        }
        public async Task AddGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateGrade(Grade grade)
        {
            _context.Entry(grade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteGrade(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if(grade != null)
            {
                _context.Grades.Remove(grade);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> GradeExists(int id)
        {
            return await _context.Grades.AnyAsync(e=>e.GradeId == id);
        }
    }
}
