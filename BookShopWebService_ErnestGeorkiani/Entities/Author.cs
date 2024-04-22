using BookShopWebService_ErnestGeorkiani.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookShopWebService_ErnestGeorkiani.Entities
{
    public class Author
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PrivateNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public string Country { get; set; }
        
        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public List<Product> Products { get; set; }

        }
}
