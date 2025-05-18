using _231103083_sevval_karagol.DAL;
using Microsoft.AspNetCore.Mvc;

namespace _231103083_sevval_karagol.Controllers
{
    public class DuyurularController : Controller
    {
        public IActionResult Index()
        {

			AkkardemoContext DB = new AkkardemoContext();
            var duyurular =DB.Duyurulars.ToList();
            
			return View(duyurular);
        }
    }
}
