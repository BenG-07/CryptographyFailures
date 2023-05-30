using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CryptographicFailure_Backend;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
