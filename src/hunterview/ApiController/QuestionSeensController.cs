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
    [Route("api/QuestionSeens")]
    public class QuestionSeensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionSeensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/QuestionSeens
        [HttpGet]
        public IEnumerable<QuestionSeen> GetQuestionSeen()
        {
            return _context.QuestionSeen;
        }

        // GET: api/QuestionSeens/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionSeen([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            QuestionSeen questionSeen = await _context.QuestionSeen.SingleOrDefaultAsync(m => m.QuestionSeenId == id);

            if (questionSeen == null)
            {
                return NotFound();
            }

            return Ok(questionSeen);
        }

        // PUT: api/QuestionSeens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionSeen([FromRoute] int id, [FromBody] QuestionSeen questionSeen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionSeen.QuestionSeenId)
            {
                return BadRequest();
            }

            _context.Entry(questionSeen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionSeenExists(id))
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

        // POST: api/QuestionSeens
        [HttpPost]
        public async Task<IActionResult> PostQuestionSeen([FromBody] QuestionSeen questionSeen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QuestionSeen.Add(questionSeen);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuestionSeenExists(questionSeen.QuestionSeenId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQuestionSeen", new { id = questionSeen.QuestionSeenId }, questionSeen);
        }

        // DELETE: api/QuestionSeens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionSeen([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            QuestionSeen questionSeen = await _context.QuestionSeen.SingleOrDefaultAsync(m => m.QuestionSeenId == id);
            if (questionSeen == null)
            {
                return NotFound();
            }

            _context.QuestionSeen.Remove(questionSeen);
            await _context.SaveChangesAsync();

            return Ok(questionSeen);
        }

        private bool QuestionSeenExists(int id)
        {
            return _context.QuestionSeen.Any(e => e.QuestionSeenId == id);
        }
    }
}