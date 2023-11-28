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
    public class AlunoModelsController : Controller
    {
        private readonly FilaFiesDbContext _context;

        public AlunoModelsController(FilaFiesDbContext context)
        {
            _context = context;
        }

        // GET: AlunoModels
        public async Task<IActionResult> Index()
        {
              return _context.Alunos != null ? 
                          View(await _context.Alunos.ToListAsync()) :
                          Problem("Entity set 'FilaFiesDbContext.Alunos'  is null.");
        }

        // GET: AlunoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alunos == null)
            {
                return NotFound();
            }

            var alunoModel = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoModel == null)
            {
                return NotFound();
            }

            return View(alunoModel);
        }

        // GET: AlunoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlunoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Matricula,Idade")] AlunoModel alunoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alunoModel);
        }

        // GET: AlunoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alunos == null)
            {
                return NotFound();
            }

            var alunoModel = await _context.Alunos.FindAsync(id);
            if (alunoModel == null)
            {
                return NotFound();
            }
            return View(alunoModel);
        }

        // POST: AlunoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Matricula,Idade")] AlunoModel alunoModel)
        {
            if (id != alunoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoModelExists(alunoModel.Id))
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
            return View(alunoModel);
        }

        // GET: AlunoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alunos == null)
            {
                return NotFound();
            }

            var alunoModel = await _context.Alunos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoModel == null)
            {
                return NotFound();
            }

            return View(alunoModel);
        }

        // POST: AlunoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alunos == null)
            {
                return Problem("Entity set 'FilaFiesDbContext.Alunos'  is null.");
            }
            var alunoModel = await _context.Alunos.FindAsync(id);
            if (alunoModel != null)
            {
                _context.Alunos.Remove(alunoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoModelExists(int id)
        {
          return (_context.Alunos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
