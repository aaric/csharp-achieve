using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleLang.Lang
{
    /**
     * https://learn.microsoft.com/zh-cn/dotnet/fundamentals/networking/http/httpclient
     *
     * https://dummyjson.com
     */
    public class HttpClientPrinter : MyPrinter
    {
        public async void print()
        {
            Console.WriteLine("---------------");
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("C# Http Client"));
            client.DefaultRequestHeaders.Add("User-Agent", "C# Http Client");

            // get
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://dummyjson.com/products/1");
            await client.SendAsync(request).ContinueWith(task =>
                Console.WriteLine($"get json -> {task.Result.Content.ReadAsStringAsync().Result}\n")
            );

            // get
            string jsonString = await client.GetStringAsync("https://dummyjson.com/products/1");
            Console.WriteLine($"get json -> {jsonString}\n");

            // post
            StringContent jsonPost = new StringContent("{\"title\":\"BMW Pencil\"}", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://dummyjson.com/products/add", jsonPost);
            Console.WriteLine($"post json -> {response.Content.ReadAsStringAsync().Result}\n");

            // put
            StringContent jsonPut =
                new StringContent("{\"title\":\"iPhone Galaxy +1\"}", Encoding.UTF8, "application/json");
            response = await client.PutAsync("https://dummyjson.com/products/1", jsonPut);
            Console.WriteLine($"put json -> {response.Content.ReadAsStringAsync().Result}\n");

            // delete
            response = await client.DeleteAsync("https://dummyjson.com/products/1");
            Console.WriteLine($"delete json -> {response.Content.ReadAsStringAsync().Result}\n");
        }
    }
}