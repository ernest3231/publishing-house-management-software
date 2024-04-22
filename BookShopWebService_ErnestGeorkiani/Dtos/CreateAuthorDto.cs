using BookShopWebService_ErnestGeorkiani.Entities;
using BookShopWebService_ErnestGeorkiani.Validators;
using System.ComponentModel.DataAnnotations;

namespace BookShopWebService_ErnestGeorkiani.Dtos
{

    public record struct CreateAuthorDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "FirstName must be at least 2 characters")]
        [MaxLength(50, ErrorMessage = "FirstName must not exceed 50 characters")]
        public string FirstName { get; set; }


        [Required]
        [MinLength(2, ErrorMessage = "LastName must be at least 2 characters")]
        [MaxLength(50, ErrorMessage = "LastName must not exceed 50 characters")]
        public string LastName { get; set; }

        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be either 'Male' or 'Female'")]
        public string Gender { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "PrivateNumber should have 11 digits")]
        public string PrivateNumber { get; set; }

        [MinimumAge(18, ErrorMessage = "Author must be at least 18 years old")]
        public DateTime DateOfBirth { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        [MinLength(4, ErrorMessage = "PhoneNumber length should be at least 4 numbers")]
        [MaxLength(50, ErrorMessage = "PhoneNumber length should not exceed 50 numbers")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int[] ProductIds { get; init; }
    }
}

