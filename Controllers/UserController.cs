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
    private readonly ILogger<UserController> _logger;
    private ErrorMessage message = new();
    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }


    [Route("/Gestor")]
    public async Task<IActionResult> Index() => View();

    [Route("/AgregarReporte")]
    public async Task<IActionResult> AddReport() => View();

    [HttpPost]
    public async Task<IActionResult> Create(RegisterViewModel request)
    {
        ClearMessageList();
        if (ModelState.IsValid)
        {
            Response response = await UserService.Register(request);

            if (response.StateExecution)
            {
                return View("Index");
            }
            else
            {                
                message.Messages = response.Messages;
                return PartialView("ErrorPartialView", message);
            }
        }
        else
        {
           message.Messages.Add("Oops parece que hubo registrando el usuario, pruebe más tarde.");
           return PartialView("ErrorPartialView", message);
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
                return PartialView("ErrorPartialView", message);
            }
        }
        else
        {
           message.Messages.Add("Oops parece que hubo en el inicio de sesión, pruebe más tarde.");
           return PartialView("ErrorPartialView", message);
        }
    }

    private void ClearMessageList()
    {
        if(message.Messages.Count > 0)
        {
            message.Messages.Clear();
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
