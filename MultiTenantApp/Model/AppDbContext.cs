using Microsoft.EntityFrameworkCore;
using MultiTenantApp.Services;

namespace MultiTenantApp.Model
{
    public class AppDbContext : DbContext
    {
        private readonly ICurrentTenantService _tenantService;
        public string currentTenantId { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentTenantService tenantService) : base(options)
        {
            _tenantService = tenantService;
            currentTenantId = tenantService.TenantId;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(a => a.TenantId == currentTenantId);
        }

        //To save something every time
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.TenantId = currentTenantId;
                        break;
                }
            }
            return base.SaveChanges();
        }

    }


}
