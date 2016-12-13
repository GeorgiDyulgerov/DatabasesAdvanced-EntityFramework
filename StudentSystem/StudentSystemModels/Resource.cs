using Microsoft.Build.Framework;

namespace StudentSystem.Models
{
    public enum ResourceType
    {
        Video, Presentation, Document, Other
    }

    public class Resource
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual Course Course { get; set; }

    }
}
