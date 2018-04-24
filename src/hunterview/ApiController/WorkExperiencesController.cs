using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using hunterview.Data;
using hunterview.Models;

namespace hunterview.ApiController
{
    [Produces("application/json")]
    [Route("api/WorkExperiences")]
    public class WorkExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkExperiencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkExperiences
        [HttpGet]
        public IEnumerable<WorkExperience> GetWorkExperience()
        {
            return _context.WorkExperience;
        }

        // GET: api/WorkExperiences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkExperience([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            WorkExperience workExperience = await _context.WorkExperience.SingleOrDefaultAsync(m => m.WorkExperienceId == id);

            if (workExperience == null)
            {
                return NotFound();
            }

            return Ok(workExperience);
        }

        // PUT: api/WorkExperiences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkExperience([FromRoute] int id, [FromBody] WorkExperience workExperience)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (id != workExperience.WorkExperienceId)
            {
                return BadRequest();
            }
            WorkExperience we = _context.WorkExperience.FirstOrDefault(o => o.WorkExperienceId == id);
            we.Position = workExperience.Position;
            we.StartDate = workExperience.StartDate;
            we.EndDate = workExperience.EndDate;
            we.Entreprise = workExperience.Entreprise;
            

            _context.Entry(workExperience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExperienceExists(id))
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

        // POST: api/WorkExperiences
        [HttpPost]
        public async Task<IActionResult> PostWorkExperience([FromBody] WorkExperience workExperience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.WorkExperience.Add(workExperience);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorkExperienceExists(workExperience.WorkExperienceId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWorkExperience", new { id = workExperience.WorkExperienceId }, workExperience);
        }

        // DELETE: api/WorkExperiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkExperience([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            WorkExperience workExperience = await _context.WorkExperience.SingleOrDefaultAsync(m => m.WorkExperienceId == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            _context.WorkExperience.Remove(workExperience);
            await _context.SaveChangesAsync();

            return Ok(workExperience);
        }

        private bool WorkExperienceExists(int id)
        {
            return _context.WorkExperience.Any(e => e.WorkExperienceId == id);
        }
        [HttpGet("{id}/{token}")]
        public IActionResult OwnWorkExperience([FromRoute] int id, [FromRoute]  string token)
        {
            if (_context.AppUSers.FirstOrDefault() == null || _context.WorkExperience.FirstOrDefault() == null) { return Ok(true); }
            WorkExperience j = new WorkExperience();
            j = _context.WorkExperience.FirstOrDefault(i => i.WorkExperienceId == id);
            ApplicationUser au = new ApplicationUser();

            au = _context.AppUSers.FirstOrDefault(l => l.Token == token);

            if (j.idUser == au.Id) { return Ok(true); }

            return Ok(false);
        }
    }
}