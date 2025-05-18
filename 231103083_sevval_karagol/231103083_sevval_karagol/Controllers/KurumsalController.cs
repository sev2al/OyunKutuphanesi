using _231103083_sevval_karagol.DAL;
using Microsoft.AspNetCore.Mvc;

namespace _231103083_sevval_karagol.Controllers
{
    public class KurumsalController : Controller
    {
        public IActionResult Index()
        {

			AkkardemoContext DB = new AkkardemoContext();
            var belgeler=DB.Belgelers.ToList();
            var kurumsal = DB.Kurumsals.SingleOrDefault();
            ViewData["kurumsal"] = kurumsal;
           

            return View(belgeler);



        }
    }
}
