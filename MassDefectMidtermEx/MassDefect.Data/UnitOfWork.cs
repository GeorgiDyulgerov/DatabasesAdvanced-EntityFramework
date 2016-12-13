using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassDefect.Data.Interfaces;
using MassDefect.Models;

namespace MassDefect.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private MassDefectContext context;
        private IRepository<SolarSystem> solarSystems;
        private IRepository<Star> stars;
        private IRepository<Planet> planets;
        private IRepository<Person> persons;
        private IRepository<Anomaly> anomalies;


        public UnitOfWork()
        {
            this.context = new MassDefectContext();
        }


        public IRepository<SolarSystem> SolarSystems => this.solarSystems 
            ?? (this.solarSystems = new Repository<SolarSystem>(this.context.SolarSystems));

        public IRepository<Star> Stars => this.stars
            ?? (this.stars = new Repository<Star>(this.context.Stars));

        public IRepository<Planet> Planets => this.planets
            ?? (this.planets = new Repository<Planet>(this.context.Planets));

        public IRepository<Person> Persons => this.persons
            ?? (this.persons = new Repository<Person>(this.context.Persons));

        public IRepository<Anomaly> Anomalies => this.anomalies
            ?? (this.anomalies = new Repository<Anomaly>(this.context.Anomalies));

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
