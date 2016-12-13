using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PhotographyWorkshop.Data;
using PhotographyWorkshop.Models;

namespace PhotographyWorkshop.ExportJson
{
    class Program
    {
        static void Main()
        {
            var context  = new PhotographyWorkshopContext();

            ExportPhotographersOrdered(context);
            //ExportPhotographersLandscape(context);


        }

        private static void ExportPhotographersOrdered(PhotographyWorkshopContext context)
        {
            var exportedPhotographers = context.Photographers
                .OrderBy(p => p.FirstName)
                .ThenByDescending(p => p.LastName)
                .Select(p => new
                {
                    p.FirstName,
                    p.LastName,
                    p.Phone
                });
            var json = JsonConvert.SerializeObject(exportedPhotographers, Formatting.Indented);
            File.WriteAllText("../../../result/photographers-ordered.json", json);
        }

        private static void ExportPhotographersLandscape(PhotographyWorkshopContext context)
        {

            var ph = context.Photographers.FirstOrDefault();
            Console.WriteLine(ph.PrimaryCamera.GetType().Name.Substring(0,10));
            Console.WriteLine(typeof(DslrCamera));
            Console.WriteLine(ph.Lenses);
            var exportedPhotographers = context.Photographers.Where(
                photo => photo.PrimaryCamera.GetType().Name.Substring(0,10) == "DslrCamera" && photo.Lenses.Count >= 1)
                .OrderBy(photo => photo.FirstName)
                .Select(photo => new
                {
                    photo.FirstName,
                    photo.LastName,
                    photo.PrimaryCamera.Make,
                    photo.Lenses.Count
                });

            var json = JsonConvert.SerializeObject(exportedPhotographers, Formatting.Indented);
            File.WriteAllText("../../../result/landscape-photographers.json", json);


        }
    }
}
