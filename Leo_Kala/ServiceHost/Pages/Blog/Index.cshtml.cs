using System.Collections.Generic;
using _01_LampshadeQuery.Contracts.Article;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.Blog
{
    public class IndexModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;

        public IndexModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public List<ArticleQueryModel> Articles { get; set; }

        public void OnGet()
        {
            Articles = _articleQuery.LatestArticle();
        }
    }
}
