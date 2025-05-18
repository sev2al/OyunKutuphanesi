using _231103083_sevval_karagol.DAL;
using Microsoft.AspNetCore.Mvc;

namespace _231103083_sevval_karagol.Controllers
{
    public class HakkimizdaController : Controller
    {
        public IActionResult Index()
        {
			AkkardemoContext DB = new AkkardemoContext();
            var hakkimizda =DB.Hakkimizda.ToList();
            var mv = DB.MisyonVizyons.FirstOrDefault();
            ViewData["MisyonVizyon"] = mv;
			return View(hakkimizda);

        }
    }
}
