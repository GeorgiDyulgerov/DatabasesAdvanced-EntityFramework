using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;
using StudentSystem.Models;

namespace CodeFirstStudentSystem.Client
{
    class Program
    {
        static void Main()
        {
            var context = new StudentSystemContext();

            context.Students.Add(new Student
            {
                Name = "pe6",
                PhoneNumber = "24353636",
                RegistrationDate = DateTime.Now
            });

            context.SaveChanges();


        }
    }
}
