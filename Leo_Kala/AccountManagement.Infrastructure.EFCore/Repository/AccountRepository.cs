using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Infrastructure.EFCore.Context;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();
        }

        public Account GetBy(string email)
        {
            return _context.Accounts.FirstOrDefault(x => x.Email == email);
        }

        public EditAccount GetDetails(long id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Mobile = x.Mobile,
                //Password = x.Password,
                //RoleId = x.RoleId
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            //var query = _context.Accounts.Include(x => x.Role).Select(x => new AccountViewModel
            //{
            //    Id = x.Id,
            //    Fullname = x.Fullname,
            //    Mobile = x.Mobile,
            //    ProfilePhoto = x.ProfilePhoto,
            //    Role = x.Role.Name,
            //    RoleId = x.RoleId,
            //    Username = x.Username,
            //    CreationDate = x.CreationDate.ToFarsi()
            //});
            var query = _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                //RoleId = x.RoleId,
                Email = x.Email,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.LastName))
                query = query.Where(x => x.LastName.Contains(searchModel.LastName));

            if (!string.IsNullOrWhiteSpace(searchModel.FirstName))
                query = query.Where(x => x.FirstName.Contains(searchModel.FirstName));

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.Email.Contains(searchModel.Email));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));

            //if (searchModel.RoleId > 0)
            //    query = query.Where(x => x.RoleId == searchModel.RoleId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
