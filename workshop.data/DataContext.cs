using Microsoft.EntityFrameworkCore;
using workshop.models;

namespace workshop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }        
        public DbSet<Person> People { get; set; }
    }
}
