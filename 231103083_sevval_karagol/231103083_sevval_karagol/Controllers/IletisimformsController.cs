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
    public class IletisimformsController : Controller
    {
        private readonly AkkardemoContext _context;

        public IletisimformsController(AkkardemoContext context)
        {
            _context = context;
        }

        // GET: Iletisimforms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Iletisimforms.ToListAsync());
        }

        // GET: Iletisimforms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisimform = await _context.Iletisimforms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iletisimform == null)
            {
                return NotFound();
            }

            return View(iletisimform);
        }

        // GET: Iletisimforms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Iletisimforms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Mail,Telefon,Mesaj")] Iletisimform iletisimform)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iletisimform);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iletisimform);
        }

        // GET: Iletisimforms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisimform = await _context.Iletisimforms.FindAsync(id);
            if (iletisimform == null)
            {
                return NotFound();
            }
            return View(iletisimform);
        }

        // POST: Iletisimforms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Mail,Telefon,Mesaj")] Iletisimform iletisimform)
        {
            if (id != iletisimform.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iletisimform);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IletisimformExists(iletisimform.Id))
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
            return View(iletisimform);
        }

        // GET: Iletisimforms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisimform = await _context.Iletisimforms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iletisimform == null)
            {
                return NotFound();
            }

            return View(iletisimform);
        }

        // POST: Iletisimforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iletisimform = await _context.Iletisimforms.FindAsync(id);
            if (iletisimform != null)
            {
                _context.Iletisimforms.Remove(iletisimform);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IletisimformExists(int id)
        {
            return _context.Iletisimforms.Any(e => e.Id == id);
        }
    }
}
