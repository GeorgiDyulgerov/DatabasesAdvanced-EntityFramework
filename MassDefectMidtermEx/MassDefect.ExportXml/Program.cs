using System.Linq;
using System.Xml.Linq;
using MassDefect.Data;

namespace MassDefect.ExportXml
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unit = new UnitOfWork();

            var exportedAnomalies = unit.Anomalies.GetAll().Select(anom=> new
            {
                anom.Id,
                originPlanet = anom.OriginPlanet.Name,
                teleportPlanet = anom.TeleportPlanet.Name,
                victims = anom.Victims.Select(person=>person.Name)
            });

            var xmlDocument = new XElement("anomalies");

            foreach (var exportedAnomaly in exportedAnomalies)
            {
                var anomalyNode = new XElement("anomaly");
                anomalyNode.Add(new XAttribute("id",exportedAnomaly.Id));
                anomalyNode.Add(new XAttribute("origin-planet",exportedAnomaly.originPlanet));
                anomalyNode.Add(new XAttribute("teleport-planet",exportedAnomaly.teleportPlanet));

                var victimsNode = new XElement("victims");

                foreach (var victim in exportedAnomaly.victims)
                {
                    var victimNode = new XElement("victim");
                    victimNode.Add(new XAttribute("name",victim));
                    victimsNode.Add(victimNode);
                }

                anomalyNode.Add(victimsNode);
                xmlDocument.Add(anomalyNode);
            }

            xmlDocument.Save("../../anomalies.xml");

        }
    }
}
