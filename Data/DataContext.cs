using Microsoft.EntityFrameworkCore;

namespace mba.Articles {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Producte> Productes { get; set; }
    }
}