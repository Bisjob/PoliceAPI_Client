using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PoliceAPI_Client.Common
{
    public class BaseService
    {
        public readonly string BaseUrl = "https://data.police.uk/api/";
        public async Task<T> GetItem<T>(string url) where T : class
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var fullUrl = $"{BaseUrl}{url}";
                    HttpResponseMessage response = await client.GetAsync(fullUrl);
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json ?? string.Empty);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return null;
                }
            }
        }

        public async Task<List<T>> GetList<T>(string url) where T : class
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var fullUrl = $"{BaseUrl}{url}";
                    HttpResponseMessage response = await client.GetAsync(fullUrl);
                    response.EnsureSuccessStatusCode();
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(json ?? string.Empty);
                }
                catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return null;
                }
                catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    await Task.Delay(1000);
                    return await GetList<T>(url);
                }
            }
        }
    }
}
