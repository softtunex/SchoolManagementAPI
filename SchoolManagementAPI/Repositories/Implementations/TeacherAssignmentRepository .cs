using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models;

namespace SchoolManagementAPI.Repositories.Implementations
{
    public class TeacherAssignmentRepository : ITeacherAssignmentRepository
    {
        private readonly SchoolContext _context;
        public TeacherAssignmentRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeacherAssignment>> GetTeacherAssignments()
        {
            return await _context.TeacherAssignments.ToListAsync();
        }
        public async Task<TeacherAssignment> GetTeacherAssignment(int id)
        {
            return await _context.TeacherAssignments.FindAsync(id);
        }
        public async Task AddTeacherAssignment(TeacherAssignment teacher)
        {
            await _context.TeacherAssignments.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTeacherAssignment(TeacherAssignment teacher)
        {
            _context.Entry(teacher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTeacherAssignment(int id)
        {
            var teacher = await _context.TeacherAssignments.FindAsync(id);
            if (teacher != null)
            {
                _context.TeacherAssignments.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> TeacherAssignmentExists(int id)
        {
            return await _context.TeacherAssignments.AnyAsync(e => e.TeacherId == id);
        }
    }
}
