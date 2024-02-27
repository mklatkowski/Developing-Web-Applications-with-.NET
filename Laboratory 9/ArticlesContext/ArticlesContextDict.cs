using Lab_09_MVC.ArticleContext;
using Lab_09_MVC.Models;
using System.Linq;

namespace Lab_09_MVC.ArticlesContext
{
    public class ArticlesContextDict: IArticlesContext
    {
        private Dictionary<int, Article> articles = new Dictionary<int, Article>
            {
                { 0, new Article(0, "Laptop", 1200.50f, DateTime.Now.AddDays(30), Category.Electronics) },
                { 1, new Article(1, "T-shirt", 19.99f, DateTime.Now.AddDays(60), Category.Clothing) },
                { 2, new Article(2, "Book", 15.00f, DateTime.Now.AddDays(90), Category.Books) },
            };
        public IEnumerable<Article> GetArticles()
        {
            return articles.Values.Select(s=>s).OrderBy(s=>s.Id);
        }

        public Article GetArticle(int id)
        {
            articles.TryGetValue(id, out var article);
            return article;
        }

        public void AddArticle(Article article)
        {
            if (articles.Count == 0)
            {
                article.Id = 0;
            }
            else
            {
                int nextId = articles.Keys.Max() + 1;
                article.Id = nextId;
            }
            articles.Add(article.Id, article);
        }

        public void RemoveArticle(int id)
        {
            articles.Remove(id);
        }

        public void UpdateArticle(Article updatedArticle)
        {
            if (articles.ContainsKey(updatedArticle.Id))
            {
                articles[updatedArticle.Id] = updatedArticle;
            }
        }
    }
}
