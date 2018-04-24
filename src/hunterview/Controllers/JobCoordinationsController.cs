using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hunterview.Data;
using hunterview.Models;

namespace hunterview.Controllers
{
    public class JobCoordinationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobCoordinationsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: JobCoordinations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobCoordination.Include(j => j.Job).Include(j => j.Jobseeker);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobCoordinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCoordination = await _context.JobCoordination.SingleOrDefaultAsync(m => m.JobCoordinationId == id);
            if (jobCoordination == null)
            {
                return NotFound();
            }

            return View(jobCoordination);
        }

        // GET: JobCoordinations/Create
        public IActionResult Create()
        {
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId");
            ViewData["idUser"] = new SelectList(_context.AppUSers, "Id", "Id");
            return View();
        }

        // POST: JobCoordinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobCoordinationId,Adddate,Approved,JobId,idUser")] JobCoordination jobCoordination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobCoordination);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId", jobCoordination.JobId);
            ViewData["idUser"] = new SelectList(_context.AppUSers, "Id", "Id", jobCoordination.idUser);
            return View(jobCoordination);
        }

        // GET: JobCoordinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCoordination = await _context.JobCoordination.SingleOrDefaultAsync(m => m.JobCoordinationId == id);
            if (jobCoordination == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId", jobCoordination.JobId);
            ViewData["idUser"] = new SelectList(_context.AppUSers, "Id", "Id", jobCoordination.idUser);
            return View(jobCoordination);
        }

        // POST: JobCoordinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobCoordinationId,Adddate,Approved,JobId,idUser")] JobCoordination jobCoordination)
        {
            if (id != jobCoordination.JobCoordinationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobCoordination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobCoordinationExists(jobCoordination.JobCoordinationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId", jobCoordination.JobId);
            ViewData["idUser"] = new SelectList(_context.AppUSers, "Id", "Id", jobCoordination.idUser);
            return View(jobCoordination);
        }

        // GET: JobCoordinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCoordination = await _context.JobCoordination.SingleOrDefaultAsync(m => m.JobCoordinationId == id);
            if (jobCoordination == null)
            {
                return NotFound();
            }

            return View(jobCoordination);
        }

        // POST: JobCoordinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobCoordination = await _context.JobCoordination.SingleOrDefaultAsync(m => m.JobCoordinationId == id);
            _context.JobCoordination.Remove(jobCoordination);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JobCoordinationExists(int id)
        {
            return _context.JobCoordination.Any(e => e.JobCoordinationId == id);
        }
    }
}
