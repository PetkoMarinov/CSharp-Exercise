using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._playlist_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> playlist = new Queue<string>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (playlist.Count > 0)
            {
                string[] actions = Console.ReadLine().Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
                string command = actions[0];

                if (command == "Play")
                {
                    playlist.Dequeue();
                }
                else if (command == "Add")
                {
                    string song = actions[1];
                    if (ContainsSong(playlist, song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        playlist.Enqueue(song);
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }
            }

            if (playlist.Count == 0)
            {
                Console.WriteLine("No more songs!");
            }
        }

        private static bool ContainsSong(Queue<string> queue, string song)
        {
            Queue<string> temp = new Queue<string>(queue);
            while (temp.Count > 0)
            {
                string nextSong = temp.Dequeue();
                if (nextSong == song)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
