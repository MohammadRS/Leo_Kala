using AccountManagement.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            //services.AddTransient<IAccountApplication, AccountApplication>();
            //services.AddTransient<IAccountRepository, AccountRepository>();

            //services.AddTransient<IRoleApplication, RoleApplication>();
            //services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
