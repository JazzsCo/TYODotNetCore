using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TYODotNetCore.ConsoleApp.Models;

namespace TYODotNetCore.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        public async Task Run()
        {
            //await Read();
            //await Edit(0);
            //await Create("Hello Loser", "Hello Author", "Hello Content");
            //await Update(4, "Hello Loser", "Hello Author", "Hello Content");
            await Delete(4);
        }

        private readonly IBlogApi refitApi = RestService.For<IBlogApi>("http://localhost:5112"); 

        private async Task Read()
        {
            List<BlogModel> lst = await refitApi.GetBlogs();

            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }   
        }

        private async Task Edit(int id)
        {
            try
            {
                BlogModel item = await refitApi.GetBlog(id);

                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            } catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Create(string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };

                string data = await refitApi.PostBlog(blog);

                Console.WriteLine(data);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Update(int id, string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };

                string data = await refitApi.PutBlog(id, blog);

                Console.WriteLine(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex.ToString());
            }
        }

        private async Task Delete(int id)
        {
            try
            {
                string data = await refitApi.DeleteBlog(id);

                Console.WriteLine(data);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
