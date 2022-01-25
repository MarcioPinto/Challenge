using Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace challenge
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
