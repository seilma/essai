using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hunterview.Data;
using hunterview.Models;

namespace hunterview.ApiController
{
    [Produces("application/json")]
    [Route("api/JobCoordinations")]
    public class JobCoordinationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobCoordinationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobCoordinations
        [HttpGet]
        public IEnumerable<JobCoordination> GetJobCoordination()
        {
            return _context.JobCoordination;
        }

        // GET: api/JobCoordinations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobCoordination([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            JobCoordination jobCoordination = await _context.JobCoordination.SingleOrDefaultAsync(m => m.JobCoordinationId == id);

            if (jobCoordination == null)
            {
                return NotFound();
            }

            return Ok(jobCoordination);
        }

        // PUT: api/JobCoordinations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobCoordination([FromRoute] int id, [FromBody] JobCoordination jobCoordination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobCoordination.JobCoordinationId)
            {
                return BadRequest();
            }

            _context.Entry(jobCoordination).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobCoordinationExists(id))
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

        // POST: api/JobCoordinations
        [HttpPost]
        public async Task<IActionResult> PostJobCoordination([FromBody] JobCoordination jobCoordination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JobCoordination.Add(jobCoordination);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobCoordinationExists(jobCoordination.JobCoordinationId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobCoordination", new { id = jobCoordination.JobCoordinationId }, jobCoordination);
        }

        // DELETE: api/JobCoordinations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobCoordination([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            JobCoordination jobCoordination = await _context.JobCoordination.SingleOrDefaultAsync(m => m.JobCoordinationId == id);
            if (jobCoordination == null)
            {
                return NotFound();
            }

            _context.JobCoordination.Remove(jobCoordination);
            await _context.SaveChangesAsync();

            return Ok(jobCoordination);
        }

        private bool JobCoordinationExists(int id)
        {
            return _context.JobCoordination.Any(e => e.JobCoordinationId == id);
        }
    }
}