using E_vent.WebUI.ViewModels;
using System.Text;
using System.Text.Json;

namespace E_vent.WebUI.Helpers
{
    public class ApiHelper
    {
        private string _apiKey;
        public ApiHelper(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<ApiViewModel<T>> Get<T>(string url) where T : class
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("x-api-key", _apiKey);
                    //string serialized = "";  adam bişi yazmıyor serilize etme
                    url = $"http://localhost:55291/api/{url}";
                    //serialized = JsonConvert.SerializeObject(data);
                    HttpResponseMessage response = await client.GetAsync(url);

                    var result = response.Content.ReadAsStringAsync().Result;
                    var entity = JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); // post del upd pat yok   entity = null 
                    return new ApiViewModel<T>() { Entity = entity, Success = true, ResponseMessage = "Request Success!" };
                }
                catch (Exception ex)
                {
                    return new ApiViewModel<T>() { Success = false, ResponseMessage = ex.Message };
                }
            }
        }

        public async Task<ApiViewModel<T>> Post<T>(string url, T data) where T : class
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("x-api-key", _apiKey);

                    url = $"http://localhost:55291/api/{url}";
                    string serialized = JsonSerializer.Serialize(data);
                    HttpResponseMessage response = await client.PostAsync(url, new StringContent(serialized, Encoding.UTF8, "application/json"));
                    var result = response.Content.ReadAsStringAsync().Result;

                    return new ApiViewModel<T>() { Entity = null, Success = true, ResponseMessage = "Request Success!" };
                }
                catch (Exception ex)
                {
                    return new ApiViewModel<T>() { Success = false, ResponseMessage = ex.Message };
                }
            }
        }

        public async Task<ApiViewModel<T>> Put<T>(string url, T data) where T : class
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("x-api-key", _apiKey);

                    url = $"http://localhost:55291/api/{url}";
                    string serialized = JsonSerializer.Serialize(data);
                    HttpResponseMessage response = await client.PutAsync(url, new StringContent(serialized, Encoding.UTF8, "application/json"));
                    var result = response.Content.ReadAsStringAsync().Result;

                    return new ApiViewModel<T>() { Entity = null, Success = true, ResponseMessage = "Request Success!" };
                }
                catch (Exception ex)
                {
                    return new ApiViewModel<T>() { Success = false, ResponseMessage = ex.Message };
                }
            }
        }

        public async Task<ApiViewModel<T>> Patch<T>(string url, T data) where T : class
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("x-api-key", _apiKey);

                    url = $"http://localhost:55291/api/{url}";
                    string serialized = JsonSerializer.Serialize(data);
                    HttpResponseMessage response = await client.PatchAsync(url, new StringContent(serialized, Encoding.UTF8, "application/json"));
                    var result = response.Content.ReadAsStringAsync().Result;

                    return new ApiViewModel<T>() { Entity = null, Success = true, ResponseMessage = "Request Success!" };
                }
                catch (Exception ex)
                {
                    return new ApiViewModel<T>() { Success = false, ResponseMessage = ex.Message };
                }
            }
        }

        public async Task<ApiViewModel<T>> Delete<T>(string url, T data) where T : class
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("x-api-key", _apiKey);

                    url = $"http://localhost:55291/api/{url}";
                    string serialized = JsonSerializer.Serialize(data);
                    HttpResponseMessage response = await client.DeleteAsync(url);
                    var result = response.Content.ReadAsStringAsync().Result;

                    return new ApiViewModel<T>() { Entity = null, Success = true, ResponseMessage = "Request Success!" };
                }
                catch (Exception ex)
                {
                    return new ApiViewModel<T>() { Success = false, ResponseMessage = ex.Message };
                }
            }
        }
    }
}
