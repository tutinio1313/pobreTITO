using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pobreTITO_Models;
using pobreTITO_Services;
using pobreTITO_response;

namespace pobreTITO.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    private UserManager<IdentityUser> userManager;
    private SignInManager<IdentityUser> signInManager;

    public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public ViewResult Login()
    {
        return View();
    }
    [HttpGet]
    public ViewResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<ViewResult> Create(RegisterViewModel register)
    {
      
         var response = await UserService.Register(register, userManager);

        return View();
    }

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
