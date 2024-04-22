using BookShopWebService_ErnestGeorkiani.Data;
using BookShopWebService_ErnestGeorkiani.Dtos;
using BookShopWebService_ErnestGeorkiani.Entities;
using BookShopWebService_ErnestGeorkiani.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BookShopWebService_ErnestGeorkiani.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IProductService _productService;

        public ProductController(DataContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        [HttpGet("all/{page}")]
        public async Task<ActionResult<List<Product>>> GetAllProducts(int page)
        {

            return await _productService.GetAllProducts(page);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
                return NotFound("Product Not Found");

            return Ok(product);

        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(CreateProductDto createProductDto)
        {

            return await _productService.AddProduct(createProductDto);

        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(UpdateProductDto updatedProduct)
        {
            return await _productService.UpdateProduct(updatedProduct);

        }

        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            return await _productService.DeleteProduct(id);

        }

    }
}
