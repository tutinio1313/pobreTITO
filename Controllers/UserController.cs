using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using pobreTITO_Models;
using pobreTITO_response;
using pobreTITO_Services;

#pragma warning disable 1998

namespace pobreTITO.Controllers;
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }    
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
