namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public ResourceType ResourceType { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }


        //o ResourceId
        //o Name - (up to 50 characters, unicode)
        //o Url - (not unicode)
        //o   ResourceType - (enum – can be Video, Presentation, Document or Other)
        //o CourseId

    }
}
