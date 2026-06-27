using API.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Activity> Activities { get; set; }
}
