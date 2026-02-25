using BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Controllers
{
    public class ProductController : Controller
    {
        private readonly BigDataOrdersDbContext _context;

        public ProductController(BigDataOrdersDbContext context)
        {
            _context = context;
        }

        public IActionResult ProductList(int page = 1)
        {
          //  var values = _context.Products.ToList();
           // return View(values);
           int pageSize = 12; // Sayfa başına gösterilecek ürün sayısı
            var products = _context.Products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(p => p.Category)
                .ToList();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)_context.Products.Count() / pageSize);
            return View(products);
        }
    }
}
