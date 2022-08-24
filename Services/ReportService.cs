using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pobreTITO_response;
using pobreTITO_Models;
using System.Collections.Generic;
using pobreTITO;

namespace pobreTITO_Services
{
    public static class ReportService
    {
        public async static Task<Response> Register(RegisterViewModel register, UserManager<IdentityUser> userManager)
        {

            Response response = new Response();
            response.Messages = new List<string>();

            bool existsUserEmail;

            if (userManager.FindByEmailAsync(register.email) != null)
            {
                existsUserEmail = true;
            }
            else
            {
                existsUserEmail = false;
            }
            bool modelContainsNulls = HaveObjectNulls(register);
            bool areEmailEquals = register.email.Equals(register.emailConfimation);
            bool arePasswordsEquals = register.email.Equals(register.emailConfimation);

            if (modelContainsNulls)
            {
                if (!existsUserEmail && areEmailEquals && arePasswordsEquals)
                {
                    response.StateExecution = true;

                    User user = new User
                    {
                        DNI = register.id,
                        Name = register.name,
                        Lastname = register.lastname,
                        Email = register.email,
                    };

                    await userManager.CreateAsync(user, register.password);
                }

                else
                {
                    response.StateExecution = false;

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

            else
            {                
                response.StateExecution = false;
                response.Messages.Add("Oops parece que los datos ingresados no son correctos.");
            }


            return response;
        }

            private static bool HaveObjectNulls(RegisterViewModel register)
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
    }
}