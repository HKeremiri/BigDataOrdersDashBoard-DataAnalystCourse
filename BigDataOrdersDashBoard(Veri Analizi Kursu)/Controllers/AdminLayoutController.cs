using Microsoft.AspNetCore.Mvc;

namespace BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
