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
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Blossom;Username=postgres;Password=password");

            return new BlossomContext(optionsBuilder.Options);
        }
    }
}
