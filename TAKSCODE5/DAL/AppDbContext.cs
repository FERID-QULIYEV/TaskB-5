using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using TAKSCODE5.Models;

namespace TAKSCODE5.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Pozition> Pozitions{ get; set; }
    }
}
