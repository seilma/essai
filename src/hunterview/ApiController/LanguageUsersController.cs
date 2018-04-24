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
    [Route("api/LanguageUsers")]
    public class LanguageUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LanguageUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LanguageUsers
        [HttpGet]
        public IEnumerable<LanguageUser> GetLanguageUser()
        {
            return _context.LanguageUser;
        }

        // GET: api/LanguageUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguageUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LanguageUser languageUser = await _context.LanguageUser.SingleOrDefaultAsync(m => m.LanguageUserid == id);

            if (languageUser == null)
            {
                return NotFound();
            }

            return Ok(languageUser);
        }

        // PUT: api/LanguageUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguageUser([FromRoute] int id, [FromBody] LanguageUser languageUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != languageUser.LanguageUserid)
            {
                return BadRequest();
            }

            _context.Entry(languageUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageUserExists(id))
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

        // POST: api/LanguageUsers
        [HttpPost]
        public async Task<IActionResult> PostLanguageUser([FromBody] LanguageUser languageUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LanguageUser.Add(languageUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LanguageUserExists(languageUser.LanguageUserid))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLanguageUser", new { id = languageUser.LanguageUserid }, languageUser);
        }

        // DELETE: api/LanguageUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguageUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LanguageUser languageUser = await _context.LanguageUser.SingleOrDefaultAsync(m => m.LanguageUserid == id);
            if (languageUser == null)
            {
                return NotFound();
            }

            _context.LanguageUser.Remove(languageUser);
            await _context.SaveChangesAsync();

            return Ok(languageUser);
        }

        private bool LanguageUserExists(int id)
        {
            return _context.LanguageUser.Any(e => e.LanguageUserid == id);
        }
        [HttpGet("{id}/{token}")]
        public IActionResult OwnLanguageUser([FromRoute] int id, [FromRoute]  string token)
        {
            if (_context.AppUSers.FirstOrDefault() == null || _context.LanguageUser.FirstOrDefault() == null) { return Ok(true); }
            LanguageUser j = new LanguageUser();
            j = _context.LanguageUser.FirstOrDefault(i => i.LanguageUserid == id);
            ApplicationUser au = new ApplicationUser();

            au = _context.AppUSers.FirstOrDefault(l => l.Token == token);

            if (j.idUser == au.Id) { return Ok(true); }

            return Ok(false);
        }
    }
}