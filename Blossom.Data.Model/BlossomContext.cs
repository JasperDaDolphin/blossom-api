using Microsoft.EntityFrameworkCore;

using Blossom.Data.Model.Users;
using Blossom.Data.Model.StudentProfiles;
using Blossom.Data.Model.BusinessProfiles;

namespace Blossom.Data.Model
{
    public class BlossomContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<StudentProfileEntity> StudentProfiles { get; set; }
        public DbSet<BusinessProfileEntity> BusinessProfiles { get; set; }

        public BlossomContext(DbContextOptions<BlossomContext> options)
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlossomContext).Assembly);
        }
    }
}