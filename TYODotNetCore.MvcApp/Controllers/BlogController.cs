using Microsoft.AspNetCore.Mvc;
using TYODotNetCore.MvcApp.Models;

namespace TYODotNetCore.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context = new AppDbContext();

        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            List<BlogModel> lst = _context.Blogs.OrderByDescending(x => x.BlogId).ToList();

            return View("BlogIndex", lst);
        }
    }
}
