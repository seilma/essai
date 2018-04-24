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
    [Route("api/Jobs")]
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

       

        // GET: api/Jobs
        [HttpGet]
        public IEnumerable<Job> GetJobs()
        {
            List<Job> lj = new List<Job>();
            lj = _context.Jobs.ToList();
            foreach (var item in lj)
            {
                // item.Speciality = _context.Speciality.FirstOrDefault(t => t.SpecialityId == item.SpecialityId);
                lj.FirstOrDefault(l => l.JobId == item.JobId).Speciality = _context.Speciality.FirstOrDefault(t => t.SpecialityId == item.SpecilityId);
                lj.FirstOrDefault(l => l.JobId == item.JobId).Company = _context.Company.FirstOrDefault(t => t.CompanyId == item.CompanyId);

            }
            return lj;
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Job job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobId == id);

            if (job == null)
            {
                return NotFound();
            }
            job.Speciality = await _context.Speciality.SingleOrDefaultAsync(m => m.SpecialityId == job.SpecilityId);
            //job.testId = job.Headhunter.Id;
            return Ok(job);
        }

        // PUT: api/Jobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob([FromRoute] int id, [FromBody] Job job)
        {
           
            Job j =  _context.Jobs.FirstOrDefault(t => t.JobId == job.JobId);

            j.Title = job.Title;
            j.Entreprise = job.Entreprise;
            j.Type = job.Type;
            j.Description = job.Description;
            j.Degree = job.Degree;
            j.Salary = job.Salary;
            j.Address = job.Address;
            j.WorkHours = job.WorkHours;
            j.Details = job.Details;


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            job.Speciality = null;
            if (id != job.JobId)
            {
                return BadRequest();
            }
            _context.Entry(j).State = EntityState.Modified;


            //    _context.Entry(job).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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

        // POST: api/Jobs
        [HttpPost]
        public async Task<IActionResult> PostJob([FromBody]  Job job)
        {
            _context.Jobs.Add(job);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobExists(job.JobId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJob", new { id = job.JobId }, job);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Job job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

            return Ok(job);
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.JobId == id);
        }
    }
}