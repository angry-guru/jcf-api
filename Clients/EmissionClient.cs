using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using jcf_api.Types;

namespace jcf_api.Clients
{
    public class EmissionClient : ApiClient
    {
        private const string AdminUrl = "wp-admin/admin-ajax.php";

        public EmissionClient(Uri clientUri) 
            : base(clientUri)
        {   
        }

        public async Task<CarbonFootprintResponse> GetHotelEmission(double numberDaysPerYear)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

            var formData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("action", "calculate_btravel_total_ajax"),
                new KeyValuePair<string, string>("flights_small", string.Empty),
                new KeyValuePair<string, string>("flights_medium", string.Empty),
                new KeyValuePair<string, string>("flights_large", string.Empty),
                new KeyValuePair<string, string>("train", string.Empty),
                new KeyValuePair<string, string>("bus", string.Empty),
                new KeyValuePair<string, string>("hotel", numberDaysPerYear.ToString())
            };

            var form = new FormUrlEncodedContent(formData);

            return await PostFormUrlWithResponse<CarbonFootprintResponse>(AdminUrl, form).ConfigureAwait(false);
        }

        public async Task<CarbonFootprintResponse> GetFlightEmission(double numberOfFlightsPerYear)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

            var formData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("action", "calculate_btravel_total_ajax"),
                new KeyValuePair<string, string>("flights_small", string.Empty),
                new KeyValuePair<string, string>("flights_medium", numberOfFlightsPerYear.ToString()),
                new KeyValuePair<string, string>("flights_large", string.Empty),
                new KeyValuePair<string, string>("train", string.Empty),
                new KeyValuePair<string, string>("bus", string.Empty),
                new KeyValuePair<string, string>("hotel", string.Empty)
            };

            var form = new FormUrlEncodedContent(formData);

            return await PostFormUrlWithResponse<CarbonFootprintResponse>(AdminUrl, form);
        }

        public async Task<CarbonFootprintResponse> GetPaperEmission(double paperWeightPerYear)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

            var formData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("action", "calculate_paper_total_ajax"),
                new KeyValuePair<string, string>("select_paper_type", "1"),
                new KeyValuePair<string, string>("select_recycled", "0"),
                new KeyValuePair<string, string>("pounds_year", paperWeightPerYear.ToString())
            };

            var form = new FormUrlEncodedContent(formData);

            return await PostFormUrlWithResponse<CarbonFootprintResponse>(AdminUrl, form);
        }
    }
}
