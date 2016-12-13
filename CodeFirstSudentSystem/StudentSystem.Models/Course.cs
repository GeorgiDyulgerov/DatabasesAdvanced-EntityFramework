using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace StudentSystem.Models
{
    public class Course
    {
        public Course()
        {
            this.Students = new List<Student>();
            this.Resources = new List<Resource>();
            this.Homeworks = new List<Homework>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
