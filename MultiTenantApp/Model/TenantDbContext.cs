using Microsoft.EntityFrameworkCore;

namespace MultiTenantApp.Model
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {
            
        }
        public DbSet<Tenant> Tenants { get; set; }
    }
}
