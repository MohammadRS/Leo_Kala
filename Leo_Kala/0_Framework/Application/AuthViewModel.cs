using System.Collections.Generic;

namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        //public long RoleId { get; set; }
        //public string Role { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        //public List<int> Permissions { get; set; }

        public AuthViewModel()
        {
        }

        public AuthViewModel(long id,string email, string mobile
            )
        {
            Id = id;
            //RoleId = roleId;
            Email = email;
            Mobile = mobile;
        }
    }
}