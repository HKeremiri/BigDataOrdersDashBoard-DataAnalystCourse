using System.Diagnostics;
using BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Models;
using Microsoft.AspNetCore.Mvc;

namespace BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
