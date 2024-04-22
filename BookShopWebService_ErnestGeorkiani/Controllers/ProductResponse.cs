using BookShopWebService_ErnestGeorkiani.Entities;

namespace BookShopWebService_ErnestGeorkiani.Controllers
{
    internal class ProductResponse
    {
        public List<Product> Products { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
    }
}