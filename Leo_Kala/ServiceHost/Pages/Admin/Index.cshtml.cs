using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Configuration.Permissions;

namespace ServiceHost.Pages.Admin
{
    [NeedsPermission(ShopPermissions.Admin)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
