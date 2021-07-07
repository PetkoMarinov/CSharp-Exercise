using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filesInFolder = Directory.GetFiles(@"E:\Programs\Microsoft VS Code");

            Dictionary<string, Dictionary<string, decimal>> files =
                new Dictionary<string, Dictionary<string, decimal>>();

            foreach (var file in filesInFolder)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extention = fileInfo.Extension;
                string fileName = fileInfo.Name.Replace(extention, "");
                decimal size = fileInfo.Length / 1024m;
                
                if (!files.ContainsKey(extention))
                {
                    files.Add(extention, new Dictionary<string, decimal>());
                }

                if (!files[extention].ContainsKey(fileName))
                {
                    files[extention].Add(fileName, size);
                }
            }

            files = files.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value.OrderBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value));

            using (var writer = new StreamWriter(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt"))
            {
                foreach (var file in files)
                {
                    writer.WriteLine(file.Key);

                    foreach (var filename in file.Value)
                    {
                        writer.WriteLine($"--{filename.Key} - {filename.Value:f3}kb");
                    }
                }
            }
        }
    }
}
