using System.Collections.Generic;
using _01_LampshadeQuery.Contracts.Article;
using _01_LampshadeQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.Blog
{
    public class ArticleModel : PageModel
    {
        //public ArticleQueryModel Article;
        //public List<ArticleQueryModel> LatestArticles;
        //public List<ArticleCategoryQueryModel> ArticleCategories;
        //private readonly IArticleQuery _articleQuery;
        //private readonly IArticleCategoryQuery _articleCategoryQuery;
        //private readonly ICommentApplication _commentApplication;

        //public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery, ICommentApplication commentApplication)
        //{
        //    _articleQuery = articleQuery;
        //    _commentApplication = commentApplication;
        //    _articleCategoryQuery = articleCategoryQuery;
        //}
        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            _articleQuery = articleQuery;
            _articleCategoryQuery = articleCategoryQuery;
        }

        public ArticleQueryModel Article;
        public List<ArticleQueryModel> LatestArticles;
        public List<ArticleCategoryQueryModel> ArticleCategories;

        public void OnGet(string id)
        {
            Article = _articleQuery.GetArticleDetails(id);
            LatestArticles = _articleQuery.LatestArticle();
            ArticleCategories = _articleCategoryQuery.GetArticleCategories();
        }

        //public IActionResult OnPost(AddComment command, string articleSlug)
        //{
        //    command.Type = CommentType.Article;
        //    var result = _commentApplication.Add(command);
        //    return RedirectToPage("/Article", new { Id = articleSlug });
        //}
    }
}
