using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        List<string> urls = new List<string>
        {
            "https://www.example.com/page1",
            "https://www.example.com/page2",
            // 添加其他页面链接
        };

        var httpClient = new HttpClient();

        // 并行处理每个页面
        await Task.WhenAll(urls.Select(url => ProcessPageAsync(httpClient, url)));
    }

    static async Task ProcessPageAsync(HttpClient httpClient, string url)
    {
        var response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            // 处理页面内容
            Console.WriteLine($"Processed {url}");
        }
    }
}
