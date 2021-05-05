using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.ApplicationContracts.Account
{
    public class RegisterAccount
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string FirstName { get; private set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string LastName { get; private set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]

        public string Email { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Password { get; set; }

        public long RoleId { get; set; }

        public IFormFile ProfilePhoto { get; set; }
        //public List<RoleViewModel> Roles { get; set; }
    }
}
