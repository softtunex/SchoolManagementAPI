using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementAPI.Models;
using SchoolManagementAPI.Services.Interfaces;

namespace SchoolManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAssignmentsController : ControllerBase
    {
        private readonly ITeacherAssignmentService _teacherService;

        public TeacherAssignmentsController(ITeacherAssignmentService teacherService)
        {
            _teacherService = teacherService;
        }

        // GET: api/TeacherAssignments
        [HttpGet("GetAllTeacherAssignments")]
        public async Task<ActionResult<IEnumerable<TeacherAssignment>>> GetTeacherAssignments()
        {
            var teachers = await _teacherService.GetAllTeacherAssignments();
            return Ok(teachers);

        }

        // GET: api/TeacherAssignments/5
        [HttpGet("GetTeacherAssignmentById/{id}")]
        public async Task<ActionResult<TeacherAssignment>> GetTeacherAssignment(int id)
        {
            var teacher = await _teacherService.GetTeacherAssignmentById(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        // PUT: api/TeacherAssignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateTeacherAssignment/{id}")]
        public async Task<IActionResult> PutTeacherAssignment(int id, TeacherAssignment teacher)
        {
            if (id != teacher.TeacherId)
            {
                return BadRequest();
            }


            try
            {
                await _teacherService.UpdateTeacherAssignment(teacher);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _teacherService.TeacherAssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TeacherAssignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateTeacherAssignment")]
        public async Task<ActionResult<TeacherAssignment>> PostTeacherAssignment(TeacherAssignment teacher)
        {
            await _teacherService.AddTeacherAssignment(teacher);

            return CreatedAtAction("GetTeacherAssignment", new { id = teacher.TeacherId }, teacher);
        }

        // DELETE: api/TeacherAssignments/5
        [HttpDelete("DeleteTeacherAssignment/{id}")]
        public async Task<IActionResult> DeleteTeacherAssignment(int id)
        {
            var teacher = await _teacherService.GetTeacherAssignmentById(id);
            if (teacher == null)
            {
                return NotFound();
            }


            await _teacherService.DeleteTeacherAssignment(id);

            return NoContent();
        }

    }
}
