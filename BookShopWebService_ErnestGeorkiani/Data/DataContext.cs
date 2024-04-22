using BookShopWebService_ErnestGeorkiani.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShopWebService_ErnestGeorkiani.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {
                            
        }

        public DbSet<Author> Authors { get; set; } 

        public DbSet<Product> Products { get; set; }
    }
}
