using Microsoft.EntityFrameworkCore;
using Mvc.Movie.Models;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class ApplicationDbContext    : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {}
        public DbSet<Person> Person {get; set;}
         public DbSet<HeThongPhanPhoi> HeThongPhanPhoi {get; set;}
    }
}