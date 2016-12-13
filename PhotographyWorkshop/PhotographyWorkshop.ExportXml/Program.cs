using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using PhotographyWorkshop.Data;

namespace PhotographyWorkshop.ExportXml
{
    class Program
    {
        static void Main()
        {
            var context = new PhotographyWorkshopContext();

            WorkShopByLocation(context);
            SameCameraPhotographers(context);


        }

        private static void SameCameraPhotographers(PhotographyWorkshopContext context)
        {
            var photographers =context.Photographers
                .Where(p => p.PrimaryCamera.Make == p.SecondaryCamera.Make && p.Lenses.Count > 0);

            var xmlDocument = new XElement("photographers");

            foreach (var photographer in photographers)
            {
                var photographerNode = new XElement("photographer");

                photographerNode.Add(new XAttribute("name", $"{photographer.FirstName} {photographer.LastName}"));
                photographerNode.Add(new XAttribute("primary-camera",$"{photographer.PrimaryCamera.Make} {photographer.PrimaryCamera.Model}"));

                var lensesNode = new XElement("lenses");

                foreach (var lense in photographer.Lenses)
                {
                    var lensNode = new XElement("lens");
                    lensNode.Value = $">{lense.Make} {lense.FocalLength}mm f{lense.MaxAperture}";
                    lensesNode.Add(lensNode);
                }

                photographerNode.Add(lensesNode);

                xmlDocument.Add(photographerNode);
            }

            xmlDocument.Save("../../../result/same-cameras-photographers.xml");


        }

        private static void WorkShopByLocation(PhotographyWorkshopContext context)
        {
            var workshops = context.Workshops.Where(work => work.Participants.Count > 5).OrderBy(work => work.Location);

            var xmlDocumet = new XElement("locations");

            foreach (var workshop in workshops)
            {
                var locationNode = new XElement("location");
               
                locationNode.Add(new XAttribute("name",workshop.Location));

                var workshopsNode = new XElement("workshop");
                var totalProfit = (workshop.Participants.Count*workshop.PricePerParticipant) - ((workshop.Participants.Count * workshop.PricePerParticipant) / 0.2m);
                workshopsNode.Add(new XAttribute("name",workshop.Name));
                workshopsNode.Add(new XAttribute("total-profit",totalProfit));

                var participantsNode = new XElement("participants");
                participantsNode.Add(new XAttribute("count",workshop.Participants.Count));

                foreach (var participant in workshop.Participants)
                {
                    var participantNode = new XElement("participant");
                    participantNode.Value = $"{participant.FirstName} {participant.LastName}";
                    participantsNode.Add(participantNode);
                }

                workshopsNode.Add(participantsNode);
                locationNode.Add(workshopsNode);
                
                xmlDocumet.Add(locationNode);
            }

            xmlDocumet.Save("../../../result/workshop-by-location.xml");
        }
    }
}
