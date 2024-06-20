using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademiaDynamic.Data;
using AcademiaDynamic.Models;
using Microsoft.AspNetCore.Authorization;

namespace AcademiaDynamic.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PlanosController : Controller
    {
        private readonly AppDbContext _context;

        public PlanosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Planos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planos.ToListAsync());
        }

        // GET: Planos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Planos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // GET: Planos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plano);
        }

        // GET: Planos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Planos.FindAsync(id);
            if (plano == null)
            {
                return NotFound();
            }
            return View(plano);
        }

        // POST: Planos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Plano plano)
        {
            if (id != plano.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoExists(plano.Id))
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
            return View(plano);
        }

        // GET: Planos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Planos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // POST: Planos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plano = await _context.Planos.FindAsync(id);
            if (plano != null)
            {
                _context.Planos.Remove(plano);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoExists(int id)
        {
            return _context.Planos.Any(e => e.Id == id);
        }
    }
}
