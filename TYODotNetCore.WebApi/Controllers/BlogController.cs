using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TYODotNetCore.MvcApp.Models;

namespace TYODotNetCore.MvcApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db = new AppDbContext();

        [HttpGet] 
        public IActionResult GetBlogs()
        {
            List<BlogModel> lst = _db.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);

            if (item is null)
            {
                return NotFound("Data not found!!");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blogModel)
        {
            _db.Blogs.Add(blogModel);
            int result = _db.SaveChanges();

            if (result > 0)
            {
                return Ok("Create successful...");
            }
            else
            {
                return Ok("Create failed...");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blogModel)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);

            if (item is null)
            {
                return NotFound("Data not found!!");
            }

            item.BlogTitle = blogModel.BlogTitle;
            item.BlogAuthor = blogModel.BlogAuthor;
            item.BlogContent = blogModel.BlogContent;

            int result = _db.SaveChanges();

            if (result > 0)
            {
                return Ok("Update successful...");
            }
            else
            {
                return Ok("Update failed...");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);

            if (item is null)
            {
                return NotFound("Data not found!!");
            }

            _db.Blogs.Remove(item);
            int result = _db.SaveChanges();

            if (result > 0)
            {
                return Ok("Delete successful...");
            }
            else
            {
                return Ok("Delete failed...");
            }
        }
    }
}
