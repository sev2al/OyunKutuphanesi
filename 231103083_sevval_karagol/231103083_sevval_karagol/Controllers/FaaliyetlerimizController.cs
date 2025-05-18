using _231103083_sevval_karagol.DAL;
using Microsoft.AspNetCore.Mvc;

namespace _231103083_sevval_karagol.Controllers
{
    public class FaaliyetlerimizController : Controller
    {
        [Route("faaliyetlerimiz")]
        public IActionResult Index()
        {
			AkkardemoContext DB = new AkkardemoContext();

            var faaliyetlerimiz = DB.Faaliyetlerimizs.ToList();
            return View(faaliyetlerimiz);
        }
    }
}
