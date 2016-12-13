using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AutoMapper;
using AutoMapper.Execution;
using Newtonsoft.Json;
using PhotographyWorkshop.Data;
using PhotographyWorkshop.Dto;
using PhotographyWorkshop.Models;

namespace PhotographyWorkshop.ImportJson
{
    class Program
    {
        private const string CamerasPath = "../../../datasets/cameras.json";
        private const string LensesPath = "../../../datasets/lenses.json";
        private const string PhotographersPath = "../../../datasets/photographers.json";
        private const string Error = "Error. Invalid data provided";


        static void Main(string[] args)
        {
            var context = new PhotographyWorkshopContext();

            ConfigureMapping(context);
            ImportCameras(context);
            ImportLenses(context);
            ImportPhotographers(context);



        }

        private static void ConfigureMapping(PhotographyWorkshopContext context)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<CameraDto, Camera>();
                config.CreateMap<CameraDto, DslrCamera>();
                config.CreateMap<CameraDto, MirrorlessCamera>();

                config.CreateMap<LensDto, Lens>();
            });
        }

        private static void ImportCameras(PhotographyWorkshopContext context)
        {
            var json = File.ReadAllText(CamerasPath);
            IEnumerable<CameraDto> cameraDtos = JsonConvert.DeserializeObject<IEnumerable<CameraDto>>(json);

            foreach (var cameraDto in cameraDtos)
            {
                if (cameraDto.Type == null || cameraDto.Make == null || cameraDto.Model == null || cameraDto.MinIso == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }


                if (cameraDto.Type == "DSLR")
                {
                    DslrCamera camera = Mapper.Map<DslrCamera>(cameraDto);
                    context.Cameras.Add(camera);
                    context.SaveChanges();
                    Console.WriteLine($"Successfully imported DSLR {camera.Make} {camera.Model}");
                }
                else if (cameraDto.Type == "Mirrorless")
                {
                    MirrorlessCamera camera = Mapper.Map<MirrorlessCamera>(cameraDto);
                    context.Cameras.Add(camera);
                    context.SaveChanges();
                    Console.WriteLine($"Successfully imported Mirrorless {camera.Make} {camera.Model}");
                }

            }



        }

        private static void ImportLenses(PhotographyWorkshopContext context)
        {
            var json = File.ReadAllText(LensesPath);
            IEnumerable<LensDto> lensDtos = JsonConvert.DeserializeObject<IEnumerable<LensDto>>(json);

            foreach (var lensDto in lensDtos)
            {
                if (lensDto.Make == null || lensDto.CompatibleWith == null || lensDto.FocalLength == null || lensDto.MaxAperture == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                Lens lens = Mapper.Map<Lens>(lensDto);
                context.Lenses.Add(lens);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported {lens.Make} {lens.FocalLength}mm f{lens.MaxAperture:#.0}");


            }
        }

        private static void ImportPhotographers(PhotographyWorkshopContext context)
        {
            var json = File.ReadAllText(PhotographersPath);
            IEnumerable<PhotographerDto> photographerDtos = JsonConvert.DeserializeObject<IEnumerable<PhotographerDto>>(json);

            foreach (var photographerDto in photographerDtos)
            {
                if (photographerDto.FirstName == null || photographerDto.LastName == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                Random rand = new Random();
                Photographer photographer = new Photographer();
                photographer.FirstName = photographerDto.FirstName;
                photographer.LastName = photographerDto.LastName;
                photographer.PrimaryCamera =
                    context.Cameras.Find(rand.Next(1, context.Cameras.Count()));
                photographer.SecondaryCamera =
                    context.Cameras.Find(rand.Next(1, context.Cameras.Count()));

                if(photographerDto.Phone==null)
                {
                    photographer.Phone = null;
                }
                else if (IsPhone(photographerDto.Phone))
                {
                    photographer.Phone = photographerDto.Phone;
                }
                else
                {
                    Console.WriteLine(Error);
                    continue;
                }


                foreach (var lense in photographerDto.Lenses)
                {
                    var lens = context.Lenses.Find(lense);
                    if (lens == null)
                    {
                        continue;
                    }
                    if (photographer.PrimaryCamera.Make != lens.Make || photographer.SecondaryCamera.Make != lens.Make)
                    {
                        continue;
                    }
                    photographer.Lenses.Add(lens);
                }

                context.Photographers.Add(photographer);
                context.SaveChanges();
                Console.WriteLine($"Successfully imported {photographer.FirstName} {photographer.LastName} | Lenses: {photographer.Lenses.Count}");


            }
        }

        private static bool IsPhone(string phone)
        {
            if (phone == null)
            {
                return false;
            }
            string regularExpressinString = @"\(?\+[0-9]{1,3}\)?\/([0-9]{6,10})";
            Regex regex = new Regex(regularExpressinString);
            if (regex.IsMatch(phone))
            {
                return true;
            }

            return false;
        }
    }
}
