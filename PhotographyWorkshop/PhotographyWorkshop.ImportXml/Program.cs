using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using PhotographyWorkshop.Data;
using PhotographyWorkshop.Models;

namespace PhotographyWorkshop.ImportXml
{
    class Program
    {
        private const string AccessoriesPath = "../../../datasets/accessories.xml";
        private const string WorkshopsPath = "../../../datasets/workshops.xml";
        private const string Error = "Error. Invalid data provided";

        static void Main()
        {
            var context = new PhotographyWorkshopContext();

            ImportAccessories(context);
            ImportWorkshops(context);


        }

        private static void ImportAccessories(PhotographyWorkshopContext context)
        {
            var xml = XDocument.Load(AccessoriesPath);
            var accessories = xml.XPathSelectElements("accessories/accessory");

            foreach (var accessory in accessories)
            {
                Random rand = new Random();
                Photographer photographer = context.Photographers.Find(rand.Next(1, context.Photographers.Count()));
                Accessory acc = new Accessory
                {
                    Name = accessory.Attribute("name").Value,
                    Owner = photographer
                };

                context.Accessories.Add(acc);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported {acc.Name}");

            }

        }

        private static void ImportWorkshops(PhotographyWorkshopContext context)
        {
            var xml = XDocument.Load(WorkshopsPath);
            var workshops = xml.XPathSelectElements("workshops/workshop");

            foreach (var workshopNode in workshops)
            {
                var worshopName = workshopNode.Attribute("name");
                var location = workshopNode.Attribute("location");
                var price = workshopNode.Attribute("price");
                var startDate = workshopNode.Attribute("start-date");
                var endDate = workshopNode.Attribute("end-date");

                if (worshopName == null || location == null || price==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                var trainer = workshopNode.XPathSelectElement("trainer");

                if (trainer == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }
                string[] FullName = trainer.Value.Split(' ');
                string firstName = FullName[0];
                string lastName = FullName[1];
                
                
                var photographer = context.Photographers.First(p=>p.FirstName == firstName && p.LastName == lastName);

                if (photographer == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                Workshop workshop = new Workshop
                {
                    Name = worshopName.Value,
                    Location = location.Value,
                    PricePerParticipant =decimal.Parse(price.Value),
                    Trainer = photographer
                };

                if (startDate != null)
                {
                    workshop.StartDate = Convert.ToDateTime(startDate.Value);
                }
                if (endDate != null)
                {
                    workshop.EndDate = Convert.ToDateTime(endDate.Value);
                }

                context.Workshops.Add(workshop);
                var participants = workshopNode.XPathSelectElements("participants/participant");

                foreach (var participant in participants)
                {
                    var firsname = participant.Attribute("first-name").Value;
                    var lastname = participant.Attribute("last-name").Value;

                    Photographer participantPhotographer =
                    context.Photographers.First(photo => photo.FirstName == firsname && photo.LastName == lastname);

                    workshop.Participants.Add(participantPhotographer);
                }

                
                context.SaveChanges();
                Console.WriteLine($"Successfully imported {workshop.Name}");

            }

        }
    }
}
