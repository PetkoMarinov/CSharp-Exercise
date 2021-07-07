using System;
using System.IO;

namespace CopyBinaryFile_withBuffer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream(@"E:\Фото\Приморско 2013\MVI_5826.AVI", FileMode.Open))
            {
                using (FileStream writer = new FileStream(@"output.avi", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
