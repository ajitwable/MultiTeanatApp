using MultiTenantApp.Model;
using MultiTenantApp.Services.DTOs;

namespace MultiTenantApp.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product CreateProduct(CreateProductRequest request);

        bool DeleteProduct(int id);
    }
}
