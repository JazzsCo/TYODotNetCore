using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TYODotNetCore.ConsoleApp.Models;
using System.Reflection.Metadata;

namespace TYODotNetCore.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        public readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()

        {
            DataSource = "LAPTOP-GF6QM6AD\\SQLEXPRESS",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = "sasa@123"
        };

        public void Read()
        {
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tbl_Blog]";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            List<BlogModel> lst =  db.Query<BlogModel>(query).ToList();

            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Edit(int id)
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

            var item = db.Query<BlogModel>(query, blogModel).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("Data not found!!");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                  ([BlogTitle]
                  ,[BlogAuthor]
                  ,[BlogContent])
            VALUES
                  (@BlogTitle
                  ,@BlogAuthor
                  ,@BlogContent)";

            BlogModel blogModel = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, blogModel);

            if (result > 0)
            {
                Console.WriteLine("Create successful...");
            }
            else
            {
                Console.WriteLine("Create failed...");
            }
        }

        public void Update(int id, string title, string author, string content)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
          SET [BlogTitle] = @BlogTitle
             ,[BlogAuthor] = @BlogAuthor
             ,[BlogContent] = @BlogContent
        WHERE BlogId = @BlogId";

            BlogModel blogModel = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, blogModel);

            if (result > 0)
            {
                Console.WriteLine("Update successful...");
            }
            else
            {
                Console.WriteLine("Update failed...");
            }
        }

        public void Delete(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
             WHERE BlogId = @BlogId";

            BlogModel blogModel = new BlogModel()
            {
                BlogId = id,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, blogModel);

            if (result > 0)
            {
                Console.WriteLine("Delete successful...");
            }
            else
            {
                Console.WriteLine("Delete failed...");
            }
        }
    }
}
