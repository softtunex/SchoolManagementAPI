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
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        // GET: api/Grades
        [HttpGet("GetAllGrades")]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            var grades = await _gradeService.GetAllGrades();
            return Ok(grades);

        }

        // GET: api/Grades/5
        [HttpGet("GetGradeById/{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            var grade = await _gradeService.GetGradeById(id);

            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateGrade/{id}")]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            if (id != grade.GradeId)
            {
                return BadRequest();
            }


            try
            {
                await _gradeService.UpdateGrade(grade);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _gradeService.GradeExists(id))
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

        // POST: api/Grades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateGrade")]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {
            await _gradeService.AddGrade(grade);

            return CreatedAtAction("GetGrade", new { id = grade.GradeId }, grade);
        }

        // DELETE: api/Grades/5
        [HttpDelete("DeleteGrade/{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _gradeService.GetGradeById(id);
            if (grade == null)
            {
                return NotFound();
            }


            await _gradeService.DeleteGrade(id);

            return NoContent();
        }

    }
}
