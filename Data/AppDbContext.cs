using ValiantApp.Models;
using Microsoft.EntityFrameworkCore;


namespace ValiantApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Club> Groups { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
