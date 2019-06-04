using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace jcf_api.Clients
{
    public abstract class ApiClient
    {
        protected readonly HttpClient client;

        protected ApiClient(Uri baseAddressUri)
        {
            client = new HttpClient { BaseAddress = baseAddressUri };
        }

        protected async Task<T> Get<T>(string path)
        {
            var response = await client.GetAsync(path).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<T>(content);
            }

            return default(T);
        }

        protected async Task<T> PostFormUrlWithResponse<T>(string path, FormUrlEncodedContent form)
        {
            var response = await client.PostAsync(path, form).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonConvert.DeserializeObject<T>(responseString);
            }

            return default(T);
        }
    }
}
