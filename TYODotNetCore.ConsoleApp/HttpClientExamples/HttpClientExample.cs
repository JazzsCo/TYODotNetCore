using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TYODotNetCore.ConsoleApp.Models;

namespace TYODotNetCore.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            await Read();
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
    }
}
