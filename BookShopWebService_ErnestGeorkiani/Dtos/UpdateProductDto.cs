using System.ComponentModel.DataAnnotations;

namespace BookShopWebService_ErnestGeorkiani.Dtos
{

    public record struct UpdateProductDto
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "FirstName must be at least 2 characters")]
        [MaxLength(250, ErrorMessage = "FirstName must not exceed 250 characters")]
        public string Name { get; set; }

        [Required]
        [MinLength(100, ErrorMessage = "FirstName must be at least 100 characters")]
        [MaxLength(500, ErrorMessage = "FirstName must not exceed 500 characters")]
        public string Annotation { get; set; }

        public string ProductType { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "PrivateNumber should have 13 digits")]
        public string ISBN { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public string PublishingHouse { get; set; }

        public int Pages { get; set; }

        // [Url]
        public string Address { get; set; }

    }

    //public record struct UpdateProductDto(int Id, string Name, string Annotation,
    //    string ProductType, string ISBN, DateTime ReleaseDate, string PublishingHouse,
    //    int Pages, string Address);
}
