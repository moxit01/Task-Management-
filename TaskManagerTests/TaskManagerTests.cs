using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Protocol.Core.Types;
using TaskManagerAPI.Controllers;
using TaskManger.Areas.Identity.Pages.Account;
using System.Security.Claims;
using System.Text;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TaskManagerLibrary;

namespace TaskManagerTests;

[TestClass]
public class TaskManagerTests
{
    private HttpClient _httpClient;

    public TaskManagerTests()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();
    }

    [DataTestMethod]
    [DataRow("name", "emailmail.in", "Qwer1233")]
    public async Task TestEmailValidationFailAsync(string name, string email, string pass)
    {

        var values = new Dictionary<string, string>
                {
                    { "FullName", name },
                    { "email", email },
                    { "password", pass }
                 };
        string Serialized = JsonConvert.SerializeObject(values);

        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpContent content = new StringContent(Serialized, Encoding.Unicode, "application/json");

        var response = await _httpClient.PostAsync(Constants.SignUpAPI, content);
        var status = (int)response.StatusCode;

        Assert.AreNotEqual(200, status);
    }

    [DataTestMethod]
    [DataRow("name", "eaasdsdm@maasil.in", "Qwer123#")]
    public async Task TestEmailValidationSuccessAsync(string name, string email, string pass)
    {
        var values = new Dictionary<string, string>
                {
                    { "FullName", name },
                    { "email", email },
                    { "password", pass }
                 };
        string Serialized = JsonConvert.SerializeObject(values);

        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpContent content = new StringContent(Serialized, Encoding.Unicode, "application/json");

        var response = await _httpClient.PostAsync(Constants.SignUpAPI, content);
        var status = (int)response.StatusCode;

        Assert.AreEqual(200, status);
    }
}
