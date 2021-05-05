using _0_Framework.Domain;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }
        public string Password { get; private set; }
        public long RoleId { get; private set; }
        //public Role Role { get; private set; }
        public string ProfilePhoto { get; private set; }

        public Account( string email, string mobile, string password, long roleId, string profilePhoto)
        {
            Email = email;
            Mobile = mobile;
            Password = password;
            RoleId = roleId;
            if (roleId == 0)
                RoleId = 2;
            ProfilePhoto = profilePhoto;
        }

        public void Edit(string firstName, string lastName, string email, string mobile, long roleId, string profilePhoto)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Mobile = mobile;
            RoleId = roleId;

            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }

    }
}
