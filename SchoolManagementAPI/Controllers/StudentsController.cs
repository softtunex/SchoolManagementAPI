using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SchoolManagementAPI.DTOs;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentService studentService,ILogger<StudentsController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        // GET: api/Students
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students= await _studentService.GetAllStudents();
            _logger.LogInformation("Retrieved all Student");
            return Ok(students);

        }

        // GET: api/Students/5
        [HttpGet("GetStudentById/{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentById(id);

            if (student == null)
            {
                _logger.LogInformation($"Student with {id} not found");
                return NotFound();
            }
            _logger.LogInformation($"Retrieved student with ID {id}");
            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateStudent/{id}")]
        public async Task<IActionResult> PutStudent(int id,[FromBody] StudentDTO studentDTO,Student stdt)
        {
            if(!ModelState.IsValid){ 
                return BadRequest(ModelState); 
            }

            if (id != stdt.StudentId)
            {
                _logger.LogWarning("ID mismatch");
                return BadRequest();
            }


            try
            {
                var student = new Student
                {
                    FirstName = studentDTO.FirstName,
                    LastName = studentDTO.LastName,
                    DateOfBirth = studentDTO.DateOfBirth,
                    Gender = studentDTO.Gender,
                    Address = studentDTO.Address,
                    ParentContact = studentDTO.ParentContact,
                    Level = studentDTO.Level
                };
                var updatedStudent = await _studentService.UpdateStudent(student); // Get the updated student
                _logger.LogInformation($"Student {student.FirstName} {student.LastName} updated successfully");
                return Ok(updatedStudent); // Return the updated student
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error updating student");
                return BadRequest(ex.Message);

            }
        }
        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateStudent")]
        public async Task<ActionResult<Student>> PostStudent([FromBody] StudentDTO studentDTO)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState); 
            }
            try
            {
                var student = new Student
                {
                    FirstName = studentDTO.FirstName,
                    LastName = studentDTO.LastName,
                    DateOfBirth = studentDTO.DateOfBirth,
                    Gender = studentDTO.Gender,
                    Address = studentDTO.Address,
                    ParentContact = studentDTO.ParentContact,
                    Level = studentDTO.Level
                }; 
                var addedStudent = await _studentService.AddStudent(student); // Get the added student
                _logger.LogInformation($"Student {student.FirstName} {student.LastName} added successfully");
                return CreatedAtAction(nameof(GetStudent), new { id = addedStudent.StudentId }, addedStudent);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error adding student");
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Students/5
        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                _logger.LogError( "Error deleting student");
                return NotFound();
            }

            _logger.LogInformation($"Student with ID {id} deleted successfully");
            await _studentService.DeleteStudent(id);

            return NoContent();
        }

    }
}
