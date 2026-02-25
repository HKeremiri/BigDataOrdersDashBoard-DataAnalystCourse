using BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Context;
using BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly BigDataOrdersDbContext _context;
        public StatisticsController(BigDataOrdersDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.CategoryCount = _context.Categories.Count();
            ViewBag.CustomerCount = _context.Customers.Count();
            ViewBag.ProductCount = _context.Products.Count();
            ViewBag.OrderCount = _context.OrdersAll.Count();
            ViewBag.CustomerCountry = _context.Customers.Select(x => x.CustomerCountry).Distinct().Count();
            ViewBag.CustomerCity = _context.Customers.Select(x => x.CustomerCity).Distinct().Count();

            ViewBag.OrderStatusByCompleted = _context.OrdersAll.Where(x => x.OrderStatus == "Tamamlandı").Count();
            ViewBag.OrderStatusByShipped = _context.OrdersAll.Where(x => x.OrderStatus == "Kargolandı").Count();
            ViewBag.OrderStatusByCancelled = _context.OrdersAll.Where(x => x.OrderStatus == "İptal Edildi").Count();

            ViewBag.October2025OrderCount = _context.OrdersAll.Where(x => x.OrderDate.Month == 10 && x.OrderDate.Year == 2025).Count();
            ViewBag.Orders2025Count = _context.OrdersAll.Where(x => x.OrderDate.Year == 2025).Count();

            ViewBag.AverageProcutPrice = _context.Products.Average(x => x.UnitPrice);
            ViewBag.AverageProductQuantity = _context.Products.Average(x => x.StockQuantity);
            return View();
        }

        public IActionResult TextualStatistics()
        {
            ViewBag.MostExpensiveProduct = _context.Products.OrderByDescending(x => x.UnitPrice).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.CheapestProduct = _context.Products.OrderBy(x => x.UnitPrice).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.MostStockedProduct = _context.Products.OrderByDescending(x => x.StockQuantity).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.LastAddedProduct = _context.Products.OrderByDescending(x => x.ProductId).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.LastAddedCustomer = _context.Customers.OrderByDescending(x => x.CustomerId).Select(x => x.CustomerName +" " +x.CustomerSurname).FirstOrDefault();
            ViewBag.TopPaymentMethod = _context.OrdersAll.GroupBy(x => x.PaymentMethod).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();
            ViewBag.MostOrderedProduct = _context.OrdersAll.GroupBy(x => x.Product.ProductName).Select(x => new
            {
                ProductName = x.Key,
                TotalOrderCount = x.Sum(o => o.Quantity)

            }).OrderByDescending(x => x.TotalOrderCount).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.LeastOrderedProduct = _context.OrdersAll.GroupBy(x => x.Product.ProductName).Select(x => new
            {
                ProductName = x.Key,
                TotalOrderCount = x.Sum(o => o.Quantity)
            }).OrderBy(x => x.TotalOrderCount).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.MostOrderedCounty = _context.OrdersAll.GroupBy(x => x.Customer.CustomerCountry).Select(x => new
            {
                Country = x.Key,
                TotalOrderCount = x.Count()
            }).OrderByDescending(x => x.TotalOrderCount).Select(x => x.Country).FirstOrDefault();
            ViewBag.MostOrderedCity = _context.OrdersAll.GroupBy(x => x.Customer.CustomerCity).Select(x => new
            {
                City = x.Key,
                TotalOrderCount = x.Count()
            }).OrderByDescending(x => x.TotalOrderCount).Select(x => x.City).FirstOrDefault();  
            return View();

        }
    }
}
