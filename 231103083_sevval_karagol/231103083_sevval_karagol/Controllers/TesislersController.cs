using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _231103083_sevval_karagol.DAL;

namespace _231103083_sevval_karagol.Controllers
{
    public class TesislersController : Controller
    {
        private readonly AkkardemoContext _context;

        public TesislersController(AkkardemoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tesislers.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tesisler = await _context.Tesislers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tesisler == null)
            {
                return NotFound();
            }

            return View(tesisler);
        }

        public IActionResult Create()
        {
            return View();
        }

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Aciklama,Fotograf")] Tesisler tesisler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tesisler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tesisler);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tesisler = await _context.Tesislers.FindAsync(id);
            if (tesisler == null)
            {
                return NotFound();
            }
            return View(tesisler);
        }

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Aciklama,Fotograf")] Tesisler tesisler)
        {
            if (id != tesisler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tesisler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TesislerExists(tesisler.Id))
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
            return View(tesisler);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tesisler = await _context.Tesislers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tesisler == null)
            {
                return NotFound();
            }

            return View(tesisler);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tesisler = await _context.Tesislers.FindAsync(id);
            if (tesisler != null)
            {
                _context.Tesislers.Remove(tesisler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TesislerExists(int id)
        {
            return _context.Tesislers.Any(e => e.Id == id);
        }
    }
}
