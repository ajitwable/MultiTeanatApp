
using Microsoft.EntityFrameworkCore;
using MultiTenantApp.Model;

namespace MultiTenantApp.Services
{
    public class CurrentTenantService : ICurrentTenantService
    {
        private readonly TenantDbContext _context;
        public CurrentTenantService(TenantDbContext context)
        {
            _context = context;
        }

        public string? TenantId { get; set; }

        public async Task<bool> SetTenant(string tenantId)
        {
            var tenantInfo = await _context.Tenants.Where(t => t.Id == tenantId).FirstOrDefaultAsync();
            if (tenantInfo != null)
            {
                TenantId = tenantInfo.Id;
                return true;
            }
            else 
            { 
                throw new Exception("Invalid Tenant");
            }
        }
    }
}
