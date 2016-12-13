using System;
using System.Collections.Generic;
using System.Xml.XPath;
using MassDefect.Data;
using MassDefect.Models;

namespace MassDefect.ImportXml
{
    using System.Xml.Linq;
    class Program
    {
        private const string NewAnomaliesPath = "../../../datasets/new-anomalies.xml";
        private const string Error = "Error: Invalid data";

        static void Main()
        {
            UnitOfWork unit = new UnitOfWork();

            var xml = XDocument.Load(NewAnomaliesPath);
            var anomalies = xml.XPathSelectElements("anomalies/anomaly");

            foreach (var anomaly in anomalies)
            {
                ImportAnomalyAndVictims(anomaly, unit);
                
            }

            unit.Commit();
        }

        private static void ImportAnomalyAndVictims(XElement anomalyNode, UnitOfWork unit)
        {
            var originPlanetName = anomalyNode.Attribute("origin-planet");
            var teleportPlanetName = anomalyNode.Attribute("teleport-planet");
            if (originPlanetName == null || teleportPlanetName == null)
            {
                Console.WriteLine(Error);
            }
            else
            {
                var originPlanet = unit.Planets.First(planet => planet.Name == originPlanetName.Value);
                var teleportPlanet = unit.Planets.First(planet => planet.Name == teleportPlanetName.Value);
                if (originPlanet == null || teleportPlanet == null)
                {
                    Console.WriteLine(Error);
                }
                else
                {
                    Anomaly anomaly = new Anomaly()
                    {
                        OriginPlanet = originPlanet,
                        TeleportPlanet = teleportPlanet,
                        Victims = new List<Person>()
                    };
                    unit.Anomalies.Add(anomaly);

                    Console.WriteLine($"Successfuly imported anomaly");

                    var victims = anomalyNode.XPathSelectElements("victims/victim");
                    foreach (var victim in victims)
                    {
                        ImportVictim(victim, unit, anomaly);
                    }
                }
            }
        }

        private static void ImportVictim(XElement victimNode, UnitOfWork unit, Anomaly anomaly)
        {
            var name = victimNode.Attribute("name");
            if (name == null)
            {
                Console.WriteLine(Error);
            }
            else
            {
                var victim = unit.Persons.First(person => person.Name == name.Value);
                if (victim == null)
                {
                    Console.WriteLine(Error);
                }
                else
                {
                    anomaly.Victims.Add(victim);
                }
            }
        }
    }
}
