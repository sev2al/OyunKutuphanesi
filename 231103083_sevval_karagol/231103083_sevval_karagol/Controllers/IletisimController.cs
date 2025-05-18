using _231103083_sevval_karagol.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _231103083_sevval_karagol.Controllers
{
    public class IletisimController : Controller
    {
        private readonly AkkardemoContext _context;

        public IletisimController(AkkardemoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AkkardemoContext DB= new AkkardemoContext();
            var iletisim=DB.Iletisims.ToList();

            return View(iletisim);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Ad,Mail,Telefon,Mesaj")] Iletisimform iletisimform)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iletisimform);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(iletisimform);
        }

    }
}
