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
        }

        public async static Task<Response> Register(RegisterViewModel register, PobretitoDbContext context)
        {
            Response response = new();

            if (!HaveObjectNulls(register))
            {
                bool alredyExistsUserEmail = context.Users.Where(x => x.Email == register.email).Equals(null);
                bool alredyExistsDNI = context.Users.Where(x => x.DNI == register.id).Equals(null);

                if (!alredyExistsUserEmail && !alredyExistsDNI)
                {
                    IdentityUser a = new();
                    
                    User user = new()
                    {
                        DNI = register.id,
                        Name = register.name,
                        Lastname = register.lastname,
                        UserName = register.email,
                        Email = register.email
                    };

                    

                   var abc = await userManager.CreateAsync(user, register.password);
                   response.StateExecution = abc.Succeeded;
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
                User user = await userManager.FindByEmailAsync(request.email);

                if (user != null)
                {
                    //await signInManager.SignOutAsync();
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

        public async static void Logout()
        {
            await signInManager.SignOutAsync();
        }

        private static bool HaveObjectNulls(RegisterViewModel register)
        {
            if (String.IsNullOrEmpty(register.id) || String.IsNullOrEmpty(register.name) || String.IsNullOrEmpty(register.lastname) || String.IsNullOrEmpty(register.email) || String.IsNullOrEmpty(register.password))
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