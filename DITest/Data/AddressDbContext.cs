using DITest.Models;
using Microsoft.EntityFrameworkCore;

namespace DITest.Data
{
    public class AddressDbContext:DbContext
    {
        public AddressDbContext(DbContextOptions<AddressDbContext> options):
            base(options)
        {

        }
        public DbSet<Address> Address { get; set; }
    }
}
