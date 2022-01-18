using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class TaskDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        public int LabelType { get; set; }
    }
}
