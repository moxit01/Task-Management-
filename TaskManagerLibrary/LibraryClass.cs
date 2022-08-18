using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace TaskManagerLibrary
{

    public class LibraryClass
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<(int, String, string)> SignUpRequest(Dictionary<string, string> values)
        {
            string Serialized = JsonConvert.SerializeObject(values);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent content = new StringContent(Serialized, Encoding.Unicode, "application/json");

            var response = await client.PostAsync(Constants.SignUpAPI, content);
            var status = (int)response.StatusCode;

            var responseString = await response.Content.ReadAsStringAsync();

            JObject jsonResult = response.Content.ReadAsAsync<JObject>().Result;
            string auth0MgtToken = jsonResult.Value<string>("Authorization");

            return (status, responseString, auth0MgtToken);
        }

        public static async Task<(int, String, string)> SignInRequest(Dictionary<string, string> values)
        {
            string Serialized = JsonConvert.SerializeObject(values);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent content = new StringContent(Serialized, Encoding.Unicode, "application/json");

            var response = await client.PostAsync(Constants.SignInAPI, content);

            var responseString = await response.Content.ReadAsStringAsync();
            var status = (int)response.StatusCode;

            JObject jsonResult = response.Content.ReadAsAsync<JObject>().Result;
            string auth0MgtToken = jsonResult.Value<string>("Authorization");

            return (status, responseString, auth0MgtToken);
        }

        public static async Task<String> CreateProjectRequest(Dictionary<string, string> values)
        {
            string Serialized = JsonConvert.SerializeObject(values);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent content = new StringContent(Serialized, Encoding.Unicode, "application/json");

            var response = await client.PostAsync(Constants.CreateProjectAPI, content);

            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseString);

            return responseString;
        }

        public static async Task<String> GetUsers(Dictionary<string, string> values)
        {
            string Serialized = JsonConvert.SerializeObject(values);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent content = new StringContent(Serialized, Encoding.Unicode, "application/json");

            var response = await client.PostAsync(Constants.GetUsers, content);

            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseString);

            return responseString;
        }
    }

}