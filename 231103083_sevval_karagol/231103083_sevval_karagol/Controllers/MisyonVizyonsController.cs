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
    public class MisyonVizyonsController : Controller
    {
        private readonly AkkardemoContext _context;

        public MisyonVizyonsController(AkkardemoContext context)
        {
            _context = context;
        }

        // GET: MisyonVizyons
        public async Task<IActionResult> Index()
        {
            return View(await _context.MisyonVizyons.ToListAsync());
        }

        // GET: MisyonVizyons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misyonVizyon = await _context.MisyonVizyons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (misyonVizyon == null)
            {
                return NotFound();
            }

            return View(misyonVizyon);
        }

        // GET: MisyonVizyons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MisyonVizyons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Misyon,Vizyon")] MisyonVizyon misyonVizyon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(misyonVizyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(misyonVizyon);
        }

        // GET: MisyonVizyons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misyonVizyon = await _context.MisyonVizyons.FindAsync(id);
            if (misyonVizyon == null)
            {
                return NotFound();
            }
            return View(misyonVizyon);
        }

        // POST: MisyonVizyons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Misyon,Vizyon")] MisyonVizyon misyonVizyon)
        {
            if (id != misyonVizyon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(misyonVizyon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MisyonVizyonExists(misyonVizyon.Id))
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
            return View(misyonVizyon);
        }

        // GET: MisyonVizyons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var misyonVizyon = await _context.MisyonVizyons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (misyonVizyon == null)
            {
                return NotFound();
            }

            return View(misyonVizyon);
        }

        // POST: MisyonVizyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var misyonVizyon = await _context.MisyonVizyons.FindAsync(id);
            if (misyonVizyon != null)
            {
                _context.MisyonVizyons.Remove(misyonVizyon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MisyonVizyonExists(int id)
        {
            return _context.MisyonVizyons.Any(e => e.Id == id);
        }
    }
}
