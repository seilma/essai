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
    public class ResponsesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResponsesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Responses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Response.Include(r => r.Question);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Responses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Response.SingleOrDefaultAsync(m => m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // GET: Responses/Create
        public IActionResult Create()
        {
            ViewData["QuestionId"] = new SelectList(_context.Question, "QuestionId", "QuestionId");
            return View();
        }

        // POST: Responses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponseId,Content,QuestionId,Valide")] Response response)
        {
            if (ModelState.IsValid)
            {
                _context.Add(response);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["QuestionId"] = new SelectList(_context.Question, "QuestionId", "QuestionId", response.QuestionId);
            return View(response);
        }

        // GET: Responses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Response.SingleOrDefaultAsync(m => m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }
            ViewData["QuestionId"] = new SelectList(_context.Question, "QuestionId", "QuestionId", response.QuestionId);
            return View(response);
        }

        // POST: Responses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResponseId,Content,QuestionId,Valide")] Response response)
        {
            if (id != response.ResponseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(response);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponseExists(response.ResponseId))
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
            ViewData["QuestionId"] = new SelectList(_context.Question, "QuestionId", "QuestionId", response.QuestionId);
            return View(response);
        }

        // GET: Responses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _context.Response.SingleOrDefaultAsync(m => m.ResponseId == id);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        // POST: Responses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _context.Response.SingleOrDefaultAsync(m => m.ResponseId == id);
            _context.Response.Remove(response);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ResponseExists(int id)
        {
            return _context.Response.Any(e => e.ResponseId == id);
        }
    }
}
