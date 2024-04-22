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

namespace BookShopWebService_ErnestGeorkiani.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        private readonly DataContext _context;

        public AuthorService(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Author>>> GetAllAuthors(int page)
        {
            if (_context.Authors is null)
                return NotFound();

            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Authors.Count() / pageResults);

            var authors = await _context.Authors
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            var response = new AuthorResponse
            {
                Authors = authors,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return Ok(authors);
        }

        public ActionResult<List<Author>> Ok(List<Author> authors)
        {
            return new ActionResult<List<Author>>(authors);
        }

        public ActionResult<List<Author>> NotFound()
        {
            return new NotFoundResult();
        }

        //public Task<ActionResult<Author>> GetAuthor(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<ActionResult<List<Author>>> DeleteAuthor(int id)
        {
            var dbAuthor = await _context.Authors.FindAsync(id);

            if (dbAuthor is null)
                return NotFound("Author Not Found.");

            _context.Authors.Remove(dbAuthor);

            await _context.SaveChangesAsync();

            return Ok(await _context.Authors.ToListAsync());
        }

        private ActionResult<List<Author>> NotFound(string v)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<List<Author>>> UpdateAuthor(UpdateAuthorDto updatedAuthor)
        {
            var dbAuthor = await _context.Authors.FindAsync(updatedAuthor.Id);

            if (dbAuthor is null)
                return NotFound("Author Not Found.");

            if (updatedAuthor.FirstName is not null)
                dbAuthor.FirstName = updatedAuthor.FirstName;

            if (updatedAuthor.LastName is not null)
                dbAuthor.LastName = updatedAuthor.LastName;

            if (updatedAuthor.Gender is not null)
                dbAuthor.Gender = updatedAuthor.Gender;

            if (updatedAuthor.PrivateNumber is not null)
                dbAuthor.PrivateNumber = updatedAuthor.PrivateNumber;

            if (updatedAuthor.DateOfBirth != null)
                dbAuthor.DateOfBirth = updatedAuthor.DateOfBirth;

            if (updatedAuthor.Country is not null)
                dbAuthor.Country = updatedAuthor.Country;

            if (updatedAuthor.City is not null)
                dbAuthor.City = updatedAuthor.City;

            if (updatedAuthor.PhoneNumber is not null)
                dbAuthor.PhoneNumber = updatedAuthor.PhoneNumber;

            if (updatedAuthor.Email is not null)
                dbAuthor.Email = updatedAuthor.Email;

            await _context.SaveChangesAsync();

            return Ok(await _context.Authors.ToListAsync());
        }

        public async Task<ActionResult<Author>> GetAuthor(int id)
        {

            //return await _authorService.GetAuthor(id);
            var author = await _context.Authors.FindAsync(id);

            if (author is null)
                return NotFound(new { message = "Author Not Found." }); ;

            return Ok(author);
        }

        private ActionResult<Author> NotFound(object value)
        {
            throw new NotImplementedException();
        }

        public ActionResult<Author> Ok(Author author)
        {
            return new ActionResult<Author>(author);
        }

        public async Task<ActionResult<List<Author>>> AddAuthor(CreateAuthorDto createAuthorDto)
        {
            Author author = new Author();

            author.FirstName = createAuthorDto.FirstName;
            author.LastName = createAuthorDto.LastName;
            author.Gender = createAuthorDto.Gender;
            author.PrivateNumber = createAuthorDto.PrivateNumber;
            author.DateOfBirth = createAuthorDto.DateOfBirth;
            author.Country = createAuthorDto.Country;
            author.City = createAuthorDto.City;
            author.PhoneNumber = createAuthorDto.PhoneNumber;
            author.Email = createAuthorDto.Email;

            author.Products = new List<Product>();

            for (int i = 0; i < createAuthorDto.ProductIds.Length; i++)
            {
                var product = await _context.Products.FindAsync(createAuthorDto.ProductIds[i]);

                if (product is null)
                    return NotFound();

                author.Products.Add(product);
            }

            _context.Authors.Add(author);

            await _context.SaveChangesAsync();

            return Ok(await _context.Authors.ToListAsync());
        }

    }
}