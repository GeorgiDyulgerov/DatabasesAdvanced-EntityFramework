using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace MassDefect.Models
{
    public class Planet
    {
        public Planet()
        {
            this.Persons = new HashSet<Person>();
            this.OriginOfAnomalies = new HashSet<Anomaly>();
            this.TeleportOfAnomalies = new HashSet<Anomaly>();
            
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual SolarSystem SolarSystem { get; set; }

        public virtual Star Sun { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

        public virtual ICollection<Anomaly> OriginOfAnomalies { get; set; }

        public virtual ICollection<Anomaly> TeleportOfAnomalies{ get; set; }
    }
}
