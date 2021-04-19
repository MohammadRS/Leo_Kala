using _01_LampshadeQuery.Contracts.Slide;
using ShopManagement.Infrastructure.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly LeoContext _context;
        public SlideQuery(LeoContext context)
        {
            _context = context;
        }
        public List<SlideQueryModel> GetSlides()
        {
            return _context.Slides.Where(x => x.IsRemoved == false).Select(x => new SlideQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                BtnText = x.BtnText,
                Heading = x.Heading,
                Link = x.Link,
                Text = x.Text,
                Title = x.Title
            }).ToList();

        }
    }
}
