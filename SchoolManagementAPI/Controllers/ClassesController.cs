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
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        // GET: api/Classes
        [HttpGet("GetAllClasses")]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            var cls = await _classService.GetAllClasses();
            return Ok(cls);
        }

        // GET: api/Classes/5
        [HttpGet("GetClassById/{id}")]
        public async Task<ActionResult<Class>> GetClass(int id)
        {
            var cls = await _classService.GetClassById(id);

            if (cls == null)
            {
                return NotFound();
            }

            return Ok(cls);
        }

        // PUT: api/Classes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateClass/{id}")]
        public async Task<IActionResult> PutClass(int id, Class cls)
        {
            if (id != cls.ClassId)
            {
                return BadRequest();
            }


            try
            {
                await _classService.UpdateClass(cls);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _classService.ClassExists(id))
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

        // POST: api/Classes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("CreateClass")]
        public async Task<ActionResult<Class>> PostClass(Class cls)
        {
            await _classService.AddClass(cls);

            return CreatedAtAction("GetClass", new { id = cls.ClassId }, cls);
        }

        // DELETE: api/Classes/5
        [HttpDelete("DeleteClass/{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var cls = await _classService.GetClassById(id);
            if (cls == null)
            {
                return NotFound();
            }

            
            await _classService.DeleteClass(id);

            return NoContent();
        }

    }
}
