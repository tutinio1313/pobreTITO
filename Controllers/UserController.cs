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
#pragma warning restore CS8618

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }


    [Route("/Gestor")]
    public async Task<IActionResult> Index() => View();

    [Route("/AgregarReporte")]
    public async Task<IActionResult> AddReport() => View();
    [Route("/Logout")]
    public async Task<IActionResult> Logout()
    {
        await UserService.Logout();
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Create(RegisterViewModel request)
    {
        IList<string> message = new List<string>();
        if (ModelState.IsValid)
        {
            Response response = await UserService.Register(request);

            if (response.StateExecution)
            {
                return View("Index");
            }
            else
            {
                message = response.Messages;
            }
        }
        else
        {
            message.Add("Oops parece que hubo registrando el usuario, pruebe más tarde.");
        }
        ViewData["messages"] = message[0];
        return RedirectToAction("Register", "Home");
    }

    public async Task<IActionResult> Login(LoginViewModel request)
    {
        IList<string> message = new List<string>();
        if (ModelState.IsValid)
        {
            Response response = await UserService.Login(request);
            if (response.StateExecution)
            {
                return View("Index");
            }
            else
            {
                 message.Add(response.Messages[0]);
            }
        }
        else
        {
            message.Add("Oops parece que hubo en el inicio de sesión, pruebe más tarde.");
        }
        ViewData["messages"] = message[0];
        return RedirectToAction("Login", "Home");
    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
