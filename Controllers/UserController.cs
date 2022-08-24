using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

    private UserManager<IdentityUser> userManager;
    private SignInManager<IdentityUser> signInManager;
    [Route("/Gestor")]
    public async Task<IActionResult> Index() => View();

    [Route("/AgregarReporte")]
    public async Task<IActionResult> AddReport() => View();

    [HttpPost]
    public async Task<ViewResult> Create(RegisterViewModel register)
    {

        var response = await UserService.Register(register, userManager);
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
