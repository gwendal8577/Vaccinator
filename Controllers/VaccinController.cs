using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vaccinator.Models;

namespace Vaccin.Controllers
{
    public class VaccinController : Controller
    {
        private readonly ContexteBDD _context = new ContexteBDD();

        // GET: Vaccin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vaccin.ToListAsync());
        }

        // GET: Vaccin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccin = await _context.Vaccin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccin == null)
            {
                return NotFound();
            }

            return View(vaccin);
        }

        // GET: Vaccin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vaccin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom")] Vaccinator.Models.Vaccin vaccin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaccin);
        }

        // GET: Vaccin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccin = await _context.Vaccin.FindAsync(id);
            if (vaccin == null)
            {
                return NotFound();
            }
            return View(vaccin);
        }

        // POST: Vaccin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] Vaccinator.Models.Vaccin vaccin)
        {
            if (id != vaccin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieExists(vaccin.Id))
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
            return View(vaccin);
        }

        // GET: Vaccin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccin = await _context.Vaccin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaccin == null)
            {
                return NotFound();
            }

            return View(vaccin);
        }

        // POST: Vaccin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccin = await _context.Vaccin.FindAsync(id);
            _context.Vaccin.Remove(vaccin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(int id)
        {
            return _context.Vaccin.Any(e => e.Id == id);
        }
    }
}
