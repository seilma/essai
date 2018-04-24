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
    public class CommentaireJobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentaireJobsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CommentaireJobs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CommentaireJob.Include(c => c.Job).Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CommentaireJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentaireJob = await _context.CommentaireJob.SingleOrDefaultAsync(m => m.CommentaireId == id);
            if (commentaireJob == null)
            {
                return NotFound();
            }

            return View(commentaireJob);
        }

        // GET: CommentaireJobs/Create
        public IActionResult Create()
        {
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId");
            ViewData["IdUser"] = new SelectList(_context.AppUSers, "Id", "Id");
            return View();
        }

        // POST: CommentaireJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentaireId,AddDate,Description,IdUser,JobId")] CommentaireJob commentaireJob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commentaireJob);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId", commentaireJob.JobId);
            ViewData["IdUser"] = new SelectList(_context.AppUSers, "Id", "Id", commentaireJob.IdUser);
            return View(commentaireJob);
        }

        // GET: CommentaireJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentaireJob = await _context.CommentaireJob.SingleOrDefaultAsync(m => m.CommentaireId == id);
            if (commentaireJob == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId", commentaireJob.JobId);
            ViewData["IdUser"] = new SelectList(_context.AppUSers, "Id", "Id", commentaireJob.IdUser);
            return View(commentaireJob);
        }

        // POST: CommentaireJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentaireId,AddDate,Description,IdUser,JobId")] CommentaireJob commentaireJob)
        {
            if (id != commentaireJob.CommentaireId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentaireJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentaireJobExists(commentaireJob.CommentaireId))
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
            ViewData["JobId"] = new SelectList(_context.Jobs, "JobId", "JobId", commentaireJob.JobId);
            ViewData["IdUser"] = new SelectList(_context.AppUSers, "Id", "Id", commentaireJob.IdUser);
            return View(commentaireJob);
        }

        // GET: CommentaireJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentaireJob = await _context.CommentaireJob.SingleOrDefaultAsync(m => m.CommentaireId == id);
            if (commentaireJob == null)
            {
                return NotFound();
            }

            return View(commentaireJob);
        }

        // POST: CommentaireJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commentaireJob = await _context.CommentaireJob.SingleOrDefaultAsync(m => m.CommentaireId == id);
            _context.CommentaireJob.Remove(commentaireJob);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CommentaireJobExists(int id)
        {
            return _context.CommentaireJob.Any(e => e.CommentaireId == id);
        }
    }
}
