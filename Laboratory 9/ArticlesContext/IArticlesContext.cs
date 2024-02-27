using System.Collections.ObjectModel;
using Lab_09_MVC.Models;

namespace Lab_09_MVC.ArticleContext
{
    public interface IArticlesContext
    {
        IEnumerable<Article> GetArticles();
        Article GetArticle(int id);
        void AddArticle(Article article);
        void RemoveArticle(int id);
        void UpdateArticle(Article updatedArticle);
    }
}
