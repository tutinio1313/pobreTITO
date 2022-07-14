using System.Diagnostics;
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
    public ViewResult Create(RegisterViewModel register)
    {
        Response response = new Response();

        if (ModelState.IsValid)
        {
            if (!HaveObjectNulls(register))
            {
                response = UserService.Register(register);
            }
        }
        else
        {
            response.StateExecution = false;
            response.Messages = new List<string>();
            response.Messages.Add("Revisa los valores ingresados porque tienes nulos.");
        }
        return View();
    }

    private bool HaveObjectNulls(RegisterViewModel register)
    {
        if (register.id == null || register.name == null || register.lastname == null || register.email == null || register.emailConfimation == null || register.password == null || register.passwordConfirmation == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
