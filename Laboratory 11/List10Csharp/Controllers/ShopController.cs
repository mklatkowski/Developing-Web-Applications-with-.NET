// ShopController.cs

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using List10Csharp.Data;
using Newtonsoft.Json;
using List10Csharp.Models;

namespace List10Csharp.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopDbContext _context;

        public ShopController(ShopDbContext context)
        {
            _context = context;
        }

        // GET: Shop
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // GET: Shop/Products/5
        public IActionResult Products(int? categoryId)
        {
            if (categoryId == null)
            {
                return NotFound();
            }

            var category = _context.Categories
                .Include(c => c.Articles)
                .FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Cart()
        {
            var cart = GetCartFromCookie();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int articleId)
        {
            var cart = GetCartFromCookie();

            var article = _context.Articles.FirstOrDefault(a => a.Id == articleId);
            if (article != null)
            {
                var existingItem = cart.Items.FirstOrDefault(item => item.ArticleId == articleId);

                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    cart.Items.Add(new CartItem
                    {
                        ArticleId = article.Id,
                        ArticleName = article.Name,
                        ArticlePrice = article.Price,
                        ImagePath = article.ImagePath,
                        Quantity = 1
                    });
                }
            }

            SaveCartToCookie(cart);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCart(int articleId, int quantity)
        {
            var cart = GetCartFromCookie();

            var existingItem = cart.Items.FirstOrDefault(item => item.ArticleId == articleId);
            if (existingItem != null)
            {
                if (quantity <= 0)
                {
                    cart.Items.Remove(cart.Items.FirstOrDefault(item => item.ArticleId == articleId));
                }
                else
                {
                    existingItem.Quantity = quantity;
                }
            }

            SaveCartToCookie(cart);

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int articleId)
        {
            var cart = GetCartFromCookie();

            var itemToRemove = cart.Items.FirstOrDefault(item => item.ArticleId == articleId);
            if (itemToRemove != null)
            {
                cart.Items.Remove(itemToRemove);
            }

            SaveCartToCookie(cart);

            return RedirectToAction("Cart");
        }

        private CartModel GetCartFromCookie()
        {
            var cartCookie = Request.Cookies["Cart"];
            return cartCookie != null ? JsonConvert.DeserializeObject<CartModel>(cartCookie) : new CartModel();
        }

        private void SaveCartToCookie(CartModel cart)
        {
            var cartCookie = JsonConvert.SerializeObject(cart);
            Response.Cookies.Append("Cart", cartCookie, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7)
            });
        }
    }
}
