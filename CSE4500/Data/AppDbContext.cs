using Microsoft.EntityFrameworkCore;
using CSE4050_SignIn.Models;
namespace CSE4050_SignIn.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) :
   base(options)
    { }
    public DbSet<User> Users => Set<User>();
}