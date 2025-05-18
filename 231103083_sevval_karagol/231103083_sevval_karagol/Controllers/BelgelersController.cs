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
    public class BelgelersController : Controller
    {
        private readonly AkkardemoContext _context;

        public BelgelersController(AkkardemoContext context)
        {
            _context = context;
        }

        // GET: Belgelers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Belgelers.ToListAsync());
        }

        // GET: Belgelers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var belgeler = await _context.Belgelers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (belgeler == null)
            {
                return NotFound();
            }

            return View(belgeler);
        }

        // GET: Belgelers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Belgelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Belgeler1,Fotograf")] Belgeler belgeler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(belgeler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(belgeler);
        }

        // GET: Belgelers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var belgeler = await _context.Belgelers.FindAsync(id);
            if (belgeler == null)
            {
                return NotFound();
            }
            return View(belgeler);
        }

        // POST: Belgelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Belgeler1,Fotograf")] Belgeler belgeler)
        {
            if (id != belgeler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(belgeler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BelgelerExists(belgeler.Id))
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
            return View(belgeler);
        }

        // GET: Belgelers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var belgeler = await _context.Belgelers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (belgeler == null)
            {
                return NotFound();
            }

            return View(belgeler);
        }

        // POST: Belgelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var belgeler = await _context.Belgelers.FindAsync(id);
            if (belgeler != null)
            {
                _context.Belgelers.Remove(belgeler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BelgelerExists(int id)
        {
            return _context.Belgelers.Any(e => e.Id == id);
        }
    }
}
