
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext() { }
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public virtual DbSet<ImageItem> Images { get; set; }
        public DbSet<CategoryItem> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ImageItem>(entity => {
                entity.ToTable("Images");
            });

            builder.Entity<CategoryItem>(entity => {
                entity.ToTable("Categories");
                entity.HasKey(c => c.IdCategory);
                entity.HasMany(c => c.Images)
                      .WithOne(c => c.CategoryItem)
                      .HasForeignKey(c => c.CategoryItemId);

            });

                }
    }
    public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("ServiceContext");
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));

            return new ServiceContext(optionsBuilder.Options);
        }
    }
}
