﻿using AmericanGirlLookup.Data;
using AmericanGirlLookup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmericanGirlLookup.Controllers
{
    public class DollsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DollsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dolls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doll.ToListAsync());
        }

        // GET: Dolls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doll = await _context.Doll
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doll == null)
            {
                return NotFound();
            }

            return View(doll);
        }

        // GET: Dolls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DollName,ReleaseDate,RetirementDate,CharacterType,Collection,OriginalPrice,CurrentValue,OwningCompany,ImagePath")] Doll doll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doll);
        }

        // GET: Dolls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doll = await _context.Doll.FindAsync(id);
            if (doll == null)
            {
                return NotFound();
            }
            return View(doll);
        }

        // POST: Dolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DollName,ReleaseDate,RetirementDate,CharacterType,Collection,OriginalPrice,CurrentValue,OwningCompany,ImagePath")] Doll doll)
        {
            if (id != doll.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DollExists(doll.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(doll);
        }

        // GET: Dolls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doll = await _context.Doll
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doll == null)
            {
                return NotFound();
            }

            return View(doll);
        }

        // POST: Dolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doll = await _context.Doll.FindAsync(id);
            if (doll != null)
            {
                _context.Doll.Remove(doll);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DollExists(int id)
        {
            return _context.Doll.Any(e => e.Id == id);
        }
    }
}
