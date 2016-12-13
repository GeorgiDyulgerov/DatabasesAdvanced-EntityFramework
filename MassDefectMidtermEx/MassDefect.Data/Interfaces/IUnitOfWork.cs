using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassDefect.Models;

namespace MassDefect.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<SolarSystem> SolarSystems { get; }

        IRepository<Star> Stars{ get; }

        IRepository<Planet> Planets{ get; }

        IRepository<Person> Persons{ get; }

        IRepository<Anomaly> Anomalies{ get; }

        void Commit();

    }
}
