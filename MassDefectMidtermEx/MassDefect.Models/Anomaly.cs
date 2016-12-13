using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace MassDefect.Models
{
    public class Anomaly
    {
        public Anomaly()
        {
            this.Victims=new HashSet<Person>();
        }

        public int Id { get; set; }

        public virtual Planet OriginPlanet { get; set; }

        public virtual Planet TeleportPlanet { get; set; }

        public virtual ICollection<Person> Victims { get; set; }

    }
}
