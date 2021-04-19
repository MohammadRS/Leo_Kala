using _01_LampshadeQuery.Contracts.Slide;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SliderMainViewComponent : ViewComponent
    {
        private readonly ISlideQuery _slideQuery;
        public SliderMainViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }
        
        public IViewComponentResult Invoke()
        {
            var slide = _slideQuery.GetSlides();
            return View(slide);
        }
    }
}
