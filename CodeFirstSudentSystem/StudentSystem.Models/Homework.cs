using System;
using Microsoft.Build.Framework;

namespace StudentSystem.Models
{
    public enum ContentType
    {
        Application, PDF, ZIP
    }

    public class Homework
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}