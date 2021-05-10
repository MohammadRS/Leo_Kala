using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Configuration.Permissions;

namespace ServiceHost.Pages.Admin
{
    public class IndexModel : PageModel
    {
        [NeedsPermission(ShopPermissions.Admin)]
        public void OnGet()
        {
        }
    }
}
