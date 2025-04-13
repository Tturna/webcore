using webcore_mvc.Models;
using Microsoft.EntityFrameworkCore;

public class MariaDBContext : DbContext
{
    public MariaDBContext(DbContextOptions<MariaDBContext> options) : base(options) { }

    // Define a DbSet for each model included in this DB context
    // public DbSet<ModelClassName> Jimmies { get; set; }
}
