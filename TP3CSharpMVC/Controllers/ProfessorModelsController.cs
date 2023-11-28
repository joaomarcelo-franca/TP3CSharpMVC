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
    public class ProfessorModelsController : Controller
    {
        private readonly FilaFiesDbContext _context;

        public ProfessorModelsController(FilaFiesDbContext context)
        {
            _context = context;
        }

        // GET: ProfessorModels
        public async Task<IActionResult> Index()
        {
              return _context.ProfessorModel != null ? 
                          View(await _context.ProfessorModel.ToListAsync()) :
                          Problem("Entity set 'FilaFiesDbContext.ProfessorModel'  is null.");
        }

        // GET: ProfessorModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProfessorModel == null)
            {
                return NotFound();
            }

            var professorModel = await _context.ProfessorModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professorModel == null)
            {
                return NotFound();
            }

            return View(professorModel);
        }

        // GET: ProfessorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfessorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Materia")] ProfessorModel professorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professorModel);
        }

        // GET: ProfessorModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProfessorModel == null)
            {
                return NotFound();
            }

            var professorModel = await _context.ProfessorModel.FindAsync(id);
            if (professorModel == null)
            {
                return NotFound();
            }
            return View(professorModel);
        }

        // POST: ProfessorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Materia")] ProfessorModel professorModel)
        {
            if (id != professorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorModelExists(professorModel.Id))
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
            return View(professorModel);
        }

        // GET: ProfessorModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProfessorModel == null)
            {
                return NotFound();
            }

            var professorModel = await _context.ProfessorModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professorModel == null)
            {
                return NotFound();
            }

            return View(professorModel);
        }

        // POST: ProfessorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProfessorModel == null)
            {
                return Problem("Entity set 'FilaFiesDbContext.ProfessorModel'  is null.");
            }
            var professorModel = await _context.ProfessorModel.FindAsync(id);
            if (professorModel != null)
            {
                _context.ProfessorModel.Remove(professorModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorModelExists(int id)
        {
          return (_context.ProfessorModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
