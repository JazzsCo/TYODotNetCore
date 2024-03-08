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
            List<BlogModel> lst = _context.Blogs.ToList();

            return View("BlogIndex", lst);
        }

        [ActionName("View")]
        public IActionResult BlogView(int id)
        {
            BlogModel? item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null) {
                return Redirect("/Blog");
            }

            return View("BlogView", item);
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Create")]
        public IActionResult BlogCreate(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();

            return Redirect("/Blog");
        }

        [ActionName("Update")]
        public IActionResult BlogUpdate(int id)
        {
            BlogModel? item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                return Redirect("/Blog");
            }

            return View("BlogUpdate", item);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id, BlogModel blog)
        {
            BlogModel? item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                return Redirect("/Blog");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _context.SaveChanges();

            return Redirect("/Blog");
        }

        [ActionName("Delete")]
        public IActionResult BlogDelete(int id)
        {
            BlogModel? item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                return Redirect("/Blog");
            }

            _context.Blogs.Remove(item);
            _context.SaveChanges();

            return Redirect("/Blog");
        }
    }
}
