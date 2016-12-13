using System;
using System.IO;
using System.Linq;
using MassDefect.Data;
using Newtonsoft.Json;

namespace MassDefect.ExportJson
{
    class Program
    {
        static void Main()
        {
            UnitOfWork unit = new UnitOfWork();

            ExportPlanetsWhichAreNotAnomalyOrigins(unit);
            ExportPeopleWhichHaveNotBeenVictims(unit);
            ExportTopAnomaly(unit);


        }

        private static void ExportPlanetsWhichAreNotAnomalyOrigins(UnitOfWork unit)
        {
            var exportedPlanets =
                unit.Planets.GetAll(planet => planet.OriginOfAnomalies.Count == 0)
                .Select(planet => planet.Name);
            var json = JsonConvert.SerializeObject(exportedPlanets, Formatting.Indented);
            File.WriteAllText("../../planets.json", json);
        }

        private static void ExportPeopleWhichHaveNotBeenVictims(UnitOfWork unit)
        {
            var people = unit.Persons
                .GetAll(person => person.Anomalies.Count == 0)
                .Select(person =>
                new
                {
                    person.Name,
                    homePlanet = new
                    {
                        person.HomePlanet.Name
                    }
                });

            string json = JsonConvert.SerializeObject(people, Formatting.Indented);
            File.WriteAllText("../../people.json", json);

        }

        private static void ExportTopAnomaly(UnitOfWork unit)
        {
            var anomaly = unit.Anomalies.GetAll().OrderByDescending(anomaly1 => anomaly1.Victims.Count).Take(1).Select(
    anomaly1 => new
    {
        id = anomaly1.Id,
        originPlanet = new
        {
            name = anomaly1.OriginPlanet.Name
        },
        teleportPlanet = new
        {
            name = anomaly1.TeleportPlanet.Name
        },
        victimsCount = anomaly1.Victims.Count
    });

            string json = JsonConvert.SerializeObject(anomaly, Formatting.Indented);
            File.WriteAllText("../../topAnomaly.json", json);
        }
    }
}
