namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            context.Database.EnsureCreated();
            //Test your solutions here

            string result = ExportAlbumsInfo(context, 9);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .ToArray()
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    AlbumPrice = a.Price.ToString("F2"),
                    Songs = a.Songs
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("F2"),
                            SongWriterName = s.Writer.Name
                        })
                    .OrderByDescending(s => s.SongName)
                    .ThenBy(s => s.SongWriterName)
                });

            StringBuilder sb = new StringBuilder();

            foreach (var item in albums)
            {
                sb.
                    AppendLine($"-AlbumName: {item.AlbumName}")
                   .AppendLine($"-ReleaseDate: {item.ReleaseDate}")
                   .AppendLine($"-ProducerName: {item.ProducerName}")
                   .AppendLine($"-Songs:");

                int i = 1;
                foreach (var song in item.Songs)
                {
                    sb.
                        AppendLine($"---#{i++}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price}")
                        .AppendLine($"---Writer: {song.SongWriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {item.AlbumPrice}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
