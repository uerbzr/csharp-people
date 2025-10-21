using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workshop.Data;
using Microsoft.Extensions.Configuration;

namespace workshop.data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory()) // Ensure you're in the correct directory
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseNpgsql(connectionString); 

            return new DataContext(optionsBuilder.Options);
        }
    }
}
