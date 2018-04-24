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
    [Route("api/CommentaireJobs")]
    public class CommentaireJobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentaireJobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CommentaireJobs
        [HttpGet]
        public IEnumerable<CommentaireJob> GetCommentaireJob()
        {
            return _context.CommentaireJob;
        }

        // GET: api/CommentaireJobs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentaireJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CommentaireJob commentaireJob = await _context.CommentaireJob.SingleOrDefaultAsync(m => m.CommentaireId == id);

            if (commentaireJob == null)
            {
                return NotFound();
            }

            return Ok(commentaireJob);
        }

        // PUT: api/CommentaireJobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentaireJob([FromRoute] int id, [FromBody] CommentaireJob commentaireJob)
        {
            CommentaireJob j = _context.CommentaireJob.FirstOrDefault(t => t.CommentaireId == commentaireJob.CommentaireId);
            j.Description = commentaireJob.Description;
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commentaireJob.CommentaireId)
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
                if (!CommentaireJobExists(id))
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

        // POST: api/CommentaireJobs
        [HttpPost]
        public async Task<IActionResult> PostCommentaireJob([FromBody] CommentaireJob commentaireJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          //  commentaireJob.JobId = 1;
            

            _context.CommentaireJob.Add(commentaireJob);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommentaireJobExists(commentaireJob.CommentaireId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCommentaireJob", new { id = commentaireJob.CommentaireId }, commentaireJob);
        }

        // DELETE: api/CommentaireJobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentaireJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CommentaireJob commentaireJob = await _context.CommentaireJob.SingleOrDefaultAsync(m => m.CommentaireId == id);
            if (commentaireJob == null)
            {
                return NotFound();
            }

            _context.CommentaireJob.Remove(commentaireJob);
            await _context.SaveChangesAsync();

            return Ok(commentaireJob);
        }
        [HttpGet("{id}/{token}")]
        public IActionResult OwnCommentaireJob([FromRoute] int id, [FromRoute]  string token)
        {
            if (_context.AppUSers.FirstOrDefault() == null || _context.CommentaireJob.FirstOrDefault() == null) { return Ok(true); }
            CommentaireJob j = new CommentaireJob();
            j = _context.CommentaireJob.FirstOrDefault(i => i.CommentaireId == id);
            ApplicationUser au = new ApplicationUser();

            au = _context.AppUSers.FirstOrDefault(l => l.Token == token);

            if (j.IdUser == au.Id) { return Ok(true); }

            return Ok(false);
        }

        private bool CommentaireJobExists(int id)
        {
            return _context.CommentaireJob.Any(e => e.CommentaireId == id);
        }
    }
}