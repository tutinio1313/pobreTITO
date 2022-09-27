using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using pobreTITO_Models;
using pobreTITO;

namespace pobreTITO_Services
{
    public static class UserService
    {
        private static UserManager<User> userManager;
        private static SignInManager<User> signInManager;
        private  static PobretitoDbContext context;

        public static void SetManagers(IApplicationBuilder app)
        {
            userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<User>>();
            signInManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<SignInManager<User>>();
        }

        public async static Task<Response> Register(RegisterViewModel register)
        {

            Response response = new();
        
            bool ExistsUserEmail = userManager.FindByEmailAsync(register.email).Equals(null);
            bool areEmailEquals = register.email.Equals(register.emailConfimation);
            bool arePasswordsEquals = register.email.Equals(register.emailConfimation);

            if (!HaveObjectNulls(register))
            {
                DbContextOptions contextOptions = new DbContextOptionsBuilder<PobretitoDbContext>().UseSqlite("Data Source=db/pobretito.sqlite; Cache=default").Options;
                if (!ExistsUserEmail && areEmailEquals && arePasswordsEquals)
                {
                    response.StateExecution = true;
                    User user = new()
                    {
                        DNI = register.id,
                        Name = register.name,
                        Lastname = register.lastname,
                        UserName = register.email,
                        Email = register.email
                    };

                    await userManager.CreateAsync(user, register.password);
                }

                else
                {
                    response.StateExecution = false;

                    if (ExistsUserEmail)
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
            Response response = new();
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