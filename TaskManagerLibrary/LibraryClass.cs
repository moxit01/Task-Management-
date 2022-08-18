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

            var headers = response.Headers;

            IEnumerable<string> val;
            if (headers.TryGetValues("Authorization", out val))
            {
                string auth0MgtToken = val.First();
                return (status, responseString, auth0MgtToken);
            }

            return (404, responseString, "");
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
            var headers = response.Headers;

            IEnumerable<string> val;
            if (headers.TryGetValues("Authorization", out val))
            {
                string auth0MgtToken = val.First();
                return (status, responseString, auth0MgtToken);
            }

            return (404, responseString, "");
        }

        public static async Task<(int, String)> CreateProjectRequest(Dictionary<string, object> values)
        {
            string Serialized = JsonConvert.SerializeObject(values);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent content = new StringContent(Serialized, Encoding.Unicode, "application/json");

            var response = await client.PostAsync(Constants.CreateProjectAPI, content);
            var status = (int)response.StatusCode;

            var responseString = await response.Content.ReadAsStringAsync();

            return (status, responseString);
        }

        public static async Task<String> GetUsers(string token)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync(Constants.GetUsers);

            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseString);

            return responseString;
        }
    }

}