using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using pobreTITO_models;
#pragma warning disable CS8618
#pragma warning disable CS8601
#pragma warning disable CS8602

namespace pobreTITO
{
    public class Listas
    {
        private static Listas? listas;

        private static string userJsonPath = Directory.GetCurrentDirectory() + "/db/user.json";

        private static List<User> users;
        private Listas()
        {

        }

        public static List<User> GetUsers()
        {
            if (listas == null)
            {
                CreateLists();
            }
            return users;
        }

        public static bool ExistsUser(string ID)
        {
            if (!ID.Contains("@"))
            {
                return users.Exists(x => x.ID == ID);
            }
            else
            {
                return users.Exists(x => x.Email == ID);
            }
        }
        private static void CreateLists()
        {

            if (listas == null)
            {
                listas = new Listas();

                string jsonUser = System.IO.File.ReadAllText(userJsonPath);

                users = JsonConvert.DeserializeObject<List<User>>(jsonUser);

                users.Sort(delegate (User UserA, User UserB)
                {
                    if (UserA.ID == null && UserB.ID == null) return 0;
                    else if (UserA.ID == null) return -1;
                    else if (UserB.ID == null) return 1;
                    else return UserA.ID.CompareTo(UserB.ID);
                }
                );

                if (users == null)
                {
                    users = new List<User>();
                }
            }
        }

        public static void AddUser(User User)
        {
            users.Add(User);
            SaveUser();
        }

        public static void RemoveUser(User User)
        {
            users.Remove(User);
            SaveUser();
        }
        /* public static User ModifyUser(UserPutRequest request ,User User)
        {
            if(request.Domicilio != null)
            {
                User.Domicilio = request.Domicilio;
            }
            if(request.Email != null)
            {
                User.Email = request.Email;
            }
            if(request.Telefono != null)
            {
                User.Telefono = request.Telefono;
            }
            if(request.Localidad != null)
            {
                User.Localidad = request.Localidad; 
            }
            if(request.Domicilio != null)
            {
                User.Domicilio = request.Domicilio;
            }
            User.EstaEnfermo = request.EstaEnfermo;
            User.EstaMedicado = request.EstaMedicado;
            User(User);
            User(User);
            return User;
        } */

        private static void SaveUser()
        {
            string temp = JsonConvert.SerializeObject(users);
            System.IO.File.WriteAllText(userJsonPath, temp);
        }
    }
}