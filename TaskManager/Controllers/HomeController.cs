using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers;

//public class FromViewModel
//{

//    [Required]
//    [Display(Name = "Project Name")]
//    public string Name { get; set; }

//    [Required]
//    [Display(Name = "Description")]
//    public string Desc { get; set; }

//    [Required]
//    [DataType(DataType.Date)]
//    [Display(Name = "Start Date")]
//    public DateTime StartDate { get; set; } = DateTime.Now;

//}



public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Project()
    {   
        return View();
    }

    public IActionResult ProjectLists()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

