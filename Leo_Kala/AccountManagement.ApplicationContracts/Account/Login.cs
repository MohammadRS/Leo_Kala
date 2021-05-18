using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Account
{
    public class Login
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(256, ErrorMessage = ValidationMessages.MaxLenght)]
        [EmailAddress(ErrorMessage = ValidationMessages.InvalidEmail)]
        public string Email { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }
    }
}
