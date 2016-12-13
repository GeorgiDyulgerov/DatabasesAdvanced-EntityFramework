using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace MassDefect.Models
{
    public class SolarSystem
    {
        public SolarSystem()
        {
            this.Planets=new HashSet<Planet>();
            this.Stars = new HashSet<Star>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Star> Stars { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }
    }
}
