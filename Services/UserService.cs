using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pobreTITO_Models;
using pobreTITO;

namespace pobreTITO_Services
{
    public static class UserService
    {
        private static UserManager<User> userManager;
        private static SignInManager<User> signInManager;

        public static void SetManagers(IApplicationBuilder app)
        {
            PobretitoDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PobretitoDbContext>();

            userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<User>>();
            signInManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<SignInManager<User>>();
        }

        public async static Task<Response> Register(RegisterViewModel register)
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
            bool areEmailEquals = register.email.Equals(register.emailConfimation);
            bool arePasswordsEquals = register.email.Equals(register.emailConfimation);

            if (HaveObjectNulls(register))
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

        public async static Task<Response> Login(LoginViewModel request)
        {
            Response response = new Response();
            try
            {
                User user = await userManager.FindByEmailAsync(request.email);


                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, request.password, false, false)).Succeeded)
                    {
                        response.StateExecution = true;
                        return response;
                    }
                    else
                    {
                        response.StateExecution = false;
                        response.Messages.Add("La constraseña es incorrecta.");
                    }
                }
                else
                {
                    response.StateExecution = false;
                    response.Messages.Add("El email ingresado es incorrecto.");
                }
            }
            catch (System.Exception)
            {
                throw;
            }


            return response;
        }

        private static bool HaveObjectNulls(RegisterViewModel register)
        {
            if (String.IsNullOrEmpty(register.id) || String.IsNullOrEmpty(register.name) || String.IsNullOrEmpty(register.lastname) || String.IsNullOrEmpty(register.email) || String.IsNullOrEmpty(register.emailConfimation) || String.IsNullOrEmpty(register.password) || String.IsNullOrEmpty(register.passwordConfirmation))
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