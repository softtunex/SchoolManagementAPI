using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models;
using System;

namespace SchoolManagementAPI.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;
        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FindAsync(id);
        }
        public async Task<Student> AddStudent(Student student)
        {
             _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;

        }
        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return student; // Return the updated student
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return student;
        }
        public async Task<Student> GetStudentByDetails(string firstName, string lastName, DateTime dateOfBirth)
        {
            return await _context.Students
                .FirstOrDefaultAsync(s => s.FirstName == firstName && s.LastName == lastName && s.DateOfBirth == dateOfBirth);
        }
        public async Task<bool> StudentExists(int id)
        {
            return await _context.Students.AnyAsync(e => e.StudentId == id);
        }
    }
}
