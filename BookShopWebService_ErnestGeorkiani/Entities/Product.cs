using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookShopWebService_ErnestGeorkiani.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Annotation { get; set; }

        public string ProductType { get; set; }

        public string ISBN { get; set;  }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public string PublishingHouse { get; set; }

        public int Pages { get; set; }

        public string Address { get; set; }

        [JsonIgnore]
        public List<Author> Authors { get; set; }

    }
}
