namespace AccountManagement.Application.Contracts.Account
{
    public class AccountSearchModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public long RoleId { get; set; }
    }
}
