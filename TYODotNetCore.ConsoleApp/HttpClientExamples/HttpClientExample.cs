using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using TYODotNetCore.ConsoleApp.Models;

namespace TYODotNetCore.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            await Delete(19);
        }

        private async Task Read()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.GetAsync("http://localhost:5112/api/Blog");

            if (res.IsSuccessStatusCode)
            {
                string dataStr = await res.Content.ReadAsStringAsync();
                Console.WriteLine(dataStr);

                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(dataStr)!;

                foreach (BlogModel item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
        }

        private async Task Edit(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.GetAsync($"http://localhost:5112/api/Blog/{id}");

            string dataStr = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(dataStr);

                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(dataStr)!;

                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            else
            {
                Console.WriteLine(dataStr);
            }
        }

        private async Task Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string blogStr = JsonConvert.SerializeObject(blog);

            HttpContent httpContent = new StringContent(blogStr, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.PostAsync("http://localhost:5112/api/Blog/", httpContent);

            string dataStr = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(dataStr);
            }
            else
            {
                Console.WriteLine(dataStr);
            }
        }

        private async Task Update(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            string blogStr = JsonConvert.SerializeObject(blog);

            HttpContent httpContent = new StringContent(blogStr, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.PutAsync($"http://localhost:5112/api/Blog/{id}", httpContent);

            string dataStr = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(dataStr);
            }
            else
            {
                Console.WriteLine(dataStr);
            }
        }

        private async Task Delete(int id)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.DeleteAsync($"http://localhost:5112/api/Blog/{id}");

            string dataStr = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(dataStr);
            }
            else
            {
                Console.WriteLine(dataStr);
            }
        }
    }
}
