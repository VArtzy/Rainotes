using app2.Model;
using Microsoft.EntityFrameworkCore;

namespace app2.Data;

public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

    }
    public DbSet<Category> Category { get; set; }
}