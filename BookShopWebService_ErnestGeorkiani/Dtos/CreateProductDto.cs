using System.ComponentModel.DataAnnotations;

namespace BookShopWebService_ErnestGeorkiani.Dtos
{

    public record struct CreateProductDto
    {

        [Required]
        [MinLength(2, ErrorMessage = "FirstName must be at least 2 characters")]
        [MaxLength(250, ErrorMessage = "FirstName must not exceed 250 characters")]
        public string Name { get; set; }

        [Required]
        [MinLength(100, ErrorMessage = "FirstName must be at least 100 characters")]
        [MaxLength(500, ErrorMessage = "FirstName must not exceed 500 characters")]
        public string Annotation { get; set; }

        [RegularExpression("^(Book|Article|ElectronicResource)$", ErrorMessage = "ProductType must be either 'Book' 'Article' or 'ElectronicResource'")]
        public string ProductType { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "PrivateNumber should have 13 digits")]
        public string ISBN { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public string PublishingHouse { get; set; }

        public int Pages { get; set; }

        [Url]
        public string Address { get; set; }

        public int[] AuthorIds { get; set; }

        public ValidationResult ValidateAddress(ValidationContext validationContext)
        {
            if (ProductType == "ElectronicResource")
            {
                if (!Uri.TryCreate(Address, UriKind.Absolute, out Uri uriResult) || (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
                {
                    return new ValidationResult("Address must be a valid URL for ElectronicResource", new[] { nameof(Address) });
                }
            }
            else if (ProductType == "Book" && string.IsNullOrWhiteSpace(Address))
            {
                return new ValidationResult("Address is required for books", new[] { nameof(Address) });
            }

            return ValidationResult.Success;
        }
    }
}

//public record struct CreateProductDto(string Name, string Annotation,
//    string ProductType, string ISBN, DateTime ReleaseDate, string PublishingHouse,
//    int Pages, string Address, int[] AuthorIds);

//}

//}
