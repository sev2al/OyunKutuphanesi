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
    public class HakkimizdumsController : Controller
    {
        private readonly AkkardemoContext _context;

        public HakkimizdumsController(AkkardemoContext context)
        {
            _context = context;
        }

        [Route("hakkimizda/yonetim")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hakkimizda.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hakkimizdum = await _context.Hakkimizda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hakkimizdum == null)
            {
                return NotFound();
            }

            return View(hakkimizdum);
        }

        public IActionResult Create()
        {
            return View();
        }
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Aciklama,Fotograf")] Hakkimizdum hakkimizdum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hakkimizdum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hakkimizdum);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hakkimizdum = await _context.Hakkimizda.FindAsync(id);
            if (hakkimizdum == null)
            {
                return NotFound();
            }
            return View(hakkimizdum);
        }

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Aciklama,Fotograf")] Hakkimizdum hakkimizdum)
        {
            if (id != hakkimizdum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hakkimizdum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HakkimizdumExists(hakkimizdum.Id))
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
            return View(hakkimizdum);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hakkimizdum = await _context.Hakkimizda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hakkimizdum == null)
            {
                return NotFound();
            }

            return View(hakkimizdum);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hakkimizdum = await _context.Hakkimizda.FindAsync(id);
            if (hakkimizdum != null)
            {
                _context.Hakkimizda.Remove(hakkimizdum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HakkimizdumExists(int id)
        {
            return _context.Hakkimizda.Any(e => e.Id == id);
        }
    }
}
