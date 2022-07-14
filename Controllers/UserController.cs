using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using pobreTITO_models;
using pobreTITO_response;
#pragma warning disable 1998

namespace pobreTITO.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    public async Task<Response> Register(RegisterViewModel register)
    {
        Response response = new Response();
        bool existsUserID = Listas.ExistsUser(register.id);
        bool existsUserEmail = Listas.ExistsUser(register.email);


        if (!existsUserID && !existsUserEmail)
        {
            response.StateExecution = true;
            response.Messages.Add("Se ha creado la cuenta.");

            User user = new User();

            user.ID = register.id;
            user.Name = register.name;
            user.Lastname = register.lastname;
            user.Email = register.email;
        }

        else
        {
            response.StateExecution = false;
            if (existsUserID && existsUserEmail)
            {
                response.Messages.Add("El dni ya esta registrado.");
                response.Messages.Add("El email ya esta registrado.");
            }
            else
            {
                if (existsUserEmail)
                {
                    response.Messages.Add("el email ya esta registrado");
                }
                else
                {
                    response.Messages.Add("El dni ya esta registrado.");
                }
            }
        }

        return response;
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
