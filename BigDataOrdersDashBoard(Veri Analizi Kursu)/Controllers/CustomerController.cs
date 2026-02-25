using BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Context;
using Microsoft.AspNetCore.Mvc;

namespace BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Controllers
{
    public class CustomerController : Controller
    {
        private readonly BigDataOrdersDbContext _context;

        public CustomerController(BigDataOrdersDbContext context)
        {
            _context = context;
        }

        public IActionResult CustomerList(int page = 1)
        {
            //  var values = _context.Customers.ToList();
            // return View(values);
            int pageSize = 12; // Sayfa başına gösterilecek müşteri sayısı
            var Customers = _context.Customers
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)_context.Customers.Count() / pageSize);
            return View(Customers);
        }
    }
}
