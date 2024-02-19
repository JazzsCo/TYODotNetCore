using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYODotNetCore.ConsoleApp.Models;

namespace TYODotNetCore.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs.ToList();    

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
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id);

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
            BlogModel blogModel = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            AppDbContext db = new AppDbContext();

            db.Blogs.Add(blogModel);
            int result = db.SaveChanges();

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
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId==id);

            if (item is null)
            {
                Console.WriteLine("Data not found!!");
                return;
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;   
            item.BlogContent = content;

            int result = db.SaveChanges();

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
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("Data not found!!");
                return;
            }

            db.Blogs.Remove(item);
            int result = db.SaveChanges();

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
