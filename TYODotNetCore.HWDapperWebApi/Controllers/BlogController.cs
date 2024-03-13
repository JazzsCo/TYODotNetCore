using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using TYODotNetCore.HWDapperWebApi.Models;

namespace TYODotNetCore.HWDapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()

        {
            DataSource = "LAPTOP-GF6QM6AD\\SQLEXPRESS",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = "sasa@123"
        };


        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = @"SELECT [BlogId]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
              FROM [dbo].[Tbl_Blog]";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = @"SELECT [BlogId]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
              FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

            BlogModel blogModel = new BlogModel()
            {
                BlogId = id
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            BlogModel? item = db.Query<BlogModel>(query, blogModel).FirstOrDefault();

            if (item is null)
            {
                return NotFound("Data not found!!");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blogModel)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                  ([BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent])
            VALUES
                  (@BlogTitle
                  ,@BlogAuthor
                  ,@BlogContent)";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, blogModel);

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
            string query = @"SELECT [BlogId]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
              FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

            BlogModel firstBlogModel = new BlogModel()
            {
                BlogId = id,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            BlogModel? item = db.Query<BlogModel>(query, firstBlogModel).FirstOrDefault();

            if (item is null)
            {
                return NotFound("Data not found!!");
            }

            string secQuery = @"UPDATE [dbo].[Tbl_Blog]
                  SET [BlogTitle] = @BlogTitle
                     ,[BlogAuthor] = @BlogAuthor
                     ,[BlogContent] = @BlogContent
                WHERE BlogId = @BlogId";

            BlogModel secBlogMode = new BlogModel()
            {
                BlogId = id,
                BlogTitle = blogModel.BlogTitle,
                BlogAuthor = blogModel.BlogAuthor,
                BlogContent = blogModel.BlogContent,
            };

            int result = db.Execute(secQuery, secBlogMode);

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
            string query = @"SELECT [BlogId]
                  ,[BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent]
              FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

            BlogModel blogModel = new BlogModel()
            {
                BlogId = id,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            BlogModel? item = db.Query<BlogModel>(query, blogModel).FirstOrDefault();

            if (item is null)
            {
                return NotFound("Data not found!!");
            }

            string secQuery = @"DELETE FROM [dbo].[Tbl_Blog]
             WHERE BlogId = @BlogId";

            int result = db.Execute(secQuery, blogModel);

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
