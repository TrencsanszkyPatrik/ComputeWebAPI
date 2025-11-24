using Microsoft.EntityFrameworkCore;

namespace ComputerWebAPI.Models
{
    public class ComputerDbContext : DbContext
    {
        public class ComputerDbContext()
        {

        }

        public ComputerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Computer> Computers { get; set; }
    }
}
