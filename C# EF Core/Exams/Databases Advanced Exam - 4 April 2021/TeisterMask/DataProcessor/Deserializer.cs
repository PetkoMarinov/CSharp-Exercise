namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var reader = new StringReader(xmlString);
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectsDto[]),new XmlRootAttribute("Projects"));
            var projects = (ProjectsDto[])serializer.Deserialize(reader);
            foreach (var item in projects)
            {
                foreach (var task in item.Tasks)
                {
                    Console.WriteLine(task.Name);
                }
            }
            return "";
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var employeesDTO = JsonConvert.DeserializeObject<IEnumerable<EmployeesDto>>(jsonString);



            return "";
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}