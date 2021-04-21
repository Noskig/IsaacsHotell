using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsaacsHotell.Data;
using IsaacsHotell.Models;

namespace IsaacsHotell.Controllers
{
    public class BokningsController : Controller
    {
        private readonly HotellDbContext _context;

        public BokningsController(HotellDbContext context)
        {
            _context = context;
        }

        // GET: Boknings
        public async Task<IActionResult> Index()
        {
            var hotellDbContext = _context.Bokningar.Include(b => b.Gäst).Include(b => b.Rum);
            return View(await hotellDbContext.ToListAsync());
        }

        // GET: Boknings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bokning = await _context.Bokningar
                .Include(b => b.Gäst)
                .Include(b => b.Rum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bokning == null)
            {
                return NotFound();
            }

            return View(bokning);
        }

        // GET: Boknings/Create
        public IActionResult Create()
        {
            ViewData["GästId"] = new SelectList(_context.Gäster, "Id", "Id");
            ViewData["RumId"] = new SelectList(_context.Rum, "Id", "Id");
            return View();
        }

        // POST: Boknings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Incheckning,Utcheckning,GästId,RumId")] Bokning bokning)
        {
            if (ModelState.IsValid) //kommer inte in här när jag försöker skapa. Nått med relationen i db som är fuckad
            {
                _context.Add(bokning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GästId"] = new SelectList(_context.Gäster, "Id", "Id", bokning.GästId);
            ViewData["RumId"] = new SelectList(_context.Rum, "Id", "Id", bokning.RumId);
            return View(bokning);
        }

        // GET: Boknings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bokning = await _context.Bokningar.FindAsync(id);
            if (bokning == null)
            {
                return NotFound();
            }
            ViewData["GästId"] = new SelectList(_context.Gäster, "Id", "Id", bokning.GästId);
            ViewData["RumId"] = new SelectList(_context.Rum, "Id", "Id", bokning.RumId);
            return View(bokning);
        }

        // POST: Boknings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Incheckning,Utcheckning,GästId,RumId")] Bokning bokning)
        {
            if (id != bokning.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bokning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BokningExists(bokning.Id))
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
            ViewData["GästId"] = new SelectList(_context.Gäster, "Id", "Id", bokning.GästId);
            ViewData["RumId"] = new SelectList(_context.Rum, "Id", "Id", bokning.RumId);
            return View(bokning);
        }

        // GET: Boknings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bokning = await _context.Bokningar
                .Include(b => b.Gäst)
                .Include(b => b.Rum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bokning == null)
            {
                return NotFound();
            }

            return View(bokning);
        }

        // POST: Boknings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bokning = await _context.Bokningar.FindAsync(id);
            _context.Bokningar.Remove(bokning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BokningExists(int id)
        {
            return _context.Bokningar.Any(e => e.Id == id);
        }
    }
}
