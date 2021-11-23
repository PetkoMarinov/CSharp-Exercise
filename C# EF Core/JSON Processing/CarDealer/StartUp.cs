using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.DTO.Import;
using CarDealer.Models;
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

            string inputSuppliers = File.ReadAllText(@"E:\C#\C# EF Core\JSON Processing\CarDealer\Datasets\suppliers.json");
            string inputParts = File.ReadAllText(@"E:\C#\C# EF Core\JSON Processing\CarDealer\Datasets\parts.json");
            Console.WriteLine(ImportSuppliers(context, inputSuppliers));
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeMapper();
            var dtoParts = JsonConvert.DeserializeObject<IEnumerable<DtoParts>>(inputJson);
            var 
            return $"Successfully imported {Parts.Count}.";
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