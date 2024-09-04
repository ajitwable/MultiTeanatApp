using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using MultiTenantApp.Services;
using MultiTenantApp.Services.DTOs;

namespace MultiTenantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        { 
            var list = _productService.GetAllProducts();
            return Ok(list);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductRequest request)
        { 
            var product = _productService.CreateProduct(request);
            return Ok(product);
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id);
            return Ok(result);
        }
    }
}
