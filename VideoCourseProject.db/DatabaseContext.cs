using Microsoft.EntityFrameworkCore;
using VideoCourseProject.db.Models;

namespace VideoCourseProject.db;

public class DatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
