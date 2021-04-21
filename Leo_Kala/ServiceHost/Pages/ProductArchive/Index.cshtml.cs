using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.ProductArchive
{
    public class IndexModel : PageModel
    {
        private readonly IProductQuery _productQuery;
        public IndexModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
        public List<ProductQueryModel> command { get; set; }

        public void OnGet()
        {
            command = _productQuery.GetLatestArrivals();
        }
    }
}
