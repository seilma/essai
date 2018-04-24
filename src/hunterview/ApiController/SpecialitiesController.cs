using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using hunterview.Data;

namespace hunterview.ApiController
{
    [Produces("application/json")]
    [Route("api/Specialities")]
    public class SpecialitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Specialities
        [HttpGet]
        public IEnumerable<Speciality> GetSpeciality()
        {
            return _context.Speciality;
        }

        // GET: api/Specialities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpeciality([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Speciality speciality = await _context.Speciality.SingleOrDefaultAsync(m => m.SpecialityId == id);

            if (speciality == null)
            {
                return NotFound();
            }

            return Ok(speciality);
        }

        // PUT: api/Specialities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeciality([FromRoute] int id, [FromBody] Speciality speciality)
        {
            Speciality j = _context.Speciality.FirstOrDefault(t => t.SpecialityId == speciality.SpecialityId);
            j.Title = speciality.Title;
            j.Description = speciality.Description;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != speciality.SpecialityId)
            {
                return BadRequest();
            }

            _context.Entry(j).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialityExists(id))
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

        // POST: api/Specialities
        [HttpPost]
        public async Task<IActionResult> PostSpeciality([FromBody] Speciality speciality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Speciality.Add(speciality);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SpecialityExists(speciality.SpecialityId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSpeciality", new { id = speciality.SpecialityId }, speciality);
        }

        // DELETE: api/Specialities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpeciality([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Speciality speciality = await _context.Speciality.SingleOrDefaultAsync(m => m.SpecialityId == id);
            if (speciality == null)
            {
                return NotFound();
            }

            _context.Speciality.Remove(speciality);
            await _context.SaveChangesAsync();

            return Ok(speciality);
        }

        private bool SpecialityExists(int id)
        {
            return _context.Speciality.Any(e => e.SpecialityId == id);
        }
    }
}