using BookShopWebService_ErnestGeorkiani.Data;
using BookShopWebService_ErnestGeorkiani.Dtos;
using BookShopWebService_ErnestGeorkiani.Entities;
using BookShopWebService_ErnestGeorkiani.Filters;
using BookShopWebService_ErnestGeorkiani.Services.AuthorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace BookShopWebService_ErnestGeorkiani.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly IAuthorService _authorService;
        public AuthorController(DataContext context, IAuthorService authorService)
        {
            _context = context;
            _authorService = authorService;
        }

        [HttpGet("all/{page}")] // ყველა არსებული ავტორის ჩვენება, გვერდების მიხედვით
        [LoggingAsync(loggerName: "AllAuthor")]
        [Logging("AllAuthors")]
        public async Task<ActionResult<List<Author>>> GetAllAuthors(int page)
        {
            return await _authorService.GetAllAuthors(page);
        }

        [HttpGet("{id}")] // კონკრეტული ავტორის მოძებნა id-ის მეშვეობით
        [LoggingAsync(loggerName:"GetSingleAuthor")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {

            return await _authorService.GetAuthor(id);

        }

        [HttpPost] // ავტორის დამატება
        public async Task<ActionResult<List<Author>>> AddAuthor(CreateAuthorDto createAuthorDto)
        {

            return await _authorService.AddAuthor(createAuthorDto);

        }

        [HttpPut] // ავტორის ინფორმაციის დარედაქტირება
        public async Task<ActionResult<List<Author>>> UpdateAuthor(UpdateAuthorDto updatedAuthor)
        {
            return await _authorService.UpdateAuthor(updatedAuthor);

        }

        [HttpDelete] // ავტორის წაშლა
        public async Task<ActionResult<List<Author>>> DeleteAuthor(int id)
        {

            return await _authorService.DeleteAuthor(id);

        }

    }
}
