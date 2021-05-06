using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Contracts.Account
{
    public class RegisterAccount
    {
        //[Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string LastName { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string Email { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }

        //public long RoleId { get; set; }

        public IFormFile ProfilePhoto { get; set; }
        //public List<RoleViewModel> Roles { get; set; }
    }
}
