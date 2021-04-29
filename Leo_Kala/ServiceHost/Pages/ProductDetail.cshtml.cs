using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampshadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductQuery _productQuery;

        public ProductDetailModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public ProductQueryModel Product;
        
        public void OnGet(string id)
        {
            Product = _productQuery.GetProductDetails(id);
        }
    }
}
