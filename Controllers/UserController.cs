using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using pobreTITO_Models;
using pobreTITO_Services;

#pragma warning disable 1998


namespace pobreTITO.Controllers;
public class UserController : Controller
{
#pragma warning disable CS8618
    private readonly ILogger<UserController> _logger;
    private readonly PobretitoDbContext _context;
    private ErrorMessage message = new();
#pragma warning restore CS8618

    public UserController(ILogger<UserController> logger, PobretitoDbContext context)
    {
        _logger = logger;
        _context = context;
    }


    [Route("/Gestor")]
    public async Task<IActionResult> Index() => View();

    [Route("/AgregarReporte")]
    public async Task<IActionResult> AddReport() => View();
    [Route("/Logout")]
    public async Task<IActionResult> Logout()
    {
        UserService.Logout();
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Create(RegisterViewModel request)
    {
        ClearMessageList();
        if (ModelState.IsValid)
        {
            Response response = await UserService.Register(request, _context);

            if (response.StateExecution)
            {
                return View("Index");
            }
            else
            {
                message.Messages = response.Messages;
                return RedirectToAction("Register", "Home", message);
            }
        }
        else
        {
            message.Messages.Add("Oops parece que hubo registrando el usuario, pruebe más tarde.");
            return RedirectToAction("Register", "Home", message);
        }
    }

    public async Task<IActionResult> Login(LoginViewModel request)
    {
        ClearMessageList();
        if (ModelState.IsValid)
        {
            Response response = await UserService.Login(request);

            if (response.StateExecution)
            {
                return View("Index");
            }
            else
            {
                message.Messages = response.Messages;
                return RedirectToAction("Login", "Home", message);
            }
        }
        else
        {
            message.Messages.Add("Oops parece que hubo en el inicio de sesión, pruebe más tarde.");
            return RedirectToAction("Login", "Home", message);
        }
    }

    private void ClearMessageList()
    {
        message.Messages = new();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
