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
    [Route("api/Experiences")]
    public class ExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExperiencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Experiences
        [HttpGet]
        public IEnumerable<Experience> GetExperience()
        {
            return _context.Experience;
        }

        // GET: api/Experiences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExperience([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Experience experience = await _context.Experience.SingleOrDefaultAsync(m => m.ExperienceId == id);

            if (experience == null)
            {
                return NotFound();
            }

            return Ok(experience);
        }

        // PUT: api/Experiences/5
        [HttpPut("{Token}")]
        public async Task<IActionResult> PutExperience([FromRoute] int id, [FromBody] Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            

            if (id != experience.ExperienceId)
            {
                return BadRequest();
            }
            Experience e = _context.Experience.FirstOrDefault(t => t.ExperienceId == id);
            e.Note = experience.Note;
            e.Valid = experience.Valid;
            _context.Entry(experience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienceExists(id))
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

        // POST: api/Experiences
        [HttpPost]
        public async Task<IActionResult> PostExperience([FromBody] Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Experience.Add(experience);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExperienceExists(experience.ExperienceId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExperience", new { id = experience.ExperienceId }, experience);
        }

        // DELETE: api/Experiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Experience experience = await _context.Experience.SingleOrDefaultAsync(m => m.ExperienceId == id);
            if (experience == null)
            {
                return NotFound();
            }

            _context.Experience.Remove(experience);
            await _context.SaveChangesAsync();

            return Ok(experience);
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experience.Any(e => e.ExperienceId == id);
        }
    }
}