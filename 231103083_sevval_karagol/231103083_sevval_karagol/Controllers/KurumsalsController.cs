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
    public class KurumsalsController : Controller
    {
        private readonly AkkardemoContext _context;

        public KurumsalsController(AkkardemoContext context)
        {
            _context = context;
        }

        // GET: Kurumsals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kurumsals.ToListAsync());
        }

        // GET: Kurumsals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurumsal = await _context.Kurumsals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kurumsal == null)
            {
                return NotFound();
            }

            return View(kurumsal);
        }

        // GET: Kurumsals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kurumsals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Aciklama,Fotograf")] Kurumsal kurumsal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kurumsal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kurumsal);
        }

        // GET: Kurumsals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurumsal = await _context.Kurumsals.FindAsync(id);
            if (kurumsal == null)
            {
                return NotFound();
            }
            return View(kurumsal);
        }

        // POST: Kurumsals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Aciklama,Fotograf")] Kurumsal kurumsal)
        {
            if (id != kurumsal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kurumsal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KurumsalExists(kurumsal.Id))
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
            return View(kurumsal);
        }

        // GET: Kurumsals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kurumsal = await _context.Kurumsals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kurumsal == null)
            {
                return NotFound();
            }

            return View(kurumsal);
        }

        // POST: Kurumsals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kurumsal = await _context.Kurumsals.FindAsync(id);
            if (kurumsal != null)
            {
                _context.Kurumsals.Remove(kurumsal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KurumsalExists(int id)
        {
            return _context.Kurumsals.Any(e => e.Id == id);
        }
    }
}
