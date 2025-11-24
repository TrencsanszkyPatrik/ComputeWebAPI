using Microsoft.EntityFrameworkCore;

namespace ComputerWebAPI.Models
{
    public class ComputerDbContext : DbContext
    {
        public ComputerDbContext() { }

        public ComputerDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Computer> computers { get; set; }
        public DbSet<Os> oses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbulder)
        {
            optionbulder.UseMySQL("server=localhost;database=Computer;user=root;password=");
        }


    }
}
