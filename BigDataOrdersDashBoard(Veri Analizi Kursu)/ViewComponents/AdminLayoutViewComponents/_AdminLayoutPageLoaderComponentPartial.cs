using Microsoft.AspNetCore.Mvc;

namespace BigDataOrdersDashBoard_Veri_Analizi_Kursu_.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutPageLoaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
