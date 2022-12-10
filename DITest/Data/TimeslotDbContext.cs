using DITest.Models;
using Microsoft.EntityFrameworkCore;

namespace DITest.Data
{
    public class TimeslotDbContext:DbContext
    {
        public TimeslotDbContext(DbContextOptions<TimeslotDbContext> options):
            base(options)
        {

        }
        public DbSet<Timeslot> Timeslot { get; set; }
    }
}
