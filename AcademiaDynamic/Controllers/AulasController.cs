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
    public class AulasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public AulasController(AppDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        // GET: Aulas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aulas.ToListAsync());
        }

        // GET: Aulas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        // GET: Aulas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aulas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Image")] Aula aula, IFormFile arquivo)
        {

                 aula.Image = "...";
               _context.Add(aula);
                await _context.SaveChangesAsync();

                if (arquivo != null)
                {
                    string nomeArquivo = aula.Id + Path.GetExtension(arquivo.FileName);
                    string caminho = Path.Combine(_webHost.WebRootPath, "img\\services");
                    string novoArquivo = Path.Combine(caminho, nomeArquivo);
                    using (var stream = new FileStream(novoArquivo, FileMode.Create))
                    {
                        arquivo.CopyTo(stream);
                    }
                    aula.Image = "\\img\\services\\" + nomeArquivo;
                    await _context.SaveChangesAsync();
                }

            return View(aula);
        }

        // GET: Aulas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas.FindAsync(id);
            if (aula == null)
            {
                return NotFound();
            }
            return View(aula);
        }

        // POST: Aulas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Image")] Aula aula , IFormFile arquivo)

        {
            if (id != aula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (arquivo != null)
                    {
                        string nomeArquivo = aula.Id + Path.GetExtension(arquivo.FileName);
                        string caminho = Path.Combine(_webHost.WebRootPath, "img\\services");
                        string novoArquivo = Path.Combine(caminho, nomeArquivo);
                        using (var stream = new FileStream(novoArquivo, FileMode.Create))
                        {
                            arquivo.CopyTo(stream);
                        }
                        aula.Image = "\\img\\services\\" + nomeArquivo;
                    }
                    _context.Update(aula);
                    await _context.SaveChangesAsync();

                    {
                    _context.Update(aula);
                    await _context.SaveChangesAsync();

                    }

                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!AulaExists(aula.Id))
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
            return View(aula);
        }

        // GET: Aulas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aula = await _context.Aulas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aula == null)
            {
                return NotFound();
            }

            return View(aula);
        }

        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aula = await _context.Aulas.FindAsync(id);
            if (aula != null)
            {
                _context.Aulas.Remove(aula);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AulaExists(int id)
        {
            return _context.Aulas.Any(e => e.Id == id);
        }
    }
}
