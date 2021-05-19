using System.Collections.Generic;
using _01_LampshadeQuery.Contracts.Article;
using _01_LampshadeQuery.Contracts.ArticleCategory;
using CommentManagement.Application.Contracts.Comment;
using CommnetManagement.Infrastructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.Blog
{
    public class ArticleModel : PageModel
    {

        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
        private readonly ICommentApplication _commentApplication;

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
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

        public IActionResult OnPost(AddComment command, string articleSlug)
        {
            command.Type = CommentType.Article;
            var result = _commentApplication.Add(command);
            return RedirectToPage("Article", new { Id = articleSlug });
        }
    }
}
