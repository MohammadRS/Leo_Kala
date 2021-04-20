using _01_LampshadeQuery.Contracts.Product;
using _01_LampshadeQuery.Contracts.Slide;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class SliderProductViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;
        public SliderProductViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
        public IViewComponentResult Invoke()
        {
            var products = _productQuery.GetLatestArrivals();
            return View(products);
        }
    }
}
