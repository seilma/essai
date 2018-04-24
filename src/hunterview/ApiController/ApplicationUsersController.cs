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
    [Route("api/ApplicationUsers")]
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApplicationUsers
        [HttpGet]
        public IEnumerable<ApplicationUser> GetAppUSers()
        {
            return _context.AppUSers;
        }

        // GET: api/ApplicationUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser applicationUser = await _context.AppUSers.SingleOrDefaultAsync(m => m.Email == id);

            if (applicationUser == null)
            {
                return NotFound();
            }

            return Ok(applicationUser);
        }

        // PUT: api/ApplicationUsers/5
        [HttpPut]
        public async Task<IActionResult> PutApplicationUser( [FromBody] ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUser a = _context.AppUSers.FirstOrDefault(t => t.Token == applicationUser.Token);
          /*  if (a.Token != applicationUser.Token)
            {
                return BadRequest();
            }*/
            a.Locked = applicationUser.Locked;
            a.FirstName = applicationUser.FirstName;
            a.LastName = applicationUser.LastName;
            a.rate = applicationUser.rate;
            a.Birthday = applicationUser.Birthday;
            a.Country = applicationUser.Country;
            a.Sector = applicationUser.Sector;
            a.Description = applicationUser.Description;
            _context.Entry(a).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(applicationUser.Token))
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

        // POST: api/ApplicationUsers
        [HttpPost]
        public async Task<IActionResult> PostApplicationUser([FromBody] ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AppUSers.Add(applicationUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApplicationUserExists(applicationUser.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetApplicationUser", new { id = applicationUser.Id }, applicationUser);
        }

        // DELETE: api/ApplicationUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApplicationUser applicationUser = await _context.AppUSers.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            _context.AppUSers.Remove(applicationUser);
            await _context.SaveChangesAsync();

            return Ok(applicationUser);
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.AppUSers.Any(e => e.Token == id);
        }
    }
}