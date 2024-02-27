using Lab_09_MVC.Models;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using Lab_09_MVC.ArticleContext;

namespace Lab_09_MVC.ArticlesContext
{
    public class ArticlesContextList: IArticlesContext
    {
        private List<Article> articles = new List<Article>();

        public IEnumerable<Article> GetArticles()
        {
            return articles;
        }

        public Article GetArticle(int id)
        {
            return articles.FirstOrDefault(a => a.Id == id);
        }

        public void AddArticle(Article article)
        {
            if (articles.Count == 0)
            {
                article.Id = 0;
            }
            else
            {
                int nextId = articles.Max(a => a.Id) + 1;
                article.Id = nextId;
            }
            articles.Add(article);
        }

        public void RemoveArticle(int id)
        {
            Article articleToRemove = articles.FirstOrDefault(a => a.Id == id);
            if (articleToRemove != null)
            {
                articles.Remove(articleToRemove);
            }
        }

        public void UpdateArticle(Article updatedArticle)
        {
            Article existingArticle = articles.FirstOrDefault(a => a.Id == updatedArticle.Id);
            articles = articles.Select(s => (s.Id == existingArticle.Id) ? existingArticle : s).ToList();
        }
    }
}
