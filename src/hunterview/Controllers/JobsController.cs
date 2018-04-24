using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using hunterview.Data;

namespace hunterview.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jobs.Include(j => j.Headhunter).Include(j => j.Speciality);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["testId"] = new SelectList(_context.AppUSers, "Id", "Id");
            ViewData["SpecilityId"] = new SelectList(_context.Speciality, "SpecialityId", "SpecialityId");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,AddDate,Address,Degree,Description,Duration,Entreprise,Expertise,ExprerationDate,NbrJaime,Position,Sector,SpecilityId,StartDate,State,Title,Type,Valid,nbrjaimepas")] Job job)
        {
            if (ModelState.IsValid)
            {
                job.testId = _context.AppUSers.First().testId;
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["testId"] = new SelectList(_context.AppUSers, "Id", "Id", job.testId);
            ViewData["SpecilityId"] = new SelectList(_context.Speciality, "SpecialityId", "SpecialityId", job.SpecilityId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["testId"] = new SelectList(_context.AppUSers, "Id", "Id", job.testId);
            ViewData["SpecilityId"] = new SelectList(_context.Speciality, "SpecialityId", "SpecialityId", job.SpecilityId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,AddDate,Address,Degree,Description,Duration,Entreprise,Expertise,ExprerationDate,NbrJaime,Position,Sector,SpecilityId,StartDate,State,Title,Type,Valid,nbrjaimepas,testId")] Job job)
        {
            if (id != job.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobId))
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
            ViewData["testId"] = new SelectList(_context.AppUSers, "Id", "Id", job.testId);
            ViewData["SpecilityId"] = new SelectList(_context.Speciality, "SpecialityId", "SpecialityId", job.SpecilityId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job = await _context.Jobs.SingleOrDefaultAsync(m => m.JobId == id);
            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.JobId == id);
        }
    }
}
