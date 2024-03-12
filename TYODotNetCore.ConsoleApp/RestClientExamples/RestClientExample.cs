using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using TYODotNetCore.ConsoleApp.Models;

namespace TYODotNetCore.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {
        public async Task Run()
        {
            await BirdRead();
        }

        //private readonly string _apiUrl = "http://localhost:5112/api/Blog";
        private readonly string _apiUrl = "http://localhost:5233/api/Bird";

        private async Task Read()
        {
            RestClient client = new RestClient();
            RestRequest restRequest = new RestRequest(_apiUrl, Method.Get);

            RestResponse res = await client.ExecuteAsync(restRequest);

            if (res.IsSuccessStatusCode)
            {
                string dataStr = res.Content!;

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

        private async Task BirdRead()
        {
            RestClient client = new RestClient();
            RestRequest restRequest = new RestRequest(_apiUrl, Method.Get);

            RestResponse res = await client.ExecuteAsync(restRequest);

            if (res.IsSuccessStatusCode)
            {
                string dataStr = res.Content!;

                List<BirdModel> lst = JsonConvert.DeserializeObject<List<BirdModel>>(dataStr)!;

                Console.WriteLine(lst.Count);
            }
        }

        private async Task Edit(int id)
        {
            string url = $"{_apiUrl}/{id}";

            RestClient client = new RestClient();
            RestRequest restRequest = new RestRequest(url, Method.Get);

            RestResponse res = await client.ExecuteAsync(restRequest);

            string dataStr = res.Content!;

            if (res.IsSuccessStatusCode)
            {
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

            RestClient client = new RestClient();
            RestRequest restRequest = new RestRequest(_apiUrl, Method.Post);
            restRequest.AddJsonBody(blog);

            RestResponse res = await client.ExecuteAsync(restRequest);

            string dataStr = res.Content!;

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

            string url = $"{_apiUrl}/{id}";

            RestClient client = new RestClient();
            RestRequest restRequest = new RestRequest(url, Method.Put);
            restRequest.AddJsonBody(blog);
            
            RestResponse res = await client.ExecuteAsync(restRequest);

            string dataStr = res.Content!;

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
            string url = $"{_apiUrl}/{id}";

            RestClient client = new RestClient();
            RestRequest restRequest = new RestRequest(url, Method.Delete);

            RestResponse res = await client.ExecuteAsync(restRequest);

            string dataStr = res.Content!;

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
