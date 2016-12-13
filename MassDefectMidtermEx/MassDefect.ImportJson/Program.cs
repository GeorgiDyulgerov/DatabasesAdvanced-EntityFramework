using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using AutoMapper;
using MassDefect.Data;
using MassDefect.Dtos;
using MassDefect.Models;
using Newtonsoft.Json;

namespace MassDefect.ImportJson
{
    class Program
    {
        private const string SolarSystemsPath = "../../../datasets/solar-systems.json";
        private const string StarsPath = "../../../datasets/stars.json";
        private const string PlanetsPath = "../../../datasets/planets.json";
        private const string PersonsPath = "../../../datasets/persons.json";
        private const string AnomaliesPath = "../../../datasets/anomalies.json";
        private const string AnomalyVictumsPath = "../../../datasets/anomaly-victims.json";
        private const string Error = "Error: Invalid data";

        static void Main()
        {
            UnitOfWork unit = new UnitOfWork();
            ConfigureMapping(unit);
            ImportSolarSystem(unit);
            ImportStars(unit);
            ImportPlanets(unit);
            ImportPersons(unit);
            ImportAnomalies(unit);
            ImportAnomalyVictims(unit);
        }

        private static void ConfigureMapping(UnitOfWork unit)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<SolarSystemDto, SolarSystem>();

                config.CreateMap<StarDto, Star>().ForMember(star => star.SolarSystem, expression => expression
                   .MapFrom(dto => unit.SolarSystems.First(solSys => solSys.Name == dto.SolarSystem)));

                config.CreateMap<PlanetDto, Planet>().ForMember(planet => planet.SolarSystem, expression => expression
                    .MapFrom(dto => unit.SolarSystems.First(solSys => solSys.Name == dto.SolarSystem)))
                   .ForMember(planet => planet.Sun, expression => expression
                   .MapFrom(dto => unit.Stars.First(star => star.Name == dto.Sun)));

                config.CreateMap<PersonDto, Person>().ForMember(person => person.HomePlanet, expression => expression
                    .MapFrom(dto => unit.Planets.First(planet => planet.Name == dto.HomePlanet)));

                config.CreateMap<AnomalyDto, Anomaly>().ForMember(anom => anom.OriginPlanet, expression => expression
                    .MapFrom(dto => unit.Planets.First(planet=>planet.Name==dto.OriginPlanet)))
                    .ForMember(anom => anom.TeleportPlanet, expression => expression
                    .MapFrom(dto => unit.Planets.First(planet => planet.Name == dto.TeleportPlanet)));
            });
        }


        private static void ImportAnomalyVictims(UnitOfWork unit)
        {
            var json = File.ReadAllText(AnomalyVictumsPath);
            IEnumerable<AnomalyVictimsDto> anomalyVictimsDtos =
                JsonConvert.DeserializeObject<IEnumerable<AnomalyVictimsDto>>(json);

            foreach (var anomalyVictimsDto in anomalyVictimsDtos)
            {
                if (anomalyVictimsDto.Id==null||anomalyVictimsDto.Person==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                var anomalyEntity = unit.Anomalies.First(anom=>anom.Id==anomalyVictimsDto.Id);
                var personEntity = unit.Persons.First(person => person.Name == anomalyVictimsDto.Person);

                if (anomalyEntity==null||personEntity==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                if (anomalyEntity.Victims==null)
                {
                    anomalyEntity.Victims=new List<Person>();
                }
                anomalyEntity.Victims.Add(personEntity);
                unit.Commit();


            }


        }

        private static void ImportAnomalies(UnitOfWork unit)
        {
            var json = File.ReadAllText(AnomaliesPath);
            IEnumerable<AnomalyDto> anomalyDtos = JsonConvert.DeserializeObject<IEnumerable<AnomalyDto>>(json);

            foreach (var anomalyDto in anomalyDtos)
            {
                if (anomalyDto.OriginPlanet == null || anomalyDto.TeleportPlanet == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                Anomaly anomaly = Mapper.Map<Anomaly>(anomalyDto);
                if (anomaly.OriginPlanet==null || anomaly.TeleportPlanet==null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                unit.Anomalies.Add(anomaly);
                unit.Commit();
                Console.WriteLine($"Successfully imported Anomaly");

            }

        }

        private static void ImportPersons(UnitOfWork unit)
        {
            var json = File.ReadAllText(PersonsPath);
            IEnumerable<PersonDto> personDtos = JsonConvert.DeserializeObject<IEnumerable<PersonDto>>(json);

            foreach (var personDto in personDtos)
            {
                if (personDto.Name == null || personDto.HomePlanet == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                Person person = Mapper.Map<Person>(personDto);
                if (person.HomePlanet == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                unit.Persons.Add(person);
                unit.Commit();
                Console.WriteLine($"Successfuly imported Person {person.Name}");
            }


        }

        private static void ImportPlanets(UnitOfWork unit)
        {
            var json = File.ReadAllText(PlanetsPath);
            IEnumerable<PlanetDto> planetDtos = JsonConvert.DeserializeObject<IEnumerable<PlanetDto>>(json);

            foreach (var planetDto in planetDtos)
            {
                if (planetDto.Name == null || planetDto.SolarSystem == null || planetDto.Sun == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                Planet planet = Mapper.Map<Planet>(planetDto);

                if (planet.SolarSystem == null || planet.Sun == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                unit.Planets.Add(planet);
                unit.Commit();
                Console.WriteLine($"Successfuly imported Planet {planet.Name}");
            }
        }

        private static void ImportStars(UnitOfWork unit)
        {
            var json = File.ReadAllText(StarsPath);
            IEnumerable<StarDto> starDtos = JsonConvert.DeserializeObject<IEnumerable<StarDto>>(json);

            foreach (var starDto in starDtos)
            {
                if (starDto.Name == null || starDto.SolarSystem == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                Star star = Mapper.Map<Star>(starDto);

                if (star.SolarSystem == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                unit.Stars.Add(star);
                unit.Commit();
                Console.WriteLine($"Successfully imported Star {star.Name}");

            }



        }

        private static void ImportSolarSystem(UnitOfWork unit)
        {
            var json = File.ReadAllText(SolarSystemsPath);
            IEnumerable<SolarSystemDto> solarSystemDtos = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDto>>(json);

            foreach (var solarSystemDto in solarSystemDtos)
            {
                if (solarSystemDto.Name == null)
                {
                    Console.WriteLine(Error);
                    continue;
                }

                SolarSystem solarSystem = Mapper.Map<SolarSystem>(solarSystemDto);
                unit.SolarSystems.Add(solarSystem);
                unit.Commit();
                Console.WriteLine($"Successfully imported Solar System {solarSystem.Name}");
            }
        }
    }
}
