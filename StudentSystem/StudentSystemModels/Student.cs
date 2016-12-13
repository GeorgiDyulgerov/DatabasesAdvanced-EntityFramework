using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace StudentSystem.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new List<Course>();
            this.Homeworks =new List<Homework>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks{ get; set; }
    }
}
