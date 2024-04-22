using BookShopWebService_ErnestGeorkiani.Dtos;
using BookShopWebService_ErnestGeorkiani.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopWebService_ErnestGeorkiani.Services.ProductService
{
    public interface IProductService
    {
        Task<ActionResult<List<Product>>> GetAllProducts(int page);

        Task<ActionResult<Product>> GetProduct(int id);

        Task<ActionResult<List<Product>>> AddProduct(CreateProductDto createProductDto);

        Task<ActionResult<List<Product>>> UpdateProduct(UpdateProductDto updatedProduct);

        Task<ActionResult<List<Product>>> DeleteProduct(int id);
    }
}
