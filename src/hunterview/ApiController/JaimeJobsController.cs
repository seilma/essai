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
    [Route("api/JaimeJobs")]
    public class JaimeJobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JaimeJobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JaimeJobs
        [HttpGet]
        public IEnumerable<JaimeJob> GetJaimeJob()
        {
            return _context.JaimeJob;
        }

        // GET: api/JaimeJobs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJaimeJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            JaimeJob jaimeJob = await _context.JaimeJob.SingleOrDefaultAsync(m => m.Id == id);

            if (jaimeJob == null)
            {
                return NotFound();
            }

            return Ok(jaimeJob);
        }

        // PUT: api/JaimeJobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJaimeJob([FromRoute] int id, [FromBody] JaimeJob jaimeJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jaimeJob.Id)
            {
                return BadRequest();
            }

            _context.Entry(jaimeJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JaimeJobExists(id))
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

        // POST: api/JaimeJobs
        [HttpPost]
        public async Task<IActionResult> PostJaimeJob([FromBody] JaimeJob jaimeJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JaimeJob.Add(jaimeJob);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JaimeJobExists(jaimeJob.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJaimeJob", new { id = jaimeJob.Id }, jaimeJob);
        }

        // DELETE: api/JaimeJobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJaimeJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            JaimeJob jaimeJob = await _context.JaimeJob.SingleOrDefaultAsync(m => m.Id == id);
            if (jaimeJob == null)
            {
                return NotFound();
            }

            _context.JaimeJob.Remove(jaimeJob);
            await _context.SaveChangesAsync();

            return Ok(jaimeJob);
        }

        private bool JaimeJobExists(int id)
        {
            return _context.JaimeJob.Any(e => e.Id == id);
        }

    }
}