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
    public class FavoritesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FavoritesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Favorites
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Favorite.Include(f => f.Company).Include(f => f.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Favorites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorite.SingleOrDefaultAsync(m => m.FavoriteId == id);
            if (favorite == null)
            {
                return NotFound();
            }

            return View(favorite);
        }

        // GET: Favorites/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId");
            ViewData["UserId"] = new SelectList(_context.AppUSers, "Id", "Id");
            return View();
        }

        // POST: Favorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FavoriteId,CompanyId,UserId")] Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorite);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", favorite.CompanyId);
            ViewData["UserId"] = new SelectList(_context.AppUSers, "Id", "Id", favorite.UserId);
            return View(favorite);
        }

        // GET: Favorites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorite.SingleOrDefaultAsync(m => m.FavoriteId == id);
            if (favorite == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", favorite.CompanyId);
            ViewData["UserId"] = new SelectList(_context.AppUSers, "Id", "Id", favorite.UserId);
            return View(favorite);
        }

        // POST: Favorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavoriteId,CompanyId,UserId")] Favorite favorite)
        {
            if (id != favorite.FavoriteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoriteExists(favorite.FavoriteId))
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
            ViewData["CompanyId"] = new SelectList(_context.Company, "CompanyId", "CompanyId", favorite.CompanyId);
            ViewData["UserId"] = new SelectList(_context.AppUSers, "Id", "Id", favorite.UserId);
            return View(favorite);
        }

        // GET: Favorites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favorite = await _context.Favorite.SingleOrDefaultAsync(m => m.FavoriteId == id);
            if (favorite == null)
            {
                return NotFound();
            }

            return View(favorite);
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favorite = await _context.Favorite.SingleOrDefaultAsync(m => m.FavoriteId == id);
            _context.Favorite.Remove(favorite);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FavoriteExists(int id)
        {
            return _context.Favorite.Any(e => e.FavoriteId == id);
        }
    }
}
