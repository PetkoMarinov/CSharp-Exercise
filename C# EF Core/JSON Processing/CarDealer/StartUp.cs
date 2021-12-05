using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.DTO.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string inputSuppliers = File.ReadAllText(@"E:\C#\C# EF Core\JSON Processing\CarDealer\Datasets\suppliers.json");
            //string inputParts = File.ReadAllText(@"E:\C#\C# EF Core\JSON Processing\CarDealer\Datasets\parts.json");
            string inputCars = File.ReadAllText(@"E:\C#\C# EF Core\JSON Processing\CarDealer\Datasets\cars.json");
            //Console.WriteLine(ImportSuppliers(context, inputSuppliers));
            //Console.WriteLine(ImportParts(context, inputParts));
            Console.WriteLine(ImportCars(context, inputCars));
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<Car>>(inputJson);
            var newCars = context.Cars
                .Include(x=>x.PartCars)
            foreach (var car in cars)
            {
                foreach (var itepartm in car.PartCars)
                {

                }        
            }
            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeMapper();
            var dtoParts = JsonConvert.DeserializeObject<IEnumerable<DtoParts>>(inputJson);
            var parts = mapper.Map<IEnumerable<Part>>(dtoParts);

            foreach (var part in parts)
            {
                if (context.Suppliers.Select(s => s.Id).Contains(part.SupplierId))
                {
                    context.Parts.Add(part);
                }
            }

            context.SaveChanges();
            return $"Successfully imported {context.Parts.Count()}.";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();
            var dtoSupplers = JsonConvert.DeserializeObject<IEnumerable<DtoSupplier>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(dtoSupplers);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            mapper = new Mapper(config);
        }
    }
}