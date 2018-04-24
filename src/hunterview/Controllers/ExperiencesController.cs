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
    public class ExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExperiencesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Experiences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Experience.Include(e => e.Jobseeker).Include(e => e.Speciality);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Experiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience.SingleOrDefaultAsync(m => m.ExperienceId == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // GET: Experiences/Create
        public IActionResult Create()
        {
            ViewData["userId"] = new SelectList(_context.AppUSers, "Id", "Id");
            ViewData["SpecialityId"] = new SelectList(_context.Speciality, "SpecialityId", "SpecialityId");
            return View();
        }

        // POST: Experiences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExperienceId,AddDate,Note,SpecialityId,Valid,userId")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experience);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["userId"] = new SelectList(_context.AppUSers, "Id", "Id", experience.userId);
            ViewData["SpecialityId"] = new SelectList(_context.Speciality, "SpecialityId", "SpecialityId", experience.SpecialityId);
            return View(experience);
        }

        // GET: Experiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience.SingleOrDefaultAsync(m => m.ExperienceId == id);
            if (experience == null)
            {
                return NotFound();
            }
            ViewData["userId"] = new SelectList(_context.AppUSers, "Id", "Id", experience.userId);
            ViewData["SpecialityId"] = new SelectList(_context.Speciality, "SpecialityId", "SpecialityId", experience.SpecialityId);
            return View(experience);
        }

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExperienceId,AddDate,Note,SpecialityId,Valid,userId")] Experience experience)
        {
            if (id != experience.ExperienceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceExists(experience.ExperienceId))
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
            ViewData["userId"] = new SelectList(_context.AppUSers, "Id", "Id", experience.userId);
            ViewData["SpecialityId"] = new SelectList(_context.Speciality, "SpecialityId", "SpecialityId", experience.SpecialityId);
            return View(experience);
        }

        // GET: Experiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience.SingleOrDefaultAsync(m => m.ExperienceId == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experience = await _context.Experience.SingleOrDefaultAsync(m => m.ExperienceId == id);
            _context.Experience.Remove(experience);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experience.Any(e => e.ExperienceId == id);
        }
    }
}
