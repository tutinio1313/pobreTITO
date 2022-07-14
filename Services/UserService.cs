using Microsoft.AspNetCore.Mvc;
using pobreTITO_response;
using pobreTITO_Models;
using System.Collections.Generic;
using pobreTITO;

namespace pobreTITO_Services
{
    public static class UserService
    {

        public static Response Register(RegisterViewModel register)
        {
            List<User> users = Listas.GetUsers();

            Response response = new Response();
            response.Messages = new List<string>();

            bool existsUserID = users.Exists(x => x.ID == register.id);
            bool existsUserEmail = users.Exists(x => x.Email ==register.email);
            bool areEmailEquals = register.email.Equals(register.emailConfimation);
            bool arePasswordsEquals = register.email.Equals(register.emailConfimation);


            if (!existsUserID && !existsUserEmail && !areEmailEquals && !arePasswordsEquals) 
            {
                response.StateExecution = true;

                User user = new User
                {
                    ID = register.id,
                    Name = register.name,
                    Lastname = register.lastname,
                    Email = register.email,
                    Password = register.password
                };

                Listas.AddUser(user);
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
    }
}