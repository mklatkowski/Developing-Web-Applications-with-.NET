// ShopController.cs

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using List10Csharp.Data;

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
    }
}
