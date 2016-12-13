namespace MassDefect.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using  MassDefect.Models;

    public class MassDefectContext : DbContext
    {

        public MassDefectContext()
            : base("name=MassDefect")
        {
        }

        public virtual DbSet<SolarSystem> SolarSystems { get; set; }
        public virtual DbSet<Star> Stars{ get; set; }
        public virtual DbSet<Planet> Planets{ get; set; }
        public virtual DbSet<Person> Persons{ get; set; }
        public virtual DbSet<Anomaly> Anomalies{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Anomaly>().HasOptional(anom => anom.OriginPlanet)
                .WithMany(planet => planet.OriginOfAnomalies)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Anomaly>().HasOptional(anom => anom.TeleportPlanet)
                .WithMany(planet=>planet.TeleportOfAnomalies)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Anomaly>().HasMany(anom => anom.Victims)
                .WithMany(person => person.Anomalies)
                .Map(configuration =>
                {
                    configuration.MapLeftKey("AnomalyId");
                    configuration.MapRightKey("PersonId");
                    configuration.ToTable("AnomalyVictims");
                });

            modelBuilder.Entity<Person>().HasRequired<Planet>(per => per.HomePlanet).WithMany(pl => pl.Persons);

            base.OnModelCreating(modelBuilder);
        }
    }

}