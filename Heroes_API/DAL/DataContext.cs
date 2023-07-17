using Heroes_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Heroes_API.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }
        public DbSet<Hero> Heroes { get; set; }
    }
}
