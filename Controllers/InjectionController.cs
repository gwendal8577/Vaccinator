using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vaccinator.Models;

namespace Injection.Controllers
{
    public class InjectionController : Controller
    {
        private readonly ContexteBDD _context = new ContexteBDD();

        // GET: Injection
        public async Task<IActionResult> Index()
        {
            return View(await _context.Injection.ToListAsync());
        }

        // GET: Injection/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injection = await _context.Injection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (injection == null)
            {
                return NotFound();
            }

            return View(injection);
        }

        // GET: Injection/Create
        public IActionResult Create()
        {
            ViewData["listeDesVaccins"] = new SelectList(_context.Vaccin, "Id", "Nom");
            ViewData["listeDesPersonnes"] = new SelectList(_context.Personne, "Id", "Nom");

            return View();
        }

        // POST: Injection/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Marque,NumeroLot,Date,DateRappel,Personne,Vaccin")] Vaccinator.Models.Injection injection, int Vaccin, int Personne)
        {
            var vaccin = await _context.Vaccin.FindAsync(Vaccin);
            var personne = await _context.Personne.FindAsync(Personne);

            injection.Vaccin = vaccin;
            injection.Personne = personne;

            ModelState.Clear();
            TryValidateModel(injection);

            if (ModelState.IsValid)
            {
                _context.Add(injection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["listeDesVaccins"] = new SelectList(_context.Vaccin, "Id", "Nom");
            ViewData["listeDesPersonnes"] = new SelectList(_context.Personne, "Id", "Nom");

            return View(injection);
        }

        // GET: Injection/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injection = await _context.Injection.FindAsync(id);
            if (injection == null)
            {
                return NotFound();
            }
            return View(injection);
        }

        // POST: Injection/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Marque,NumeroLot,Date,DateRappel,Vaccin,Personne")] Vaccinator.Models.Injection injection)
        {
            if (id != injection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(injection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieExists(injection.Id))
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
            return View(injection);
        }

        // GET: Injection/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injection = await _context.Injection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (injection == null)
            {
                return NotFound();
            }

            return View(injection);
        }

        // POST: Injection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var injection = await _context.Injection.FindAsync(id);
            _context.Injection.Remove(injection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieExists(int id)
        {
            return _context.Injection.Any(e => e.Id == id);
        }
    }
}
