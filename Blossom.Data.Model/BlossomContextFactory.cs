using Blossom.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Blossom.Data.Model
{
    public class BlossomContextFactory : IDesignTimeDbContextFactory<BlossomContext>
    { 
        public BlossomContextFactory() {}

        public BlossomContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlossomContext>();
            var serverVersion = new MySqlServerVersion("8.0.20");
            optionsBuilder.UseMySql("server=localhost;port=3306;database=blossom.careers;user=root;password=", serverVersion);

			return new BlossomContext(optionsBuilder.Options);
        }
    }
}
