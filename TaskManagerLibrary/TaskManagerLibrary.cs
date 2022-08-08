namespace TaskManagerLibrary;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

public class TaskManagerLibrary
{
    private static readonly HttpClient client = new HttpClient();

    public static async Task<(int, String)> SignUpRequest(Dictionary<string, string> values)
    {
        //var content = new FormUrlEncodedContent(values);

        string Serialized = JsonConvert.SerializeObject(values);

        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpContent content = new StringContent(Serialized, Encoding.Unicode, "application/json");

        var response = await client.PostAsync(Constants.SignUpAPI, content);
        var status = (int)response.StatusCode;

        var responseString = await response.Content.ReadAsStringAsync();

        return (status, responseString);
    }

    public static async Task<String> SignInRequest(Dictionary<string, string> values)
    {
        //var content = new FormUrlEncodedContent(values);

        string Serialized = JsonConvert.SerializeObject(values);

        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpContent content = new StringContent(Serialized, Encoding.Unicode, "application/json");

        var response = await client.PostAsync(Constants.SignInAPI, content);

        var responseString = await response.Content.ReadAsStringAsync();

        Console.WriteLine(responseString);

        return responseString;
    }
}

