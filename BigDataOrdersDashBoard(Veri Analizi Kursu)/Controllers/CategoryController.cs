using BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Context;
using Microsoft.AspNetCore.Mvc;

namespace BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BigDataOrdersDbContext _context;

        public CategoryController(BigDataOrdersDbContext context)
        {
            _context = context;
        }

        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }
    }
}
