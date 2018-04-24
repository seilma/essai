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
    [Route("api/Responses")]
    public class ResponsesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResponsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Responses
        [HttpGet]
        public IEnumerable<Response> GetResponse()
        {
            List<Response> lr = new List<Response>();
            lr = _context.Response.ToList();

            foreach (var item in lr)
            {
                lr.FirstOrDefault(l => l.ResponseId == item.ResponseId).Question = _context.Question.FirstOrDefault(l => l.QuestionId == item.QuestionId);
            }
            return lr;
        }

        // GET: api/Responses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResponse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Response response = await _context.Response.SingleOrDefaultAsync(m => m.ResponseId == id);

            if (response == null)
            {
                return NotFound();
            }
            response.Question = await _context.Question.SingleOrDefaultAsync(m => m.QuestionId == response.QuestionId);
            return Ok(response);
        }

        // PUT: api/Responses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponse([FromRoute] int id, [FromBody] Response response)
        {
            Response j = _context.Response.FirstOrDefault(t => t.ResponseId == response.ResponseId);
            j.Content = response.Content;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != response.ResponseId)
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
                if (!ResponseExists(id))
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

        // POST: api/Responses
        [HttpPost]
        public async Task<IActionResult> PostResponse([FromBody] Response response)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Response.Add(response);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResponseExists(response.ResponseId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResponse", new { id = response.ResponseId }, response);
        }

        // DELETE: api/Responses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Response response = await _context.Response.SingleOrDefaultAsync(m => m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }

            _context.Response.Remove(response);
            await _context.SaveChangesAsync();

            return Ok(response);
        }

        private bool ResponseExists(int id)
        {
            return _context.Response.Any(e => e.ResponseId == id);
        }
    }
}