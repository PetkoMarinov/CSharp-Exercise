namespace SandBox
{
    using System;

    public class EntryPoint
    {
        public static void Main()
        {

            long triangleRows = long.Parse(Console.ReadLine());

            long[][] array = new long[triangleRows][];

            array[0] = new long[1];
            array[0][0] = 1;


            for (long row = 1; row < array.Length; row++)
            {
                array[row] = new long[row + 1];
                array[row][0] = 1;
                array[row][array[row].Length - 1] = 1;

                for (long col = 1; col < array[row].Length - 1; col++)
                {
                    long[] previousRow = array[row - 1];
                    long left = previousRow[col - 1];
                    long right = previousRow[col];

                    array[row][col] = left + right;
                }
            }

            for (long row = 0; row < triangleRows; row++)
            {
                Console.WriteLine(string.Join(" ", array[row]));
            }
        }
    }
}