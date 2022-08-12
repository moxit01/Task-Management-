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
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectControllerTests;




[TestClass]
public class ProjectControllerTests
{

    private HttpClient _httpClient;

    public ProjectControllerTests()
    {
        var webAppFactory = new WebApplicationFactory<Program>();
        _httpClient = webAppFactory.CreateDefaultClient();
    }

    [DataTestMethod]
    [DataRow("Task Management", "This is test project for task management", "2022-10-01", "2022-12-01", new string[] { ""})]
    public async Task TestCreateProjectAsync(string name, string desc, string start, string end, string[] users)
    {

        var values = new Dictionary<string, object>
                {
                    { "Name", name },
                    { "Desc", desc },
                    { "StartDate", start },
                    { "EndDate", end},
                    { "users", users}
                 };
        string Serialized = JsonConvert.SerializeObject(values);

        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpContent content = new StringContent(Serialized, Encoding.Unicode, "application/json");

        var response = await _httpClient.PostAsync(Constants.SignUpAPI, content);
        var status = (int)response.StatusCode;

        Assert.AreNotEqual(200, status);
    }

    [TestMethod]
    [DataRow("")]
    public void GetProjectNotFound(string project)
    {
        var controller = new ProjectController();


        var response = controller.Get(project);

        Assert.IsInstanceOfType(response, typeof(Microsoft.AspNetCore.Mvc.NotFoundResult));

    }



    [TestMethod]
    public async Task GetProjectAsync()
    {

        var apiClient = new HttpClient();
        var apiResponse = await apiClient.GetAsync($"/Project");
        Assert.IsTrue(apiResponse.IsSuccessStatusCode);


        //var webAppFactory = new WebApplicationFactory<Program>();
        //var client = webAppFactory.CreateClient();
        //var response =  client.GetAsync("/Project");
        //response.EnsureSuccessStatusCode();
        //response.StatusCode.Should().Be(HttpStatusCode.OK);

    }


}
