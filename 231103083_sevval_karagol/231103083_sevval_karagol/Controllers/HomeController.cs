using _231103083_sevval_karagol.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _231103083_sevval_karagol.DAL;

namespace _231103083_sevval_karagol.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            AkkardemoContext DB= new AkkardemoContext();

            var hiz = DB.Hizmetlers.ToList();
            var ilt = DB.Iletisims.ToList();  
            var tesis = DB.Tesislers.ToList();
            var hakkimizda = DB.Hakkimizda.ToList();
            ViewData["Hakkimizda"] = hakkimizda;
            ViewData["Tesisler"] = tesis;
            
            indexmodel m=new indexmodel();
            m.Iletisims = ilt;
            m.Tesislers = tesis;
            m.Hizmetlers = hiz;


            return View(hiz);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
