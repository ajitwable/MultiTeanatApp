using System.ComponentModel.DataAnnotations;

namespace MultiTenantApp.Model
{
    public class Product : IMustHaveTenant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TenantId { get; set; }
    }
}
