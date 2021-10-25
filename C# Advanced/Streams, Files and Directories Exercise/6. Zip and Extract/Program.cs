using System;
using System.IO;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"C:\Users\сем. Маринови\Desktop\ДДС\CSharp",
                @"E:\Нова папка\testArchive.zip");
            ZipFile.ExtractToDirectory(@"E:\Нова папка\testArchive.zip",
                @"C:\Users\сем. Маринови\Desktop\ДДС");
        }
    }
}
