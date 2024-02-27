using Lab_09_MVC.ArticleContext;
using Lab_09_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_09_MVC.Controllers
{
    public class ArticleController : Controller
    {
        private IArticlesContext articleContext;

        public ArticleController(IArticlesContext articleContext)
        {
            this.articleContext = articleContext;
        }
        public IActionResult Index()
        {
            return View(articleContext.GetArticles());
        }

        public IActionResult Details(int id)
        {
            return View(articleContext.GetArticle(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Article article)
        {
            try
            {
                if (ModelState.IsValid)               
                    articleContext.AddArticle(article); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(articleContext.GetArticle(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Article article)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    article.Id = id;
                    articleContext.UpdateArticle(article);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(articleContext.GetArticle(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                articleContext.RemoveArticle(id); // zmiana
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
