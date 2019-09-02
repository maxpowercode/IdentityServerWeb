using System.ComponentModel.DataAnnotations;
namespace IdentityWeb.Models
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email{get;set;}
        public string Password{get;set;}
        public string ConfirmPassword{get;set;}
    }
}