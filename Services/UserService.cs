using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using pobreTITO_Models;

namespace pobreTITO_Services
{
    public static class UserService
    {
#pragma warning disable CS8618
        private static UserManager<User> userManager;
        private static SignInManager<User> signInManager;
        private static PobretitoDbContext context;


        public static void SetManagers(IApplicationBuilder app)
        {
            userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<User>>();
            signInManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<SignInManager<User>>();
            context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PobretitoDbContext>();
        }

        public async static Task<Response> Register(RegisterViewModel register)
        {
            Response response = new();

            if (!HaveObjectNulls(register))
            {
                bool alredyExistsUserEmail = context.Users.Where(x => x.Email == register.Email).Equals(null);
                bool alredyExistsDNI = context.Users.Where(x => x.DNI == register.Id).Equals(null);

                if (!alredyExistsUserEmail && !alredyExistsDNI)
                {
                    IdentityUser a = new();

                    User user = new()
                    {
                        DNI = register.Id,
                        Name = register.Name,
                        Lastname = register.Lastname,
                        UserName = register.Email,
                        Email = register.Email
                    };

                    response.StateExecution = (await userManager.CreateAsync(user, register.Password)).Succeeded;

                    if (response.StateExecution)
                    {
                        await signInManager.SignOutAsync();
                        var temp = await LoginProcess(user, register.Password);
                    }
                }

                else
                {
                    response.StateExecution = false;

                    if (alredyExistsUserEmail)
                    {
                        response.Messages.Add("el email ya esta registrado");
                    }
                    if (alredyExistsDNI)
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
                User user = await userManager.FindByEmailAsync(request.Email);

                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    response = await LoginProcess(user, request.Password);
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


        public async static Task<Response> LoginProcess(User user, string password)
        {
            Response response = new();
            if ((await signInManager.PasswordSignInAsync(user, password, false, false)).Succeeded)
            {
                response.StateExecution = true;
            }
            else
            {
                response.StateExecution = false;
                response.Messages.Add("La constraseña es incorrecta.");
            }
            return response;
        }

        public async static Task Logout() => await signInManager.SignOutAsync();


        private static bool HaveObjectNulls(RegisterViewModel register)
        {
            if (String.IsNullOrEmpty(register.Id) || String.IsNullOrEmpty(register.Name) || String.IsNullOrEmpty(register.Lastname) || String.IsNullOrEmpty(register.Email) || String.IsNullOrEmpty(register.Password))
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