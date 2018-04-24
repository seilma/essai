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
    public class WorkExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkExperiencesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: WorkExperiences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.WorkExperience.Include(w => w.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: WorkExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperience.SingleOrDefaultAsync(m => m.WorkExperienceId == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        // GET: WorkExperiences/Create
        public IActionResult Create()
        {
            ViewData["idUser"] = new SelectList(_context.AppUSers, "Id", "Id");
            return View();
        }

        // POST: WorkExperiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkExperienceId,Durée,EndDate,Entreprise,Position,StartDate,idUser,photo")] WorkExperience workExperience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["idUser"] = new SelectList(_context.AppUSers, "Id", "Id", workExperience.idUser);
            return View(workExperience);
        }

        // GET: WorkExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperience.SingleOrDefaultAsync(m => m.WorkExperienceId == id);
            if (workExperience == null)
            {
                return NotFound();
            }
            ViewData["idUser"] = new SelectList(_context.AppUSers, "Id", "Id", workExperience.idUser);
            return View(workExperience);
        }

        // POST: WorkExperiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkExperienceId,Durée,EndDate,Entreprise,Position,StartDate,idUser,photo")] WorkExperience workExperience)
        {
            if (id != workExperience.WorkExperienceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkExperienceExists(workExperience.WorkExperienceId))
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
            ViewData["idUser"] = new SelectList(_context.AppUSers, "Id", "Id", workExperience.idUser);
            return View(workExperience);
        }

        // GET: WorkExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workExperience = await _context.WorkExperience.SingleOrDefaultAsync(m => m.WorkExperienceId == id);
            if (workExperience == null)
            {
                return NotFound();
            }

            return View(workExperience);
        }

        // POST: WorkExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workExperience = await _context.WorkExperience.SingleOrDefaultAsync(m => m.WorkExperienceId == id);
            _context.WorkExperience.Remove(workExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool WorkExperienceExists(int id)
        {
            return _context.WorkExperience.Any(e => e.WorkExperienceId == id);
        }
    }
}
