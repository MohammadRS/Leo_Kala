using _01_LampshadeQuery.Contracts.Product;
using _01_LampshadeQuery.Contracts.Slide;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class MomentSliderViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;
        public MomentSliderViewComponent(IProductQuery productQuery)
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
