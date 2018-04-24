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
    public class AnswersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnswersController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Answers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Answer.Include(a => a.Response).Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Answers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer.SingleOrDefaultAsync(m => m.AnswerId == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // GET: Answers/Create
        public IActionResult Create()
        {
            ViewData["IdResponse"] = new SelectList(_context.Response, "ResponseId", "ResponseId");
            ViewData["IdUser"] = new SelectList(_context.AppUSers, "Id", "Id");
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnswerId,IdResponse,IdUser")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(answer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IdResponse"] = new SelectList(_context.Response, "ResponseId", "ResponseId", answer.IdResponse);
            ViewData["IdUser"] = new SelectList(_context.AppUSers, "Id", "Id", answer.IdUser);
            return View(answer);
        }

        // GET: Answers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer.SingleOrDefaultAsync(m => m.AnswerId == id);
            if (answer == null)
            {
                return NotFound();
            }
            ViewData["IdResponse"] = new SelectList(_context.Response, "ResponseId", "ResponseId", answer.IdResponse);
            ViewData["IdUser"] = new SelectList(_context.AppUSers, "Id", "Id", answer.IdUser);
            return View(answer);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnswerId,IdResponse,IdUser")] Answer answer)
        {
            if (id != answer.AnswerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(answer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswerExists(answer.AnswerId))
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
            ViewData["IdResponse"] = new SelectList(_context.Response, "ResponseId", "ResponseId", answer.IdResponse);
            ViewData["IdUser"] = new SelectList(_context.AppUSers, "Id", "Id", answer.IdUser);
            return View(answer);
        }

        // GET: Answers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answer = await _context.Answer.SingleOrDefaultAsync(m => m.AnswerId == id);
            if (answer == null)
            {
                return NotFound();
            }

            return View(answer);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var answer = await _context.Answer.SingleOrDefaultAsync(m => m.AnswerId == id);
            _context.Answer.Remove(answer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AnswerExists(int id)
        {
            return _context.Answer.Any(e => e.AnswerId == id);
        }
    }
}
