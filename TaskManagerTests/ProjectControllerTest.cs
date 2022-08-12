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
using TaskManagerAPI.Models;
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
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace ProjectControllerTests;




[TestClass]
public class ProjectControllerTests
{


    [TestMethod]
    public void GetProjectNotFound()
    {
        var controller = new ProjectController();


        var response = controller.Get(1);

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
