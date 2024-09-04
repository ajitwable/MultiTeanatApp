using MultiTenantApp.Model;
using MultiTenantApp.Services.DTOs;

namespace MultiTenantApp.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;
        public ProductService(AppDbContext context)
        {
            _dbContext = context;
        }
        public Product CreateProduct(CreateProductRequest request)
        {
            var product = new Product();
            product.Name = request.Name;
            product.Description = request.Description;

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return product;
        }

        public bool DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return true; 
            }
            return false;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = _dbContext.Products.ToList();
            return products;
        }
    }
}
