using BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Entities;
using Microsoft.EntityFrameworkCore;

namespace BigDataOrdersDashBoard_Veri_Analizi_Kursu_.Context
{
    public class BigDataOrdersDbContext : DbContext
    {
        public BigDataOrdersDbContext(DbContextOptions<BigDataOrdersDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderAll> OrdersAll { get; set; }
    }
}
