using BookShopWebService_ErnestGeorkiani.Entities;

namespace BookShopWebService_ErnestGeorkiani.Controllers
{
    internal class AuthorResponse
    {
        public List<Author> Authors { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
    }
}