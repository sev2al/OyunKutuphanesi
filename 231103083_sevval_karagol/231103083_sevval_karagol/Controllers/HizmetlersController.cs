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
    public class HizmetlersController : Controller
    {
        private readonly AkkardemoContext _context;

        public HizmetlersController(AkkardemoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Hizmetlers.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizmetler = await _context.Hizmetlers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hizmetler == null)
            {
                return NotFound();
            }

            return View(hizmetler);
        }

        public IActionResult Create()
        {
            return View();
        }

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Fotograf")] Hizmetler hizmetler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hizmetler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hizmetler);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizmetler = await _context.Hizmetlers.FindAsync(id);
            if (hizmetler == null)
            {
                return NotFound();
            }
            return View(hizmetler);
        }

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Fotograf")] Hizmetler hizmetler)
        {
            if (id != hizmetler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hizmetler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HizmetlerExists(hizmetler.Id))
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
            return View(hizmetler);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hizmetler = await _context.Hizmetlers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hizmetler == null)
            {
                return NotFound();
            }

            return View(hizmetler);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hizmetler = await _context.Hizmetlers.FindAsync(id);
            if (hizmetler != null)
            {
                _context.Hizmetlers.Remove(hizmetler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HizmetlerExists(int id)
        {
            return _context.Hizmetlers.Any(e => e.Id == id);
        }
    }
}
