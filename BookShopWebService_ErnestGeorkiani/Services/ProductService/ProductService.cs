using BookShopWebService_ErnestGeorkiani.Controllers;
using BookShopWebService_ErnestGeorkiani.Data;
using BookShopWebService_ErnestGeorkiani.Dtos;
using BookShopWebService_ErnestGeorkiani.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopWebService_ErnestGeorkiani.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<List<Product>>> AddProduct(CreateProductDto createProductDto)
        {
            Product product = new Product();

            product.Name = createProductDto.Name;
            product.Annotation = createProductDto.Annotation;
            product.ProductType = createProductDto.ProductType;
            product.ISBN = createProductDto.ISBN;
            product.ReleaseDate = createProductDto.ReleaseDate;
            product.PublishingHouse = createProductDto.PublishingHouse;
            product.Pages = createProductDto.Pages;
            product.Address = createProductDto.Address;

            product.Authors = new List<Author>();

            for (int i = 0; i < createProductDto.AuthorIds.Length; i++)
            {
                var author = await _context.Authors.FindAsync(createProductDto.AuthorIds[i]);

                if (author is null)
                    return NotFound();

                product.Authors.Add(author);
            }

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        private ActionResult<List<Product>> NotFound()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var dbProduct = await _context.Products.FindAsync(id);

            if (dbProduct is null)
                return NotFound("Product Not Found.");

            _context.Products.Remove(dbProduct);

            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());

        }

        private ActionResult<List<Product>> NotFound(string v)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<List<Product>>> GetAllProducts(int page)
        {
            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Products.Count() / pageResults);

            var products = await _context.Products
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new ProductResponse
            {
                Products = products,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return Ok(products);

        }

        public Task<ActionResult<Product>> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<List<Product>>> UpdateProduct(UpdateProductDto updatedProduct)
        {
            var dbProduct = await _context.Products.FindAsync(updatedProduct.Id);

            if (dbProduct is null)
                return NotFound("Product Not Found");

            if (updatedProduct.Name is not null)
                dbProduct.Name = updatedProduct.Name;

            if (updatedProduct.Name is not null)
                dbProduct.Annotation = updatedProduct.Annotation;

            if (updatedProduct.Name is not null)
                dbProduct.ProductType = updatedProduct.ProductType;

            if (updatedProduct.Name is not null)
                dbProduct.ISBN = updatedProduct.ISBN;

            if (updatedProduct.Name is not null)
                dbProduct.ReleaseDate = updatedProduct.ReleaseDate;

            if (updatedProduct.Name is not null)
                dbProduct.PublishingHouse = updatedProduct.PublishingHouse;

            if (updatedProduct.Name is not null)
                dbProduct.Pages = updatedProduct.Pages;

            if (updatedProduct.Name is not null)
                dbProduct.Address = updatedProduct.Address;

            await _context.SaveChangesAsync();

            return Ok(await _context.Products.ToListAsync());
        }

        private ActionResult<List<Product>> Ok(List<Product> products)
        {
            return new ActionResult<List<Product>>(products);
        }

    }
}
