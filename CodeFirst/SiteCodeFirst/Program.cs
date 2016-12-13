using System;
using System.Linq;
using SiteCodeFirst.Models;

namespace SiteCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {   
            var context = new SiteCodeFirstContext();

            User gUser = new User()
            {
                FirstName = "George",
                LastName = "Dyulg",
                Username = "Go6koy",
                RegisteredOn = DateTime.Now,
                Age = 21,
                Password = "Go6k0y!",
                Email = "some@aefa.sas"
                

            };

            context.Users.Add(gUser);
            context.SaveChanges();
            var users = context.Users;

            foreach (var user in users)
            {
                Console.WriteLine(user.FullName);
            }



        }
    }
}
