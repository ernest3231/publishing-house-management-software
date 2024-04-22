using BookShopWebService_ErnestGeorkiani.Dtos;
using BookShopWebService_ErnestGeorkiani.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShopWebService_ErnestGeorkiani.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<ActionResult<List<Author>>> GetAllAuthors(int page);
        Task<ActionResult<Author>> GetAuthor(int id);
        Task<ActionResult<List<Author>>> DeleteAuthor(int id);
        Task<ActionResult<List<Author>>> UpdateAuthor(UpdateAuthorDto updatedAuthor);
        Task<ActionResult<List<Author>>> AddAuthor(CreateAuthorDto createAuthorDto);

    }
}