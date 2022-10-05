using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pobreTITO_Models;
using pobreTITO_Services;
namespace pobreTITO.Controllers;
#pragma warning disable 1998

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public async Task<IActionResult> Index() => View();
    [Route("/Login")]
    public async Task<IActionResult> Login() => View();
    [Route("/Register")]
    public async Task<IActionResult> Register() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
