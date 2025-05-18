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
    public class FaaliyetlerimizsController : Controller
    {
        private readonly AkkardemoContext _context;

        public FaaliyetlerimizsController(AkkardemoContext context)
        {
            _context = context;
        }

        // GET: Faaliyetlerimizs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Faaliyetlerimizs.ToListAsync());
        }

        // GET: Faaliyetlerimizs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faaliyetlerimiz = await _context.Faaliyetlerimizs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faaliyetlerimiz == null)
            {
                return NotFound();
            }

            return View(faaliyetlerimiz);
        }

        // GET: Faaliyetlerimizs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faaliyetlerimizs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Aciklama,Fotograf,FotografBaslik")] Faaliyetlerimiz faaliyetlerimiz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faaliyetlerimiz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faaliyetlerimiz);
        }

        // GET: Faaliyetlerimizs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faaliyetlerimiz = await _context.Faaliyetlerimizs.FindAsync(id);
            if (faaliyetlerimiz == null)
            {
                return NotFound();
            }
            return View(faaliyetlerimiz);
        }

        // POST: Faaliyetlerimizs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Aciklama,Fotograf,FotografBaslik")] Faaliyetlerimiz faaliyetlerimiz)
        {
            if (id != faaliyetlerimiz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faaliyetlerimiz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaaliyetlerimizExists(faaliyetlerimiz.Id))
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
            return View(faaliyetlerimiz);
        }

        // GET: Faaliyetlerimizs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faaliyetlerimiz = await _context.Faaliyetlerimizs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faaliyetlerimiz == null)
            {
                return NotFound();
            }

            return View(faaliyetlerimiz);
        }

        // POST: Faaliyetlerimizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var faaliyetlerimiz = await _context.Faaliyetlerimizs.FindAsync(id);
            if (faaliyetlerimiz != null)
            {
                _context.Faaliyetlerimizs.Remove(faaliyetlerimiz);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FaaliyetlerimizExists(int id)
        {
            return _context.Faaliyetlerimizs.Any(e => e.Id == id);
        }
    }
}
