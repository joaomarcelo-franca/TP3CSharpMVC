using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3CSharpMVC.Models;

namespace TP3CSharpMVC.Controllers
{
    public class CursoModelsController : Controller
    {
        private readonly FilaFiesDbContext _context;

        public CursoModelsController(FilaFiesDbContext context)
        {
            _context = context;
        }

        // GET: CursoModels
        public async Task<IActionResult> Index()
        {
              return _context.Cursos != null ? 
                          View(await _context.Cursos.ToListAsync()) :
                          Problem("Entity set 'FilaFiesDbContext.Cursos'  is null.");
        }

        // GET: CursoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var cursoModel = await _context.Cursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoModel == null)
            {
                return NotFound();
            }

            return View(cursoModel);
        }

        // GET: CursoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CursoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DuracaoEmMeses,Nome")] CursoModel cursoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cursoModel);
        }

        // GET: CursoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var cursoModel = await _context.Cursos.FindAsync(id);
            if (cursoModel == null)
            {
                return NotFound();
            }
            return View(cursoModel);
        }

        // POST: CursoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DuracaoEmMeses,Nome")] CursoModel cursoModel)
        {
            if (id != cursoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cursoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoModelExists(cursoModel.Id))
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
            return View(cursoModel);
        }

        // GET: CursoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cursos == null)
            {
                return NotFound();
            }

            var cursoModel = await _context.Cursos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cursoModel == null)
            {
                return NotFound();
            }

            return View(cursoModel);
        }

        // POST: CursoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cursos == null)
            {
                return Problem("Entity set 'FilaFiesDbContext.Cursos'  is null.");
            }
            var cursoModel = await _context.Cursos.FindAsync(id);
            if (cursoModel != null)
            {
                _context.Cursos.Remove(cursoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoModelExists(int id)
        {
          return (_context.Cursos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
