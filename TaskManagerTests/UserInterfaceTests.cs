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
using ProjectPages.Areas.Identity.Pages.Account;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using TaskManagerLibrary;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;

namespace UserInterfaceTests;

[TestClass]
public class UserInterfaceTests
{

    IWebDriver _driver;

    [TestInitialize]
    public void Startup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        _driver = new ChromeDriver();
    }


    [TestMethod]
    public void TestLoginTitle()
    {
        _driver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Login");
        Assert.AreEqual("Log in", _driver.Title);

        _driver.Quit();
    }


    [TestMethod]
    public void TestRegisterTitle()
    {
        _driver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Register");
        Assert.AreEqual("Regsiter", _driver.Title);

        _driver.Quit();
    }


}
