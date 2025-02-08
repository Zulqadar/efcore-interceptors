using InterceptorsEFCore.Interceptors;
using InterceptorsEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace InterceptorsEFCore.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings here (if needed)
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new LoggingInterceptor()); // Adding LoggingInterceptor
            optionsBuilder.AddInterceptors(new RetryInterceptor()); // Adding RetryInterceptor
            optionsBuilder.AddInterceptors(new SoftDeleteInterceptor()); // Adding SoftDeleteInterceptor
            optionsBuilder.AddInterceptors(new AuditInterceptor()); // Adding AuditInterceptor

            base.OnConfiguring(optionsBuilder);
        }
    }
}
