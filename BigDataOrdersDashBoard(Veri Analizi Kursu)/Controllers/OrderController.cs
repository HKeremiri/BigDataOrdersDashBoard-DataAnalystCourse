using BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Controllers
{
    public class OrderController : Controller
    {
        private readonly BigDataOrdersDbContext _context;
        public OrderController(BigDataOrdersDbContext context)
        {
            _context = context;
        }

        public IActionResult OrderList(int page = 1)
        {
            //  var values = _context.Orders.ToList();
            // return View(values);
            int pageSize = 12; // Sayfa başına gösterilecek ürün sayısı
            var Orders = _context.OrdersAll
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(o => o.Product) // Ürün bilgilerini dahil et
                .Include(o => o.Customer) // Müşteri bilgilerini dahil et
                .ToList();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)_context.OrdersAll.Count() / pageSize);
            return View(Orders);
        }
    }
}
