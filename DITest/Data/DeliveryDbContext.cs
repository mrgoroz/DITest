using DITest.Models;
using Microsoft.EntityFrameworkCore;

namespace DITest.Data
{
    public class DeliveryDbContext:DbContext
    {
        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options):
            base(options)
        {

        }
        public DbSet<Delivery> Delivery { get; set; }
    }
}
