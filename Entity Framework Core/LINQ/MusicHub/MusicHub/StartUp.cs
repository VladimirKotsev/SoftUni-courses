namespace MusicHub
{
    using System;
    using System.Text;
    using System.Globalization;

    using Initializer;
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportAlbumsInfo(context, 9));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId.HasValue && a.ProducerId.Value == producerId)
                .ToList()
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer!.Name,
                    Songs = a.Songs,
                    a.Price
                });


            StringBuilder sb = new StringBuilder();

            foreach (var album in albums)
            {
                int songCount = 1;
                decimal albumPrice = 0;
                albumPrice += album.Price;

                sb
                    .AppendLine($"-AlbumName: {album.Name}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                    .AppendLine($"-ProducerName: {album.ProducerName}");

                sb.AppendLine("-Songs:");
                foreach (var song in album.Songs.OrderByDescending(x => x.Name).ThenBy(x => x.Writer.Name))
                {
                    sb
                        .AppendLine($"---#{songCount}")
                        .AppendLine($"---SongName: {song.Name}")
                        .AppendLine($"---Price: {song.Price:f2}")
                        .AppendLine($"---Writer: {song.Writer.Name}");
                    songCount++;
                }
                sb.AppendLine($"-AlbumPrice: {albumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .AsEnumerable()
                .Where(s => s.Duration.TotalSeconds > duration)
                .ToList()
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer.Name)
                .Select(s => new
                {
                    s.Name,
                    Performers = s.SongPerformers
                        .Select(p => p.Performer.FirstName + " " + p.Performer.LastName)
                        .OrderBy(p => p)
                        .ToList(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album!.Producer!.Name,
                    Duratation = s.Duration.ToString("c", CultureInfo.InvariantCulture)
                });

            StringBuilder sb = new StringBuilder();

            int songCount = 1;
            foreach(var song in songs)
            {
                sb
                    .AppendLine($"-Song #{songCount}")
                    .AppendLine($"---SongName: {song.Name}")
                    .AppendLine($"---Writer: {song.WriterName}");
                if (song.Performers.Count() != 0)
                {
                    foreach(var performer in song.Performers)
                    {
                        sb.AppendLine($"---Performer: {performer}");
                    }
                }
                sb
                    .AppendLine($"---AlbumProducer: {song.AlbumProducer}")
                    .AppendLine($"---Duration: {song.Duratation}");
                songCount++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
